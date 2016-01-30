using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float initialSpeed = 1f;

    private ElementsNames elements;
    private float speed;
    private bool goRight = true;

    public bool GoRight
    {
        get { return goRight; }
        set { goRight = value; }
    }

   
}
