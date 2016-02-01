using UnityEngine;
using System.Collections;

public class KeySequencer : MonoBehaviour {

    public string name;
    public KeyCode[] sequence;

    private int waitedKeyIndex = 0;

    public delegate void SequenceValid();
    public event SequenceValid SequenceValidEvent;
    public bool iskonami;

    void Update()
    {
        if (Ball.gameBegin || iskonami)
        {
            if (Input.GetKeyDown(sequence[waitedKeyIndex]))
            {
                if (waitedKeyIndex == sequence.Length - 1)
                {
                    SequenceValidEvent();
                    waitedKeyIndex = 0;
                }
                else
                {
                    waitedKeyIndex++;
                }
            }
            else 
            {
                for (int i = 0; i < sequence.Length; i++)
                {
                    if (Input.GetKeyDown(sequence[i]))
                    {
                        waitedKeyIndex = 0;
                    }
                }
  
            }
        }
    }
}
