using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour {
	
	public GameObject startPanel;
	public GameObject creditsPanel;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnClick(){
		Camera.main.GetComponent<AudioSource> ().Play ();
		creditsPanel.SetActive (false);
		startPanel.SetActive (true);
	}
}
