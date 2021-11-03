using UnityEngine;

public class Desactivar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisión)
    {
        colisión.gameObject.SetActive(false);
    }
}
