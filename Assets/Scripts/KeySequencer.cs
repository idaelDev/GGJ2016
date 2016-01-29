using UnityEngine;
using System.Collections;

public class KeySequencer : MonoBehaviour {

    public string name;
    public KeyCode[] sequence;

    private int waitedKeyIndex = 0;

    public delegate void SequenceValid();
    public event SequenceValid SequenceValidEvent;

    void Update()
    {
        if(Input.GetKeyDown(sequence[waitedKeyIndex]))
        {
            if(waitedKeyIndex == sequence.Length-1)
            {
                SequenceValidEvent();
                waitedKeyIndex = 0;
            }
            else
            {
                waitedKeyIndex++;
            }
        }
        else if(Input.anyKeyDown)
        {
            waitedKeyIndex = 0;
        }
    }
}
