using UnityEngine;

public class CrearObjeto : MonoBehaviour
{

    public GameObject objeto;
    public GameObject punto;
    public float duración;

    void crear()
    {
        GameObject instanciado = Instantiate(objeto, punto.transform.position, Quaternion.identity);

        if (duración > 0)
        {
            Destroy(instanciado, duración);
        }
    }
}
