using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Game");
        print("Ici");
    }

    public void OnClickQuit()
    {
        Application.Quit();
        print("LA");
    }
}
