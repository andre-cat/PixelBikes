using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class CargadorMenú : CargadorEscena
{
    private Image imagen;
    private float resta_opacidad = 0.05f; // Resta de opacidad por frame
    private float suma_opacidad = 0.9f; // Suma de opacidad por frame
    private float opacidad_final = 0.8f;

    void Awake()
    {
        imagen = GetComponent<Image>();
    }

    void Start()
    {
        StartCoroutine(opaco_a_transparente(imagen, resta_opacidad));
    }

    public void jugar()
    {
        cargar_escena(imagen, "TRANS", opacidad_final, suma_opacidad);
    }

    public void avatar()
    {
        cargar_escena(imagen, "AVATAR", opacidad_final, suma_opacidad);
    }

    public void tienda()
    {
        cargar_escena(imagen, "TIENDA", opacidad_final, suma_opacidad);
    }

    public void opciones()
    {
        cargar_escena(imagen, "OPCIONES", opacidad_final, suma_opacidad);
    }

    public void volver()
    {
        cargar_escena(imagen, "MENU", opacidad_final, suma_opacidad);
    }

    public void salir()
    {
        Debug.Log("¡SALIR!");
        StartCoroutine(salir(imagen, suma_opacidad));
    }

    IEnumerator salir(Image image, float suma)
    {
        for (float alfa = 0; alfa <= 1; alfa += suma)
        {
            imagen.color = new Color(0, 0, 0, alfa);
            yield return null;
        }
        Application.Quit();
    }
}
