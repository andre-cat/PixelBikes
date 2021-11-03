using UnityEngine;

[CreateAssetMenu]
public class ContenedorObstáculo : ScriptableObject
{
    public GameObject[] contenedor;


    public int número_obstáculos
    {
        get
        {
            return contenedor.Length;
        }
    }

    public GameObject obtener_obstáculo(int índice)
    {
        return contenedor[índice];
    }
}
