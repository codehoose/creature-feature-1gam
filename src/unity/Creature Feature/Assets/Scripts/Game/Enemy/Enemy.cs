using UnityEngine;

public class Enemy : MonoBehaviour
{
    AudioSource _audioSource;

    public int health = 3;

    public AudioClip normalHit;
    public AudioClip deathHit;

    public GameObject enemyDrop;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Bullet")
        {
            collision.gameObject.SetActive(false); // Hide the bullet
            health--; // subtract the health
            if (health > 0)
            {
                Play(collision.transform.position, normalHit);
            }
            else
            {
                Play(collision.transform.position, deathHit, true);
            }
        }
    }

    void Play(Vector2 pos, AudioClip clip, bool destroy = false)
    {
        _audioSource.PlayOneShot(clip);
        // TODO: Play explosion / reaction

        if (destroy)
        {
            if (enemyDrop != null)
            {
                var copy = Instantiate(enemyDrop);
                copy.transform.position = transform.position;
                copy.transform.localPosition = Vector3.zero;
            }

            Destroy(gameObject);
        }
    }
}
