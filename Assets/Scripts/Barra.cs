using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{
    public enum TipoBarra
    {
        Vida,
        Progreso,
    }

    private Slider deslizador;
    private float instante_inicial;
    public TipoBarra tipo_barra;

    void Awake()
    {
        deslizador = GetComponent<Slider>();
    }

    void Start()
    {
        if (tipo_barra == TipoBarra.Vida)
        {
            deslizador.maxValue = 100;
            deslizador.value = PlayerPrefs.GetInt("vida");
        }
        else
        {
            deslizador.maxValue = PlayerPrefs.GetFloat("tiempo");
            deslizador.value = 0;
            instante_inicial = Time.time;
        }
    }

    void Update()
    {
        if (tipo_barra == TipoBarra.Vida)
        {
            deslizador.value = PlayerPrefs.GetInt("vida");
            if (CargadorNivel.over == false & deslizador.value <= 0)
            {
                GameObject.FindWithTag("Player").GetComponent<Animator>().SetTrigger("Morir");
                CargadorNivel.over = true;
            }
        }
        else
        {
            deslizador.value = Time.time - instante_inicial;

            if (deslizador.value >= deslizador.maxValue * 0.5)
            {
                MovimientoEnemigo.mitad = true;

                if (deslizador.value >= deslizador.maxValue * 0.75)
                {
                    MovimientoEnemigo.final = true;

                    if (CargadorNivel.over == false & deslizador.value >= deslizador.maxValue)
                    {
                        GameObject.FindWithTag("Enemigo").GetComponent<Animator>().SetTrigger("Despedida");
                        CargadorNivel.over = true;
                    }
                }
            }
        }
    }
}