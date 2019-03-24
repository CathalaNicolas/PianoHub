using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.LoadScene("PlayMenu");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
