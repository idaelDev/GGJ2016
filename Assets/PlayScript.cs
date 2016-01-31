using UnityEngine;
using System.Collections;

public class PlayScript : MonoBehaviour {

	public UnityEngine.UI.Button button1;
	public UnityEngine.UI.Button button2;
	bool clicked = false;
	AudioSource audio;
	public float m_step;
	public int m_levelNumber;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (clicked) {

		}
	}

	IEnumerator Play(){
		GameObject obj = GameObject.Find ("MusicMenu(Clone)");
		Destroy (obj);
		while ( audio.isPlaying) {
		
			yield return 0;
		}

		Application.LoadLevel (m_levelNumber);
	}

	public void OnClick(){
		button1.interactable = false;
		button2.interactable = false;
		audio.Play();
		clicked = true;
	}
}
