using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Slider deslizador;

    private void Awake(){
       deslizador = GetComponent<Slider>();
   }

    public void configurar_vida(int vida){
        deslizador.value = vida;
    }

    public void configurar_vida_inicial(){
        deslizador.maxValue = 100;
        deslizador.value = 100;
    }
}
