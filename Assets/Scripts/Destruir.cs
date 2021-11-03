using UnityEngine;

public class Destruir : MonoBehaviour
{
    public GameObject objeto;

    private void destruir()
    {
        Destroy(objeto);
    }
}