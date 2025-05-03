using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
       
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
