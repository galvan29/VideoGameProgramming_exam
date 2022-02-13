using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    private Tipo1 cart;
    public RawImage cartaSuUnity;
    public Text description;
    public Texture tipo1;
    public Texture tipo2;
    public Texture tipo3;

    public void aggiornaGrafica(Tipo1 carta)
    {
        cart = carta;
        description.text = cart.description;
        if(cart.tipologia.Contains("BadLuck"))
            cartaSuUnity.texture = (Texture)tipo1;
        else if(cart.tipologia.Contains("GoodLuck"))
            cartaSuUnity.texture = (Texture)tipo3;
        else
            cartaSuUnity.texture = (Texture)tipo2;

    }
}
