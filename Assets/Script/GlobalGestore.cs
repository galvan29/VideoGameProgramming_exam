using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Cinemachine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GlobalGestore : MonoBehaviour
{
	public GameObject Gbutton;
	public GameObject ChangeTurnoOver;
	public Button playGame;
	public Button changeTurno;
	public Player player;
	public Player player2;
	public Text roll;
	public RawImage rollContenit;
	private bool scelta;
	private int[] dati;
	private bool turno;
	private Button btn;
	private Button btn2;
	public CinemachineVirtualCamera vcam;
	public ChooseCard choose;
	Player playerbro;
	public AudioSource music;
	public Dashboard dash;
    public Canvas hud;
	public VideoPlayer vid;
	public VideoClip[] myclip;
	public GameObject videoDeiDadi;

	void Start()
	{
		player.Start();
		dati = player.getPoint();
		btn = playGame.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		scelta = false;
		turno = true;
		playerbro = player;
		ChangeTurnoOver.SetActive(false);
		player.aggiornaGrafica(dati);
	}

	Player playerTemp;
	void TaskOnClick()
	{
		if (turno)
			playerTemp = player;
		else
			playerTemp = player2;

		dati = playerTemp.getPoint();
		playerTemp.aggiornaGrafica(dati);
		int numero = UnityEngine.Random.Range(2, 13);
		
		Gbutton.SetActive(false);

		vid.clip = myclip[numero - 2];
		StartCoroutine(waiter(numero));
		rollContenit.enabled = true;
		scelta = false;		
	}

	IEnumerator waiter(int numero)
	{
		while (vid.isPlaying)
		{
			yield return null;
		}
		playerTemp.tiratoDado(numero);
		vid.clip = null;
		//StartCoroutine(waiter2());
	}

	/*IEnumerator waiter2()
	{
		yield return new WaitForSeconds(2);
		vid.enabled = false;
	}*/

	void Update()
	{
		if(playerbro.fine)
        {
			int[] punteggio;
			punteggio = player.getPoint();
			punteggio = punteggio.Concat(player2.getPoint()).ToArray();
			player.fine = true;
			player2.fine = true;
			hud.enabled = false;
			dash.FineGioco(punteggio);
        }
        else
        {
			if (!scelta && !playerbro.MovingBool())
			{
				if (!playerbro.Nothing())
				{
					if (Input.GetMouseButtonDown(0))
					{
						RaycastHit raycastHit;
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						if (Physics.Raycast(ray, out raycastHit, 100f))
						{
							if (raycastHit.transform != null)
							{
								if (raycastHit.transform.gameObject.tag == "choice1" || raycastHit.transform.gameObject.tag == "choice2")
									CurrentClickedGameObject(raycastHit.transform.gameObject);			
							}
						}
					}
				}
				else if (playerbro.Nothing())
				{
					scelta = true;
					dati = playerbro.getPoint();
					ciao();
					cambia();
				}
			}
        }

		
	}

	void cambia()
    {
		if (turno)
			playerbro = player;
		else
			playerbro = player2;
	}

	public void MainMenuFunction()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void CurrentClickedGameObject(GameObject gameObject)
	{
		scelta = true;
		int i = gameObject.tag == "choice1" ? 0 : 1;
		dati = playerbro.getPoint();
		if (playerbro.passaCarteAlGestore() != null)
		{
			Tipo1[] arrayCarte = playerbro.passaCarteAlGestore();
			dati[0] += arrayCarte[i].dollari;
			dati[1] += arrayCarte[i].sociale;
			dati[2] += arrayCarte[i].ambientale;
			dati[3] += arrayCarte[i].economico;
			dati[4] = (playerbro==player ? 1 : 0);
			playerbro.rimetti();
			ciao();
		}
		cambia();
	}

	public void ciao()
	{
		playerbro.aggiornaGrafica(dati);
		ChangeTurnoOver.SetActive(true);
		turno = !turno;
		btn2 = changeTurno.GetComponent<Button>();
		btn2.onClick.AddListener(cambiaTurno);
	}
	private void cambiaTurno()
    {
		ChangeTurnoOver.SetActive(false);
		if (turno)
			playerTemp = player;
		else
			playerTemp = player2;
		dati = playerbro.getPoint();
		playerbro.aggiornaGrafica(dati);
		//cambiare velocità per la transazione
		vcam.LookAt = playerTemp.transform;
		vcam.Follow = playerTemp.transform;
		Gbutton.SetActive(true);
		player.NothingBool = false;
		player2.NothingBool = false;
	}
}