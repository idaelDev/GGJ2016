using UnityEngine;
using System.Collections;

public class ChangePanelScript : MonoBehaviour {


	public GameObject NewPanel;
	public GameObject OldPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		Camera.main.GetComponent<AudioSource> ().Play ();
		OldPanel.SetActive (false);
		NewPanel.SetActive (true);
	}
}
