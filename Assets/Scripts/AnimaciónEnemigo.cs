using UnityEngine;

public class AnimaciónEnemigo : MonoBehaviour
{

	public GameObject punto;
    public GameObject roca;
    private Animator animador;
    private float x_jugador;

    private void Awake()
    {
        animador = GetComponent<Animator>();
    }

    private void update()
    {
        animador.SetFloat("x", transform.position.x);

		/*if ()
		{
            GameObject roca_gigante = Instantiate(roca, punto.transform.position, Quaternion.identity);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D colisión)
    {
        if (colisión.gameObject.tag == "Roca")
        {
            animador.SetTrigger("Explotar");
        }
    }
}
