using UnityEngine;

public class Crear : MonoBehaviour
{

    public GameObject objeto;
    public Transform punto;
    public float duración;

    void crear()
    {
        GameObject instanciado = Instantiate(objeto, punto.position, Quaternion.identity);

        if (duración > 0)
        {
            Destroy(instanciado, duración);
        }
    }
}
