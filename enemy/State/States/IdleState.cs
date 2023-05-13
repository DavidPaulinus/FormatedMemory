using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] private float maxDistanceChase;
    [SerializeField] private ChaseState chase;

    private Transform trans;
    private CheckPlayerDistance checkDistance;

    private void Start()
    {
        trans = GetComponent<Transform>();
        checkDistance = GetComponentInParent<CheckPlayerDistance>();
    }

    public override State RunCurrentState()
    {
        if (checkDistance.CheckDistance(trans, maxDistanceChase))
        {
            return chase;
        }
        return this;
    }

    public float getMaxDistance()
    {
        return maxDistanceChase;
    }

}
