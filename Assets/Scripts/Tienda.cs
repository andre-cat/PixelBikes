using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tienda : MonoBehaviour
{
    public Slider barra_burbuja, barra_corazón;

    private int máximo_burbuja, máximo_corazones;
    private int burbujas, corazones, limones;

    public TMP_Text texto_limones;
    public TMP_Text texto_burbujas;
    public TMP_Text texto_corazones;

    private void Start()
    {
        máximo_burbuja = 30;
        máximo_corazones = 30;

        predeterminado();
    }

    private void predeterminado()
    {
        limones = PlayerPrefs.GetInt("limones", 0);

        corazones = PlayerPrefs.GetInt("corazones", 0);
        burbujas = PlayerPrefs.GetInt("burbujas", 0);

        texto_limones.text = limones + "$";

        barra_corazón.maxValue = máximo_corazones;
        barra_burbuja.maxValue = máximo_burbuja;

        barra_corazón.value = corazones;
        barra_burbuja.value = burbujas;
    }

    public void comprar_corazones(int precio_limones)
    {
        if (corazones < máximo_corazones)
        {
            if (limones > precio_limones)
            {
                limones -= precio_limones;
                texto_limones.text = this.limones + "$";

                corazones += 1;
                PlayerPrefs.SetInt("corazones", corazones);

                texto_corazones.text = corazones.ToString();
                barra_corazón.value = corazones;
                Debug.Log("¡Compra exitosa!");
            }
            else
            {
                Debug.Log("No hay suficientes limones.");
            }
        }
        else
        {
            Debug.Log("Tope de corazones.");
        }
    }

    public void comprar_burbuja(int precio_limones)
    {
        if (burbujas < máximo_burbuja)
        {
            if (limones > precio_limones)
            {
                limones -= precio_limones;
                texto_limones.text = limones + "$";

                burbujas += 1;
                PlayerPrefs.SetInt("armour", burbujas);

                texto_burbujas.text = burbujas.ToString();
                barra_burbuja.value = burbujas;
                Debug.Log("¡Compra exitosa!");
            }
            else
            {
                Debug.Log("No hay suficientes limones.");
            }
        }
        else
        {
            Debug.Log("Tope de burbujas.");
        }
    }
}