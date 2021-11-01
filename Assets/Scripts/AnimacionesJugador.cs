using UnityEngine;

public class AnimacionesJugador : MonoBehaviour
{

    public static int nivel = 1;

    public static int energía = 100;
    public BarraVida barra;

    public static int limón = 0;
    public ContadorPuntaje puntaje;



    private Animator animador;

    private void Start()
    {
        barra.ConfigurarEnergíaInicial();
        puntaje.ConfigurarTextoInicial();
    }

    void Awake()
    {
        animador = GetComponent<Animator>();
    }

    void Update()
    {
        animaciones_arriba_abajo();
        barra.ConfigurarEnergía(energía);
        puntaje.ConfigurarTexto(limón);
    }

    private void animaciones_arriba_abajo()
    {
        animador.SetBool("Arriba", Input.GetKey("up"));
        animador.SetBool("Abajo", Input.GetKey("down"));
    }

    private void daño(int valor_daño)
    {
        energía = energía - valor_daño;
    }

    private void OnTriggerEnter2D(Collider2D colisión)
    {
        switch (colisión.tag)
        {
            case "Limón":
                limón++;
                break;
            case "Destructible-Ofensivo":
                if (colisión.name != "Barril")
                { daño(20); }
                else { daño(5); }
                animador.SetTrigger("Resbalar");
                break;
            case "Indestructible-Ofensivo":
                //Controlador.vida = Controlador.vida - 30;
                daño(10);
                animador.SetTrigger("Resbalar");
                break;
            case "Rampa":
                animador.SetTrigger("Saltar");
                break;
        }
    }
}
