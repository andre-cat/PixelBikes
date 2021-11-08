using UnityEngine;

public class Instanciar : MonoBehaviour
{
    public GameObject objeto;
    public GameObject punto;

    void Start()
    {
        objeto = Instantiate(objeto, punto.transform.position, Quaternion.identity, punto.transform);
    }
}
