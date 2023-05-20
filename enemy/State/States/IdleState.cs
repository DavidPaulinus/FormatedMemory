using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] private float maxDistanceToNextState;
    [SerializeField] private State nextState;

    private Transform trans;
    private CheckPlayerDistance checkDistance;

    private void Start()
    {
        trans = GetComponent<Transform>();
        checkDistance = GetComponentInParent<CheckPlayerDistance>();
    }

    public override State RunCurrentState()
    {
        if (checkDistance.CheckDistance(trans, maxDistanceToNextState)) return nextState;

        return this;
    }

    public float getMaxDistance()
    {
        return maxDistanceToNextState;
    }

}
