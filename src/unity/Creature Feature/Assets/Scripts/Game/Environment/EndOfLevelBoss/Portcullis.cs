using System.Collections;
using UnityEngine;

public class Portcullis : MonoBehaviour
{
    public Vector3 target = new Vector3(-1, 0, 0);

    void Start()
    {
        EventManager.Current.ListenForEvent<FollowTargetCamera.TargetCameraUnityEvent>(DropGate);
    }

    void DropGate()
    {
        StartCoroutine(DropTheGate());
    }

    IEnumerator DropTheGate()
    {
        Vector3 start = transform.position;

        float duration = 0.5f;

        float time = 0;
        while (time < 1f)
        {
            transform.position = Vector3.Lerp(start, target, time);
            time += Time.deltaTime / duration;

            yield return null;
        }

        transform.position = target;
    }
}
