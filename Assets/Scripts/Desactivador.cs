using UnityEngine;

public class Desactivador : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D colisión)
	{
		if (colisión.tag != "Enemigo")
		{
		colisión.gameObject.SetActive(false);
		}
	}
}
