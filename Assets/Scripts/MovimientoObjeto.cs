using UnityEngine;

public class MovimientoObjeto : MonoBehaviour
{
    public float velocidad = 12000;
    private Rigidbody2D objeto;
    public Vector2 dirección;

    void Start()
    {
        objeto = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        objeto.velocity = dirección * velocidad * Time.deltaTime * Controlador.factor();
    }
}
