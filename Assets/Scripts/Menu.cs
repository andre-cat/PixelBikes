using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   public void avatar()
    {
        SceneManager.LoadScene("AVATAR");
    }

       public void tienda()
    {
        SceneManager.LoadScene("TIENDA");
    }

    public void opciones()
    {
        SceneManager.LoadScene("OPCIONES");
    }

    public void volver()
    {
        SceneManager.LoadScene("MENU");
    }

     public void salir()
    {
        Debug.Log("¡SALIR!");
        Application.Quit();
    }
}