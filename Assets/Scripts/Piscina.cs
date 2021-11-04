using UnityEngine;

public class Piscina : MonoBehaviour
{
    public ContenedorObstáculo contenedor;

    public int cantidad = 1;
    public int instanciar = 2;
    public float tiempo_inicial = 5;
    public int layer = 0;
    private bool[] números;

    private void Start()
    {
        llenar_piscina();
        InvokeRepeating("sacar_de_piscina", tiempo_inicial, instanciar);
    }

    private void llenar_piscina()
    {
        for (int i = 1; i <= cantidad; i++)
        {
            añadir_a_piscina_primera_vez();
        }
    }

    private void añadir_a_piscina_primera_vez()
    {
        for (int i = 0; i < contenedor.número_obstáculos; i++)
        {
            GameObject obstáculo = Instantiate(contenedor.obtener_obstáculo(i), this.transform.position, Quaternion.identity, this.transform);
            obstáculo.SetActive(false);
        }
    }

    private void añadir_a_piscina(int índice)
    {
        GameObject obstáculo = Instantiate(contenedor.obtener_obstáculo(índice), this.transform.position, Quaternion.identity, this.transform);
        obstáculo.SetActive(false);
    }

    private GameObject sacar_de_piscina()
    {
        GameObject obstáculo = null;

        números = new bool[this.transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            números[i] = false;
        }

        int aleatorio = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            do
            {
                aleatorio = Random.Range(0, números.Length - 1);
            } while (números[aleatorio] == true);

            if (!transform.GetChild(aleatorio).gameObject.activeSelf)
            {
                obstáculo = transform.GetChild(aleatorio).gameObject;
                break;
            }
            else
            {
                números[aleatorio] = true;
            }
        }

        if (obstáculo == null)
        {
            añadir_a_piscina(aleatorio);
            obstáculo = transform.GetChild(transform.childCount - 1).gameObject;
        }
        obstáculo.transform.position = this.transform.position;
        obstáculo.SetActive(true);
        if (layer != 0)
        {
            obstáculo.GetComponentInChildren<SpriteRenderer>().sortingOrder = layer;
        }
        return obstáculo;
    }
}
