using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public Text nome;
    public Text dollars;
    public Text social;
    public Text ambient;
    public Text economic;
    public RawImage profilo;
    public Texture NewTexture1;
    public Texture NewTexture2;

    private void Start()
    {
        nome.text = "Iron Man";
        profilo.texture = (Texture)NewTexture1;
        dollars.text = "0";
        social.text = "0";
        ambient.text = "0";
        economic.text = "0";
    }
    public void aggiornaGrafica(int[] dati)
    {
        dollars.text = dati[0].ToString();
        social.text = dati[1].ToString();
        ambient.text = dati[2].ToString();
        economic.text = dati[3].ToString();
        if (dati[4] == 1)
        {
            profilo.texture = (Texture)NewTexture1;
            nome.text = "Iron Man";
        }
            
        else
        {
            profilo.texture = (Texture)NewTexture2;
            nome.text = "Batman";
        }


    }
}
