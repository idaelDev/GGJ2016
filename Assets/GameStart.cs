using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        GameObject obj = GameObject.Find("MusicMenu(Clone)");
        Destroy(obj);
        Application.LoadLevel("Main");
    }
}
