using UnityEngine.UI;

public class CargadorMaster : CargadorEscena
{
    private Image imagen;
    public float opacidad_final = 1f;
    public float suma_opacidad = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        imagen = GetComponent<Image>();
    }

    public void volver(){
        StartCoroutine(transparente_a_opaco(imagen, "MENU", opacidad_final, suma_opacidad));
    }
}
