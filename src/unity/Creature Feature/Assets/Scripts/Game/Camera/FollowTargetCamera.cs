using UnityEngine;
using UnityEngine.Events;

public class FollowTargetCamera : MonoBehaviour
{
    const float DAMPENING = 0.1f;

    private bool _sticky;

    public Rect bounds;

    public Transform target;

    public bool stopAtEnd;
   
    public class TargetCameraUnityEvent : UnityEvent { }

    void Awake()
    {
        EventManager.Current.CreateEvent<TargetCameraUnityEvent>();
    }

    void OnDestroy()
    {
        // TODO: RemoveEvent    
    }

    void LateUpdate()
    {
        if (_sticky)
            return;

        var t = Time.deltaTime / DAMPENING;

        var targetPos = new Vector3(target.position.x, 0f, transform.position.z);
        transform.position = Vector3.Lerp(targetPos, transform.position, t);

        // Minimum position
        if (transform.position.x < bounds.xMin)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }

        if (transform.position.x > bounds.xMax)
        {
            transform.position = new Vector3(bounds.xMax, transform.position.y, transform.position.z);
            _sticky = stopAtEnd;

            EventManager.Current.Post<TargetCameraUnityEvent>();
        }
    }
}
