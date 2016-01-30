using UnityEngine;
using System.Collections;

public class HUDBarScript : MonoBehaviour {
	RectTransform rectTrans;
	public float m_0To1Value;
	// Use this for initialization
	void Start () {
		rectTrans = GetComponent <RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_0To1Value > 0 && m_0To1Value <= 1) {
			rectTrans.localScale = new Vector3 ( m_0To1Value,1,1);
		} else if (m_0To1Value <= 0) {
			rectTrans.localScale = new Vector3 (0,1,1);;
		}else
		{
			rectTrans.localScale = new Vector3 (1,1,1);
		}
	}

	void set0To1Value(float val){
		m_0To1Value = val;
	}
		
}
