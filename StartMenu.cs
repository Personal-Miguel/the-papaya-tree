using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("ThePapayaTree");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
