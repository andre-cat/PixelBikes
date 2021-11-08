using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Tienda : MonoBehaviour
{
    public Slider barra_burbuja, barra_corazón;

    public TMP_Text texto_limones, texto_burbujas, texto_corazones;
    public TMP_Text texto_precio_burbujas, texto_precio_corazones;
    public TMP_Text mensaje;

    private int precio_burbujas, precio_corazones;
    private int máximo_burbuja, máximo_corazones;
    private int burbujas, corazones, limones;

    private void Start()
    {
        máximo_burbuja = 30;
        máximo_corazones = 30;
        precio_burbujas = 10;
        precio_corazones = 5;

        predeterminado();
    }

    private void predeterminado()
    {
        limones = PlayerPrefs.GetInt("limones",0);
        corazones = PlayerPrefs.GetInt("corazones", 0);
        burbujas = PlayerPrefs.GetInt("burbujas", 0);

        texto_limones.text = limones + "$";
        texto_burbujas.text = burbujas.ToString();
        texto_corazones.text = corazones.ToString();

        texto_precio_burbujas.text = precio_burbujas.ToString() + "$";
        texto_precio_corazones.text = precio_corazones.ToString() + "$";

        barra_burbuja.maxValue = máximo_burbuja;
        barra_burbuja.value = burbujas;

        barra_corazón.maxValue = máximo_corazones;
        barra_corazón.value = corazones;

        mensaje.text = "Holi. :D";
    }

    public void comprar_corazón()
    {
        if (corazones < máximo_corazones)
        {
            if (limones > precio_corazones)
            {
                limones -= precio_corazones;
                PlayerPrefs.SetInt("limones", limones);
                texto_limones.text = limones + "$";

                corazones += 1;
                PlayerPrefs.SetInt("corazones", corazones);

                texto_corazones.text = corazones.ToString();
                barra_corazón.value = corazones;
                mensaje.text = "¡Compra exitosa!";
                StartCoroutine(esperar(mensaje, "<3"));
            }
            else
            {
                mensaje.text = "No hay suficientes limones.";
                StartCoroutine(esperar(mensaje, "u-u"));
            }
        }
        else
        {
            mensaje.text = "Tope de corazones.";
            StartCoroutine(esperar(mensaje, ":("));
        }
    }

    public void comprar_burbuja()
    {
        if (burbujas < máximo_burbuja)
        {
            if (limones > precio_burbujas)
            {
                limones -= precio_burbujas;
                PlayerPrefs.SetInt("limones", limones);
                texto_limones.text = limones + "$";

                burbujas += 1;
                PlayerPrefs.SetInt("armour", burbujas);

                texto_burbujas.text = burbujas.ToString();
                barra_burbuja.value = burbujas;
                mensaje.text = "¡Compra exitosa!";
                StartCoroutine(esperar(mensaje, ":)"));
            }
            else
            {
                mensaje.text = "No hay suficientes limones.";
                StartCoroutine(esperar(mensaje, "._."));
            }
        }
        else
        {
            mensaje.text = "Tope de burbujas.";
            StartCoroutine(esperar(mensaje, ":|"));
        }
    }

    private IEnumerator esperar(TMP_Text mensaje, string texto)
    {
        yield return new WaitForSeconds(2);
        mensaje.text = texto;
    }
}