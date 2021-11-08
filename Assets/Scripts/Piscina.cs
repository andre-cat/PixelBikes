using UnityEngine;

public class Piscina : MonoBehaviour
{
    public GameObject prefab;
    public int brecha_instancia = 10;
    public int cantidad = 2;
    public GameObject punto_1;
    public GameObject punto_3;
    public GameObject punto_5;
    public GameObject punto_7;

    private void Start()
    {
        llenar_piscina();
        InvokeRepeating("sacar_de_piscina", 2f, brecha_instancia);
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
        if (CargadorNivel.over == true)
        {
            CancelInvoke();
        }
        
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

        Transform punto = punto_1.transform;
        int layer = 0;

        int aleatorio = Random.Range(1, 5);
        switch (aleatorio)
        {
            case 1:
                punto = punto_1.transform;
                layer = 1;
                break;
            case 2:
                punto = punto_3.transform;
                layer = 3;
                break;
            case 3:
                punto = punto_5.transform;
                layer = 5;
                break;
            case 4:
                punto = punto_7.transform;
                layer = 7;
                break;
        }

        objeto.transform.position = punto.position;
        objeto.GetComponent<SpriteRenderer>().sortingOrder = layer;
        objeto.SetActive(true);
        return objeto;
    }
}
