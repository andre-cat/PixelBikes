using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class CargadorNivel : CargadorEscena
{
    private Image imagen;
    private float suma_de_alfa = 0.03f;

    void Awake()
    {
        imagen = GetComponent<Image>();
    }

    void Start()
    {
        StartCoroutine(opaco_a_transparente(imagen, suma_de_alfa));

        StartCoroutine(esperar("NIVEL_" + PlayerPrefs.GetInt("nivel"), 1, suma_de_alfa));
    }

    IEnumerator esperar(string nombre, float opacidad, float suma)
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(transparente_a_opaco(imagen, nombre, opacidad, suma));
    }
}
