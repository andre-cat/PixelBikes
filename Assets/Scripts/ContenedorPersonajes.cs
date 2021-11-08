using UnityEngine;

[CreateAssetMenu(fileName = "Personajes")]
public class ContenedorPersonajes : ScriptableObject
{
    public Personaje[] contenedor;

    public int número
    {
        get
        {
            return contenedor.Length;
        }
    }

    public Personaje personaje(int i)
    {
        return contenedor[i];
    }
}