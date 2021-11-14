using UnityEngine;

public class Controlador : MonoBehaviour
{
    public static bool over;

    void Start()
    {
        over = false;
        predeterminado();
    }

    public static void predeterminado()
    {
        PlayerPrefs.SetInt("vida", 100);
        PlayerPrefs.SetInt("nivel", 1);
        PlayerPrefs.SetFloat("dificultad", 1);
        PlayerPrefs.SetFloat("tiempo", 30);
    }

    public static float factor()
    {
        float factor = PlayerPrefs.GetFloat("dificultad", 1);
        return factor;
    }
}