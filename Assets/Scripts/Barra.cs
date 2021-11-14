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
            if (Controlador.over == false & deslizador.value <= 0)
            {
                PlayerPrefs.SetFloat("dificultad", 0);
                GameObject.FindWithTag("Player").GetComponent<Animator>().SetTrigger("Morir");
                GameObject.FindWithTag("Player").transform.Find("Polvo").gameObject.SetActive(false);
                GameObject.FindWithTag("Player").transform.Find("Bicicleta").gameObject.SetActive(true);
                Controlador.over = true;
            }
        }
        else
        {
            deslizador.value = Time.time - instante_inicial;

            if (deslizador.value >= deslizador.maxValue * 0.5)
            {
                MovimientoEnemigo.mitad = true;

                if (deslizador.value >= deslizador.maxValue * 0.85)
                {
                    MovimientoEnemigo.final = true;

                    if (Controlador.over == false & deslizador.value >= deslizador.maxValue)
                    {
                        GameObject.FindWithTag("Enemigo").GetComponent<Animator>().SetTrigger("Despedida");
                        Controlador.over = true;
                    }
                }
            }
        }
    }
}