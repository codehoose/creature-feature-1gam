using UnityEngine;
using System.Collections;

public class PatrolMob : MonoBehaviour
{
    Vector3 _start;
    Vector3 _end;

    public float length;

    public bool startFacingRight;

    public float speed;

    private void Awake()
    {
        _start = transform.position;
        _end = transform.position + Vector3.right * length;
    }

    IEnumerator Start()
    {
        var npc = gameObject.GetComponentInChildren<SpriteRenderer>();
        if (npc == null)
            yield break;

        bool outbound = true;
        npc.flipX = startFacingRight;

        var start = _start;
        var end = _end;
        
        while (true)
        {
            while (transform.position != end)
            {
                transform.position = Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime);
                yield return null;
            }

            transform.position = end;

            npc.flipX = !npc.flipX;

            outbound = !outbound;
            start = outbound ? _start : _end;
            end = outbound ? _end : _start;
        }
    }

    private void OnDrawGizmosSelected()
    {
        var start = _start == Vector3.zero ? transform.position : _start;
        var end = _end == Vector3.zero ? transform.position + Vector3.right * length : _end;

        var tmp = Gizmos.color;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(start, end);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(start, 0.25f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(end, 0.25f);

        Gizmos.color = tmp;
    }
}
