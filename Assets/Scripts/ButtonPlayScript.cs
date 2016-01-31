using UnityEngine;
using System.Collections;

public class ButtonPlayScript : MonoBehaviour {

	public int m_levelNumber;
	public AudioSource m_audio;
	bool clicked = false;
	public UnityEngine.UI.Button button;
	public UnityEngine.UI.Button creditsButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (clicked && !m_audio.isPlaying) 
		{
			Application.LoadLevel (m_levelNumber);
		}
	}

	public void OnClick(){
		m_audio.Play ();
		button.interactable = false;
		creditsButton.interactable = false;
		clicked = true;

	}
}
