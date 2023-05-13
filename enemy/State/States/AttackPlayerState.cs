using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerState : State
{
    private float maxDistance;
    [SerializeField] private ChaseState chase;

    private Transform trans;
    private CheckPlayerDistance checkDistance;

    void Start()
    {
        trans = GetComponent<Transform>();
        checkDistance = GetComponentInParent<CheckPlayerDistance>();
        maxDistance = chase.getMaxDistance();
    }

    public override State RunCurrentState()
    {
        if (!checkDistance.CheckDistance(trans, maxDistance))
        {
            return chase;
        }
        return this;
    }

}
