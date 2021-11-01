using UnityEngine;
using TMPro;

public class ContadorPuntaje : MonoBehaviour
{

   public TMP_Text texto;

    public void ConfigurarTexto(int puntaje)
    {
        texto.text = puntaje.ToString();
    }

    public void ConfigurarTextoInicial()
    {
        texto.text = "0";
    }
}
