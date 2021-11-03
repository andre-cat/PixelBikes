using UnityEngine;

[CreateAssetMenu]
public class ContenedorObstáculo : ScriptableObject
{
    public GameObject[] contenedor;

    public GameObject obtener_obstáculo(int índice)
    {
        return contenedor[índice];
    }
}
