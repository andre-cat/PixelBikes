using UnityEngine;

public class MovimientoObjeto : MonoBehaviour
{
    private float velocidad = 7000;
    private Rigidbody2D objeto;

    private void Start()
    {
        objeto = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 dirección = new Vector2(-1,0);
        objeto.velocity = dirección * velocidad * Time.deltaTime * Controlador.factor();
    }
}
