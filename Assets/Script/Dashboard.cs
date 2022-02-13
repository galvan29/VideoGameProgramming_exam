
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Dashboard : MonoBehaviour
{
    public Text Player1Name;
    public Text Player2Name;
    public Text Soc1;
    public Text Soc2;
    public Text Amb1;
    public Text Amb2;
    public Text Econ1;
    public Text Econ2;
    public Text Tot1;
    public Text Tot2;
    public CinemachineVirtualCamera vcam;
    public RawImage medaglia;
    public RawImage medaglia2;

    private void Start()
    {
        medaglia.enabled = false;
        medaglia2.enabled = false;
    }

    public void FineGioco(int[] punteggi)
    {
        int val = punteggi[0]/500;
        int val2 = punteggi[5]/500;
        int soc1 = punteggi[1];
        int soc2 = punteggi[6];
        int amb1 = punteggi[2];
        int amb2 = punteggi[7];
        int eco1 = (punteggi[3]+val);
        int eco2 = (punteggi[8]+val2);

        Soc1.text = soc1.ToString();
        Soc2.text = soc2.ToString();
        Amb1.text = amb1.ToString();
        Amb2.text = amb2.ToString();
        Econ1.text = eco1.ToString();
        Econ2.text = eco2.ToString();
        Tot1.text=(soc1+amb1+eco1).ToString();
        Tot2.text= (soc2 + amb2 + eco2).ToString();
        if ((soc1 + amb1 + eco1) > (soc2 + amb2 + eco2))
            medaglia2.enabled = true;
        else
            medaglia.enabled = true;
        vcam.LookAt = transform;
        vcam.Follow = transform;
        //change distance dell'offset via riga
    }
}
