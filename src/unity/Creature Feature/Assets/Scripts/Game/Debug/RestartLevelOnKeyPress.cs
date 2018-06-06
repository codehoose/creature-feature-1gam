using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartLevelOnKeyPress : MonoBehaviour
{

    public KeyCode key = KeyCode.R;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
