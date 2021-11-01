using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void salir()
    {
        Debug.Log("¡SALIR!");
        Application.Quit();
    }

    public void opciones()
    {
        SceneManager.LoadScene("Opciones");
    }

     public void avatar()
    {
        SceneManager.LoadScene("");
    }

    public void volver()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}