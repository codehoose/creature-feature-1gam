using UnityEngine;

public class FollowTargetCamera : MonoBehaviour
{
    const float DAMPENING = 0.1f;

    public float minX = 0f; // TODO: Set max position too!
    
    public Transform target;

    void LateUpdate()
    {
        var t = Time.deltaTime / DAMPENING;

        var targetPos = new Vector3(target.position.x, 0f, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, t);

        // Minimum position
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
}
