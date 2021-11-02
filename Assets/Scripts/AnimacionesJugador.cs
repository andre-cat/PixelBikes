using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimacionesJugador : MonoBehaviour
{

    public BarraVida vida;
    public ContadorPuntaje puntaje;

    private Animator animador;
    private Animator animador_enemigo;

    private Image fondo;
    private float tiempo_inicial;
    private bool una_vez = false;

    void Awake()
    {
        vida = GameObject.FindWithTag("Vida").GetComponent<BarraVida>();
        puntaje = GameObject.FindWithTag("Puntaje").GetComponent<ContadorPuntaje>();

        animador = GetComponent<Animator>();
        animador_enemigo = GameObject.FindWithTag("Enemigo").GetComponent<Animator>();
    }

    private void Start()
    {
        vida.configurar_vida_inicial();
        puntaje.configurar_texto_inicial();
    }

    void Update()
    {
        animaciones_arriba_abajo();
        vida.configurar_vida(Controlador.vida);
        puntaje.configurar_texto(Controlador.limon);
        if (Controlador.vida <= 0)
        {
        }
    }

    private void animaciones_arriba_abajo()
    {
        animador.SetBool("Arriba", Input.GetKey("up"));
        animador.SetBool("Abajo", Input.GetKey("down"));
    }

    private void daño(int valor_daño)
    {
        Controlador.vida = Controlador.vida - valor_daño;
    }

    private void OnTriggerEnter2D(Collider2D colisión)
    {
        switch (colisión.tag)
        {
            case "Limón":
                Controlador.limon++;
                break;
            case "Destructible-Ofensivo":
                if (colisión.name != "Barril")
                {
                    animador.SetTrigger("Resbalar");
                    animador_enemigo.SetTrigger("Choque");
                    daño(20);
                }
                else
                {
                    animador.Play("Contacto");
                    daño(5);
                }
                break;
            case "Indestructible-Ofensivo":
                animador.SetTrigger("Resbalar");
                animador_enemigo.SetTrigger("Choque");
                daño(10);
                break;
            case "Rampa":
                animador.SetTrigger("Saltar");
                break;
        }
    }
}
