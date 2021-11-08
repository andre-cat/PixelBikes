using UnityEngine;

public class AnimaciónRoca : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D colisión)
    {
        if (colisión.gameObject.tag == "Enemigo")
        {
            colisión.gameObject.GetComponent<Animator>().SetTrigger("Explotar");
        }
    }
}