using UnityEngine;

public class Controlador : MonoBehaviour
{

    public static int nivel = 1;
    public static int vida = 100;
    public static int limon = 0;
    public static float dificultad = 10;
    public static float tiempo = 30;

    public static float factor()
    {
        float reducción = (10 * dificultad) / 100;
        return reducción;
    }
}