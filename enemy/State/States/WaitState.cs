using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : State
{
    [SerializeField] private State nextState;
    [SerializeField] private float time;

    private float counter;

    private void Awake()
    {
        counter = time;
    }
    public override State RunCurrentState()
    {
        if (counter <= 0) return nextState;

        counter -= Time.deltaTime;

        return this;
    }

}
