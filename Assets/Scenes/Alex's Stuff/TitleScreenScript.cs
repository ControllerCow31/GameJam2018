using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreenScript : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Rough Level");
    }
}
