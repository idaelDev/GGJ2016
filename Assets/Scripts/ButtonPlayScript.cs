using UnityEngine;
using System.Collections;

public class ButtonPlayScript : MonoBehaviour {

	public int m_levelNumber;
	public AudioSource m_audio;
	bool clicked = false;
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
		clicked = true;

	}
}
