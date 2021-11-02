using UnityEngine;
using TMPro;

public class ContadorPuntaje : MonoBehaviour
{
   public TMP_Text texto;

   private void Awake(){
       texto = GetComponent<TextMeshProUGUI>();
   }

    public void configurar_texto(int puntaje)
    {
        texto.text = puntaje.ToString();
    }

    public void configurar_texto_inicial()
    {
        texto.text = "0";
    }
}
