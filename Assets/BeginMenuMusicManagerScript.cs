using UnityEngine;
using System.Collections;

public class BeginMenuMusicManagerScript : MonoBehaviour {

	public GameObject prefabMusic;

	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find ("MusicMenu(Clone)");
		if (obj == null) {
			Instantiate(prefabMusic);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
