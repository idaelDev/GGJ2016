using UnityEngine;
using System.Collections;

public class GeneralExplanationSceneScript : MonoBehaviour {

	public int m_secondsToWait;
	public int m_levelNumber;
	public float m_step;

	// Use this for initialization
	void Start () {
		StartCoroutine ("WaitAndGo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator WaitAndGo(){
		yield return new WaitForSeconds(m_secondsToWait);
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
