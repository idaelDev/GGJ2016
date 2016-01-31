using UnityEngine;
using System.Collections;

public class BubbleManagerScript : MonoBehaviour {

	public GameObject endHUD;
	public AudioSource SourceAudio;
	public UnityEngine.UI.Text textMessageEnd;
	public string textMessageHUDP1Win;
	public string textMessageHUDP2Win;

	public GameObject PrefabMusic;
	public float speedFade;


	//Win Message
	private int winPlayer = 0;
	public GameObject messageWinP1;
	public UnityEngine.UI.Text textMessageP1;
	public string messageP1;
	public AudioClip AudioWinP1;
	public GameObject messageWinP2;
	public UnityEngine.UI.Text textMessageP2;
	public string messageP2;
	public AudioClip AudioWinP2;
	public float TimeMessage;
	private bool Once = false;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (winPlayer) {
		case 0:

			break;
		case 1:
			if(!Once){
				StartCoroutine("WinMessage1");
			}
			Once = true;
			break;
		case 2:
			if(!Once){
				StartCoroutine("WinMessage2");
			}
			Once = true;
			break;
		default:

			break;

		}
	}

	public void setWinPlayer ( int player){
		winPlayer = player;
	}

	IEnumerator WinMessage1(){
		Debug.Log ("messagewin1");
		StartCoroutine ("FadeOut",Camera.main.GetComponent<AudioSource> ());
		textMessageP1.text = messageP1;
		messageWinP1.SetActive (true);
		SourceAudio.clip = AudioWinP1;
		SourceAudio.Play ();
		yield return new WaitForSeconds(TimeMessage);
		messageWinP1.SetActive (false);
		textMessageEnd.text = textMessageHUDP1Win;
		GameObject.Instantiate (PrefabMusic);
		endHUD.SetActive (true);
	}

	IEnumerator WinMessage2(){
		Debug.Log ("messagewin2");
		StartCoroutine ("FadeOut",Camera.main.GetComponent<AudioSource> ());
		textMessageP2.text = messageP2;
		messageWinP2.SetActive (true);
		SourceAudio.clip = AudioWinP2;
		SourceAudio.Play();
		yield return new WaitForSeconds(TimeMessage);
		messageWinP2.SetActive (false);
		textMessageEnd.text = textMessageHUDP2Win;
		GameObject.Instantiate (PrefabMusic);
		endHUD.SetActive (true);
	}

	IEnumerator FadeOut(AudioSource audio){
		float vol = audio.volume;
		vol -= Time.deltaTime * speedFade;
		while (vol > 0) {
			audio.volume = vol;
			yield return 0;
			vol -= Time.deltaTime * speedFade;
		}
	}
}
