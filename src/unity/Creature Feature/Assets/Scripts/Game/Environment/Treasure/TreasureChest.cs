using System;
using System.Collections;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    bool playerIsTouching;
    bool treasureRevealed;

    Sprite _prize;
    Action _action;

    [Tooltip("The open treasure chest image")]
    public Sprite opened;   

    [Tooltip("The image riser point")]
    public GameObject riser;

    [Tooltip("The time it takes for the icon to rise up")]
    public float riseDuration = 0.5f;

    [Tooltip("The wait time before the icon fades away")]
    public float showDelay = 1.5f;

    [Tooltip("The types of treasure available from this chest")]
    public TreasureScriptableObject[] treasures;
    
    IEnumerator Start()
    {
        var manager = FindObjectOfType<TreasureChestLevelManager>();

        if (treasures==null || treasures.Length == 0)
        {
            yield break;
        }

        var rand = UnityEngine.Random.Range(0, treasures.Length);
        _prize = treasures[rand].icon;
        _action = treasures[rand].Apply;

        while (!treasureRevealed)
        {
            if (playerIsTouching && Input.GetButtonDown("Fire2"))
            {
                yield return OpenChest();
            }
            else
            {
                yield return null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            playerIsTouching = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerIsTouching = false;
    }

    IEnumerator OpenChest()
    {
        treasureRevealed = true;
        GetComponent<SpriteRenderer>().sprite = opened;
        riser.GetComponent<SpriteRenderer>().sprite = _prize;

        if (_action != null)
        {
            _action();
        }

        float t = 0f;
        while (t < 1f)
        {
            riser.transform.localPosition = Vector2.Lerp(riser.transform.localPosition, new Vector2(0, 1.5f), t);
            t += Time.deltaTime / riseDuration;
            yield return null;
        }

        yield return new WaitForSeconds(showDelay);

        float alpha = 1f;
        var sp = riser.GetComponent<SpriteRenderer>();
        var clr = sp.color;

        t = 0;
        while (t < 1f)
        {
            clr.a = Mathf.Lerp(1, 0, t);
            sp.color = clr;
            riser.transform.localPosition = Vector2.Lerp(riser.transform.localPosition, new Vector2(0, 0), t);

            t += Time.deltaTime / riseDuration;
            yield return null;
        }

        riser.SetActive(false);       
    }
}
