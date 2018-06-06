using UnityEngine;
using System.Collections;

public class PlayOneShotAudio : MonoBehaviour
{
    public bool destroyAfterPlayed;

    IEnumerator Start()
    {
        var audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            yield break;

        if (destroyAfterPlayed)
        {
            yield return new WaitForSeconds(audioSource.clip.length);
            Destroy(gameObject);
        }
    }
}
