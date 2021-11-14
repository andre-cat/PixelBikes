using UnityEngine;

public class Obstáculo : MonoBehaviour
{
    public enum Daño{
        Ninguno,
        Bajo,
        Medio,
        Alto
    }

    public enum Destruible{
        Sí,
        No,
    }

    public string nombre;
    public Daño daño;
    public Destruible destruible;
}
