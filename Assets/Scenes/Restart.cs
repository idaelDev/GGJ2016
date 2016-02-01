using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public void OnClick()
    {
        Application.LoadLevel("Main");
    }
}
