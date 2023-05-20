using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : State
{
    [SerializeField] private State nextState;
    [SerializeField] private float time;

    public override State RunCurrentState()
    {
        if (time <= 0) return nextState;

        time -= Time.deltaTime;

        return this;
    }

}
