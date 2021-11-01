using UnityEngine;

public class AnimacionesJugador : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator animador;

    // Update is called once per frame

    void Awake()
    {
        animador = GetComponent<Animator>();
    }

    void Update()
    {
        animaciones_arriba_abajo();
    }

    private void animaciones_arriba_abajo()
    {
        animador.SetBool("Arriba", Input.GetKey("up"));
        animador.SetBool("Abajo", Input.GetKey("down"));
    }

    private void OnTriggerEnter2D(Collider2D colisión)
    {
        switch (colisión.tag)
        {
            case "Destructible-Ofensivo":
                Controlador.vida = Controlador.vida - 10;
                animador.SetTrigger("Resbalar");
                break;
            case "Indestructible-Ofensivo":
                Controlador.vida = Controlador.vida - 30;
                animador.SetTrigger("Resbalar");
                break;
            case "Rampa":
                animador.SetTrigger("Saltar");
                break;
        }
    }


}
