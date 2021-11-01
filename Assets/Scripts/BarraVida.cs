using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Slider deslizador;

    public void ConfigurarEnergía(int vida){
        deslizador.value = vida;
    }

    public void ConfigurarEnergíaInicial(){
        deslizador.maxValue = 100;
        deslizador.value = 100;
    }
}
