using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Player : MonoBehaviour
{
    public Route currentRoute;
    public CardAnimation CardContainer;
    public HUD hud;
    public CardDisplay carddisplay;
    public CardDisplay carddisplay2;
    public ChooseCard choose;
    int routePosition;
    bool isMoving;
    private float hy;
    private int passi;
    private int PrePos;
    private int[] dati;
    private Tipo1[] arraytemp;
    private float rotation;
    public bool NothingBool;
    public bool fine;
    public int idPlayer;

    public void Start()
    {
        hy = transform.position.y;
        passi = 0;
        NothingBool = false;
        //isMoving = false;
        dati = new int[] { 0, 0, 0, 0 , idPlayer};
        fine = false;
    }

    public void tiratoDado(int steps)
    {
        if (!isMoving && !fine)
        {
            StartCoroutine(Move(steps));
        }
    }
    IEnumerator Move(int steps)
    {
        passi = 0;
        if(isMoving)
        {
            yield break;
        }
        isMoving = true;
        Quaternion rotA = transform.rotation;
        while (steps>0)
        {   
            routePosition++;
           //routePosition %= currentRoute.childNodeList.Count;
            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
            nextPos.y+=0.1f;
            rotation = currentRoute.childNodeList[(routePosition)].localRotation.eulerAngles.y; 

            while (MoveToNextNode(nextPos))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rotation, 0), 1.5f);  //fix 1f, per rotazione
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            steps--;
            //passiMancanti.text = steps.ToString();
            passi++;
            if (routePosition >= currentRoute.childNodeList.Count-1)
            {
                fine = true;
                yield return null;
            }
        }
        isMoving = false;
        string stringa = currentRoute.childNodeList[routePosition].tag;
        if (stringa.CompareTo("Nothing") == 0)
            NothingBool = true;
        else
            NothingBool = false;

        if (!NothingBool) 
        {
            if (stringa.CompareTo("scelta") == 0)
            {
                arraytemp = choose.prelevaCarte("GoodLuck");
                Tipo1[] arraytemp2 = choose.prelevaCarte("BadLuck");
                arraytemp = arraytemp.Concat(arraytemp2).ToArray();
            }
            else
            {
                arraytemp = choose.prelevaCarte(stringa);

            }
            carddisplay.aggiornaGrafica(arraytemp[0]);
            carddisplay2.aggiornaGrafica(arraytemp[1]);
            StartCoroutine(CardContainer.sposta(transform.position));    //sposta solo se scelta, e anche rimetti da muovere solo se scelta.
            passaCarteAlGestore();
        }
        else if(NothingBool)
        {
            arraytemp = null;
            passaCarteAlGestore();
        }
    }

    public bool Nothing()
    {
        return NothingBool;
    }

    public bool MovingBool()
    {
        return isMoving;
    }

    public Tipo1[] passaCarteAlGestore()
    {
        return arraytemp;
    }

    public void rimetti()
    {
        StartCoroutine(CardContainer.rimetti(transform.position));
        if(!CardContainer.enabled)
            CardContainer.enabled = true;
    }
    bool MoveToNextNode(Vector3 goal)
    {
        transform.position = Vector3.MoveTowards(transform.position, goal, 5f * Time.deltaTime);
        return goal != transform.position;
    }

    public int[] getPoint()
    {
        return dati;
    }

    public void aggiornaGrafica(int[] dati)
    {
        if(hud!=null)
          hud.aggiornaGrafica(dati);
    }
}
