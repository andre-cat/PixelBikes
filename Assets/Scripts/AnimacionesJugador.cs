using UnityEngine;
using UnityEngine.UI;

public class AnimacionesJugador : MonoBehaviour
{

    public BarraVida barra_vida;
    public ContadorPuntaje contador_puntaje;

    private Animator animador;
    private Animator animador_enemigo;

    private Image fondo;
    private float tiempo_inicial;

    void Awake()
    {
        barra_vida = GameObject.FindWithTag("Vida").GetComponent<BarraVida>();
        contador_puntaje = GameObject.FindWithTag("Puntaje").GetComponent<ContadorPuntaje>();

        animador = GetComponent<Animator>();
        animador_enemigo = GameObject.FindWithTag("Enemigo").GetComponent<Animator>();
    }

    private void Start()
    {
        PlayerPrefs.GetInt("vida", 100);
        PlayerPrefs.GetInt("limones", 0);
        barra_vida.configurar_vida_inicial();
        contador_puntaje.configurar_texto_inicial();
    }

    void Update()
    {
        animaciones_arriba_abajo();
        barra_vida.configurar_vida(PlayerPrefs.GetInt("vida"));
        contador_puntaje.configurar_texto(PlayerPrefs.GetInt("limones"));
    }

    private void animaciones_arriba_abajo()
    {
        animador.SetBool("Subir", Input.GetKey("up"));
        animador.SetBool("Bajar", Input.GetKey("down"));
    }

    private void daño(int valor_daño)
    {
        int vida = PlayerPrefs.GetInt("vida");
        vida -= valor_daño;
        PlayerPrefs.SetInt("vida", vida);
    }

    private void OnTriggerEnter2D(Collider2D colisión)
    {
        switch (colisión.tag)
        {
            case "Limón":
                int limones = PlayerPrefs.GetInt("limones");
                limones++;
                PlayerPrefs.SetInt("limones", limones);
                break;
            case "Destructible-Ofensivo":
                if (colisión.name == "Barril")
                {
                    animador.SetTrigger("Resbalar");
                    animador_enemigo.SetTrigger("Risa");
                    daño(20);
                }
                else
                {
                    animador.SetTrigger("Contacto");
                    daño(5);
                }
                break;
            case "Indestructible-Ofensivo":
                animador.SetTrigger("Resbalar");
                animador_enemigo.SetTrigger("Risa");
                daño(10);
                break;
            case "Rampa":
                animador.SetTrigger("Saltar");
                break;
        }
    }
}
