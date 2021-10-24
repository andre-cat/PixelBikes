using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exit()
    {
        Debug.Log("EXIT!!!");
        Application.Quit();
    }

    public void options()
    {
        SceneManager.LoadScene("options_menu");
    }

    public void back()
    {
        SceneManager.LoadScene("main_menu");
    }
}