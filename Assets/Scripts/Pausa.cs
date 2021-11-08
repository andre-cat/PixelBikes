using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject menú_pausa;
    public static bool pausa = false;

    void Awake(){
        menú_pausa = GameObject.FindWithTag("Pausa");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pausa == true)
            {
                no_pausar();
            }
            else
            {
                pausar();
            }
        }
    }

    private void no_pausar()
    {
        menú_pausa.SetActive(false);
        Time.timeScale = 1f;
        pausa = false;
    }

    private void pausar()
    {
        menú_pausa.SetActive(true);
        Time.timeScale = 0f;
        pausa = true;
    }
}
