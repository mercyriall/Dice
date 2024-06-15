using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void OnClickToBackMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickToStartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickToExit()
    {
        Application.Quit();
    }

}
