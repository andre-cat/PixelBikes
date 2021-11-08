using UnityEngine;

[CreateAssetMenu(fileName = "Chris",menuName = "Personaje")]
public class Personaje : ScriptableObject
{
    public string nombre;
    public Sprite avatar;
    public Color fondo;
    public Color título;
    public GameObject transición;
    public GameObject muerte;
}