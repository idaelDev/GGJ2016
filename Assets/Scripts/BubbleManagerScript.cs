using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BubbleManagerScript : MonoBehaviour {

	public GameObject endHUD;
	public AudioSource SourceAudio;
	public UnityEngine.UI.Text textMessageEnd;
	public string textMessageHUDP1Win;
	public string textMessageHUDP2Win;

	public GameObject PrefabMusic;
	public float speedFade;
    
  
    public Sprite MonkeyImage;
    public Sprite CraneImage;
    public Image winnerImage;

	//Win Message
	private int winPlayer = 0;
	public string messageP1;
	public AudioClip AudioWinP1;
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
        winnerImage.sprite = CraneImage;
		Debug.Log ("messagewin1");
		StartCoroutine ("FadeOut",Camera.main.GetComponent<AudioSource> ());
		SourceAudio.clip = AudioWinP1;
		SourceAudio.Play ();
		//yield return new WaitForSeconds(TimeMessage);
		textMessageEnd.text = textMessageHUDP1Win;
		GameObject.Instantiate (PrefabMusic);
		endHUD.SetActive (true);
        yield return 0;
	}

	IEnumerator WinMessage2(){
        winnerImage.sprite = MonkeyImage;
		Debug.Log ("messagewin2");
		StartCoroutine ("FadeOut",Camera.main.GetComponent<AudioSource> ());
		SourceAudio.clip = AudioWinP2;
		SourceAudio.Play();
		//yield return new WaitForSeconds(TimeMessage);
		textMessageEnd.text = textMessageHUDP2Win;
		GameObject.Instantiate (PrefabMusic);
		endHUD.SetActive (true);
        yield return 0;
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
