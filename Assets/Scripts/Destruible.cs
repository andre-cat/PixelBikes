using UnityEngine;

public class Destruible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisión)
    {   
        if (colisión.gameObject.tag == "Player")
        {
            Animator animador = GetComponent<Animator>();
                animador.SetTrigger("Choque");
        }
    }
}
