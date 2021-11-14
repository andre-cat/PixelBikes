using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class CargadorEscena : MonoBehaviour
{
    public void cargar_escena(Image imagen, string escena, float opacidad_final, float suma_opacidad_por_frame)
    {
        StartCoroutine(transparente_a_opaco(imagen, escena, opacidad_final, suma_opacidad_por_frame));
    }

    public IEnumerator transparente_a_opaco(Image imagen, string escena, float opacidad_final, float suma_opacidad)
    {
        for (float alfa = 0; alfa <= opacidad_final; alfa += suma_opacidad)
        {
            imagen.color = new Color(0, 0, 0, alfa);
            yield return null;
        }
        SceneManager.LoadScene(escena);
    }

    public IEnumerator opaco_a_transparente(Image imagen, float resta_opacidad)
    {
        for (float alfa = 1; alfa >= 0; alfa -= resta_opacidad)
        {
            imagen.color = new Color(0, 0, 0, alfa);
            yield return null;
        }
    }
}
