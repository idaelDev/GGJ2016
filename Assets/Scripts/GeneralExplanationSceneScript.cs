using UnityEngine;
using System.Collections;

public class GeneralExplanationSceneScript : MonoBehaviour {

	public int m_levelNumber;
	public float m_step;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine ("WaitAndGo");
	}

	public void Ending(){

	}

	IEnumerator WaitAndGo(){
		GameObject obj = GameObject.Find ("MusicMenu(Clone)");
		AudioSource audio = obj.GetComponent<AudioSource> ();
		float i = audio.volume;
		while (i > 0) {
			i -= Time.deltaTime * m_step;
			audio.volume = i;
			yield return 0;
		}
		Destroy (obj);
		Application.LoadLevel (m_levelNumber);
	}
}
