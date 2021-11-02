using UnityEngine;

[CreateAssetMenu]
public class ContenedorPersonaje : ScriptableObject
{
    public Personaje[] contenedor;

    public int número_personajes
    {
        get
        {
            return contenedor.Length;
        }
    }

    public Personaje obtener_personaje(int i)
    {
        return contenedor[i];
    }
}