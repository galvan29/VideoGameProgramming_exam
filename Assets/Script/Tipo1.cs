using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName ="Card")]
public class Tipo1 : ScriptableObject
{
    public new string name;
    public string description;
    public int dollari;
    public int sociale;
    public int ambientale;
    public int economico;
    public string tipologia;
}
