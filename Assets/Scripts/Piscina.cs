using UnityEngine;

public class Piscina : MonoBehaviour
{
    public GameObject prefab;
    public int cantidad = 3;
    public int instanciados = 1;
    public float tiempo = 15;
    public int layer;

    private void Start()
    {
        llenar_piscina();
        InvokeRepeating("sacar_de_piscina", tiempo, instanciados);
    }

    private void llenar_piscina()
    {
        for (int i = 1; i <= cantidad; i++)
        {
            añadir_a_piscina();
        }
    }

    private void añadir_a_piscina()
    {
        GameObject objeto = Instantiate(prefab, this.transform.position, Quaternion.identity, this.transform);
        objeto.SetActive(false);
    }

    private GameObject sacar_de_piscina()
    {
        GameObject objeto = null;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).gameObject.activeSelf)
            {
                objeto = transform.GetChild(i).gameObject;
                break;
            }
        }

        if (objeto == null)
        {
            añadir_a_piscina();
            objeto = transform.GetChild(transform.childCount - 1).gameObject;
        }

        objeto.transform.position = this.transform.position;
        objeto.SetActive(true);
        objeto.GetComponentInChildren<SpriteRenderer>().sortingOrder = layer;
        return objeto;
    }

}
