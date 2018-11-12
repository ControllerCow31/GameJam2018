using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Quits the player when the user hits escape

public class QuitOnEsc : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        } else if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}