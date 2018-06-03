using System.Collections;
using UnityEngine;

public class Locomotion : MonoBehaviour {

    const float MAX_VELOCITY = 7.5f;

    bool canJump = false;
    Rigidbody2D _rb;
    GroundProbe _probe;
    Vector2 hSpeed = new Vector2(15, 0);
    Vector2 _speed = Vector3.zero;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _probe = GetComponent<GroundProbe>();
    }

    IEnumerator Start()
    {
        while (!_probe.IsOnGround())
        {
            yield return null;
        }

        canJump = true;
    }

    void Update()
    {
        var input = Input.GetAxis("Horizontal");
        _speed = hSpeed * input * Time.deltaTime;

        if (canJump && Input.GetButtonDown("Fire1") && _probe.IsOnGround())
        {
            StartCoroutine(DoJump());
        }
    }

    void FixedUpdate()
    {
        if (_speed.magnitude > 0.1f)
        {
            _rb.AddForce(_speed, ForceMode2D.Impulse);
            if (Mathf.Abs(_rb.velocity.x) > MAX_VELOCITY)
            {
                // Taken from https://unity3d.com/learn/tutorials/topics/2d-game-creation/creating-basic-platformer-game
                _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * MAX_VELOCITY, _rb.velocity.y);
            }
        }
	}

    IEnumerator DoJump()
    {
        canJump = false;
        float force = 7.5f;

        _rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.25f);
        canJump = true;
    }
}
