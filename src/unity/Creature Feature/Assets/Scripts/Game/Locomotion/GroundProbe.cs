using UnityEngine;

public class GroundProbe : MonoBehaviour
{
    const float PROBE_RADIUS = 0.1f;

    public Transform probePoint;
    
    public bool IsOnGround()
    {
        var collider = Physics2D.OverlapCircle(probePoint.position, PROBE_RADIUS, LayerMask.GetMask("Platforms"));
        return collider != null;
    }
}
