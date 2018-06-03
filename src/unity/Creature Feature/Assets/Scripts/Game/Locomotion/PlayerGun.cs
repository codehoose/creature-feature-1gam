using System.Collections;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    const int MAX_POOL_SIZE = 50;

    float _lastDirection = 1;
    int _index = 0;
    Rigidbody2D[] _pool = new Rigidbody2D[MAX_POOL_SIZE];

    [Header("Parameters")]
    [Tooltip("Cooldown period between bullets")]
    public float cooldownPeriod = 0.75f;

    [Header("Objects")]
    [Tooltip("Point at which bullets are spawned")]
    public Transform point;

    [HideInInspector]
    public GameObject bulletPrefab;

    IEnumerator Start()
    {
        while (bulletPrefab == null)
        {
            yield return null;
        }

        FillPool();

        while (true)
        {
            if (Input.GetButton("Fire3"))
            {
                SpawnBullet();
                yield return new WaitForSeconds(cooldownPeriod);
            }
            else
            {
                yield return null;
            }
        }
    }

    void SpawnBullet()
    {
        var tmp = Input.GetAxis("Horizontal");
        if (tmp > 0)
        {
            _lastDirection = 1f;
        }
        else if (tmp < 0)
        {
            _lastDirection = -1f;
        }
        else
        {
            _lastDirection = 1f;
        }
        
        _pool[_index].gameObject.SetActive(true);
        _pool[_index].transform.SetPositionAndRotation(point.position, Quaternion.identity);
        _pool[_index].velocity = Vector2.zero;
        _pool[_index].AddForce(new Vector2(16, 0) * _lastDirection, ForceMode2D.Impulse);
        
        _index++;
        _index %= MAX_POOL_SIZE;
    }

    void FillPool()
    {
        for (int i = 0; i < MAX_POOL_SIZE; i++)
        {
            _pool[i] = Instantiate(bulletPrefab).GetComponent<Rigidbody2D>();
            _pool[i].gameObject.SetActive(false);
        }
    }
}
