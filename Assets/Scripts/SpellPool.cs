using UnityEngine;
using System.Collections;


public class SpellPool : ObjectPool {

    public KeySequencer sequencer;
    public bool moveRight;

    protected void Start()
    {
        base.Start();
        sequencer.SequenceValidEvent += LaunchSpell;
    }

    void LaunchSpell()
    {
        Spell s = GetObject() as Spell;
        s.moveright = moveRight;
    }

}
