using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CargadorNivel : MonoBehaviour
{
    public static bool over;

    void Start()
    {
        over = false;
    }

    public void jugar()
    {
        cargar_escena("TRANS");
    }

    public void nivel()
    {
        SceneManager.LoadScene("NIVEL_" + PlayerPrefs.GetInt("nivel"));
    }

    public void avatar()
    {
        cargar_escena("AVATAR");
    }

    public void tienda()
    {
        cargar_escena("TIENDA");
    }

    public void opciones()
    {
        cargar_escena("OPCIONES");
    }

    public void volver()
    {
        cargar_escena("MENU");
    }

    public void muerte()
    {
        StartCoroutine(cargar_escena("MUERTE", 3));
    }

    public void trans()
    {
        if (SceneManager.GetActiveScene().name != "Nivel_3")
        {
            StartCoroutine(cargar_escena("TRANS", 3));
        }
        else
        {
            StartCoroutine(cargar_escena("FINAL", 3));
        }
    }

    public void salir()
    {
        GetComponent<Animator>().SetTrigger("Iniciar");
        Debug.Log("¡SALIR!");
        Application.Quit();
    }

    private void cargar_escena(string nombre)
    {
        if (SceneManager.GetActiveScene().name != "MUERTE" & SceneManager.GetActiveScene().name != "FINAL")
        {
            GetComponent<Animator>().SetTrigger("Iniciar");
        }
        SceneManager.LoadScene(nombre);
    }

    IEnumerator cargar_escena(string nombre, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        GetComponent<Animator>().SetTrigger("Terminar");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nombre);
    }
}
