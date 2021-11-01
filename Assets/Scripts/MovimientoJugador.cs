using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    private float velocidad = 100;
    private Rigidbody2D cuerpo;

    private void Start()
    {
        cuerpo = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        arriba();
        abajo();
    }

    private void arriba()
    {
        if (Input.GetKey("up"))
        {
            float y = velocidad * Time.deltaTime * Controlador.factor();
            cuerpo.AddForce(new Vector2(0, y), ForceMode2D.Impulse);
        }
    }

    private void abajo()
    {
        if (Input.GetKey("down"))
        {
            float y = velocidad * Time.deltaTime * Controlador.factor();
            cuerpo.AddForce(new Vector2(0, -y), ForceMode2D.Impulse);
        }
    }
}
