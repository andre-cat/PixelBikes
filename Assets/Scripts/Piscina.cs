using UnityEngine;

public class Piscina : MonoBehaviour
{
    public ContenedorObstáculo contenedor;

    public int cantidad = 1;
    public int instanciados = 1;
    public float tiempo = 5;
    public GameObject punto_1;
    public GameObject punto_2;
    public GameObject punto_3;

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
        for (int i = 0; i < contenedor.número_obstáculos; i++)
        {
            GameObject obstáculo = Instantiate(contenedor.obtener_obstáculo(i), this.transform.position, Quaternion.identity, this.transform);
            obstáculo.SetActive(false);
        }
    }

    private GameObject sacar_de_piscina()
    {
        int aleatorio = Random.Range(1, contenedor.número_obstáculos);

        GameObject obstáculo = null;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).gameObject.activeSelf)
            {
                obstáculo = transform.GetChild(i).gameObject;
            }
        }

        if (obstáculo == null)
        {
            añadir_a_piscina();
            obstáculo = transform.GetChild(transform.childCount).gameObject;
        }

        GameObject punto = null;
        int layer = 0;

        int caso = Random.Range(1, 4);

        switch (caso)
        {
            case 1:
                punto = punto_1;
                layer = 2;
                break;
            case 2:
                punto = punto_2;
                layer = 4;
                break;
            case 3:
                punto = punto_3;
                layer = 6;
                break;
        }

        obstáculo.transform.position = punto.transform.position;
        obstáculo.SetActive(true);
        obstáculo.GetComponentInChildren<SpriteRenderer>().sortingOrder = layer;
        return obstáculo;
    }

}
