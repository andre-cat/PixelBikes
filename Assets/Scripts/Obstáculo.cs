using UnityEngine;

public class Obstáculo : MonoBehaviour
{

    public enum Daño
    {
        Ninguno,
        Moderado,
        Letal,
    }

    public enum Tipo
    {
        Destructible,
        Indestructible,
    }

    public Daño daño;
    public Tipo tipo;
}