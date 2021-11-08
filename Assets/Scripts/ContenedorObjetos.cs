using UnityEngine;

[CreateAssetMenu(fileName = "Objetos")]
public class ContenedorObjetos : ScriptableObject
{
    public GameObject[] contenedor;

    public int número
    {
        get
        {
         return contenedor.Length;
        }
    }

    public GameObject objeto(int índice)
    {
        return contenedor[índice];
    }
}
