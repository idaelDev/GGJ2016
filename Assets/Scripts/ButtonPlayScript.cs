using UnityEngine;
using System.Collections;

public class ButtonPlayScript : MonoBehaviour {
	
	public AudioSource m_audio;
	bool clicked = false;
	public UnityEngine.UI.Button button;
	public UnityEngine.UI.Button creditsButton;

	public GameObject NextPanel;
	public GameObject OldPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnClick(){
		m_audio.Play ();
		button.interactable = false;
		creditsButton.interactable = false;
		NextPanel.SetActive (true);
		OldPanel.SetActive (false);
		clicked = true;

	}
}
