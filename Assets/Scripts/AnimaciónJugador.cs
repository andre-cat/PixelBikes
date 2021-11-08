using UnityEngine;

public class AnimaciónJugador : MonoBehaviour
{
    private Animator jugador;
    private Animator enemigo;

    void Awake()
    {
        jugador = GetComponent<Animator>();
        enemigo = GameObject.FindWithTag("Enemigo").GetComponent<Animator>();
        Texto.limones = PlayerPrefs.GetInt("limones", 0);
    }

    void Update()
    {
        arriba_abajo();
    }

    private void arriba_abajo()
    {
        jugador.SetBool("Subir", Input.GetKey("up"));
        jugador.SetBool("Bajar", Input.GetKey("down"));
    }

    private void daño(int valor_daño)
    {
        PlayerPrefs.SetInt("vida", PlayerPrefs.GetInt("vida") - valor_daño);
    }

    void OnTriggerEnter2D(Collider2D colisión)
    {
        switch (colisión.tag)
        {
            case "Limón":
                colisión.GetComponent<Animator>().SetTrigger("Choque");
                Texto.limones++;
                break;
            case "Destructible-Ofensivo":
                if (colisión.name == "Barril")
                {
                    jugador.SetTrigger("Resbalar");
                    enemigo.SetTrigger("Risa");
                    daño(30);
                }
                else
                {
                    jugador.SetTrigger("Contacto");
                    daño(10);
                }
                break;
            case "Indestructible-Ofensivo":
                jugador.SetTrigger("Resbalar");
                enemigo.SetTrigger("Risa");
                daño(20);
                break;
            case "Rampa":
                jugador.SetTrigger("Saltar");
                break;
        }
    }
}
