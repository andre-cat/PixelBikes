using UnityEngine;

public class AnimaciónRoca : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D colisión)
    {
        if (colisión.gameObject.tag == "Enemigo")
        {
            Debug.Log("Holi");
            colisión.gameObject.GetComponent<Animator>().SetTrigger("Explotar");
        }
    }
}