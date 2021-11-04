using UnityEngine;

public class Controlador : MonoBehaviour
{
    public static float dificultad = 10;

    public static float factor()
    {
        float reducción = (10 * dificultad) / 100;
        return reducción;
    }
}