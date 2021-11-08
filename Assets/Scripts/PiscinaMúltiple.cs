using UnityEngine;

public class PiscinaMúltiple : MonoBehaviour
{
    public ContenedorObjetos contenedor;

    public int cantidad = 2;
    public static int iniciar_en = 4;
    public int instanciar_cada = 2;
    public GameObject punto_2;
    public GameObject punto_4;
    public GameObject punto_6;

    private bool[] números;

    private void Start()
    {
        llenar_piscina();
        InvokeRepeating("sacar_de_piscina", iniciar_en, instanciar_cada);
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
        for (int i = 0; i < contenedor.número; i++)
        {
            GameObject obstáculo = Instantiate(contenedor.objeto(i), this.transform.position, Quaternion.identity, this.transform);
            obstáculo.SetActive(false);
        }
    }

    private void añadir_a_piscina(int índice)
    {

        GameObject obstáculo = Instantiate(contenedor.objeto(índice), this.transform.position, Quaternion.identity, this.transform);
        obstáculo.SetActive(false);
    }

    private GameObject sacar_de_piscina()
    {
        if (CargadorNivel.over == true)
        {
            CancelInvoke();
        }

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

        Transform punto = punto_2.transform;
        int layer = 0;

        aleatorio = Random.Range(1, 4);
        switch (aleatorio)
        {
            case 1:
                punto = punto_2.transform;
                layer = 2;
                break;
            case 2:
                punto = punto_4.transform;
                layer = 4;
                break;
            case 3:
                punto = punto_6.transform;
                layer = 6;
                break;
        }

        obstáculo.transform.position = punto.position;
        obstáculo.GetComponentInChildren<SpriteRenderer>().sortingOrder = layer;

        obstáculo.SetActive(true);
        return obstáculo;
    }
}
