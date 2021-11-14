using UnityEngine;

public class Pausar : MonoBehaviour
{
    private GameObject panel_pausa;
    private bool pausa = false;

    void Awake(){
        panel_pausa = gameObject.transform.Find("PanelPausa").gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pausa == true)
            {
                continuar();
            }
            else
            {
                pausar();
            }
        }
    }

    private void continuar()
    {
        panel_pausa.SetActive(false);
        Time.timeScale = 1f;
        pausa = false;
    }

    private void pausar()
    {
        panel_pausa.SetActive(true);
        Time.timeScale = 0f;
        pausa = true;
    }
}
