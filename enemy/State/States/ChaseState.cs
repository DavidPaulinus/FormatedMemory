using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{

    [SerializeField] private float maxDistanceAttack;
    [SerializeField] private AttackPlayerState attack;
    [SerializeField] private IdleState idle;

    private Transform trans;
    private CheckPlayerDistance checkDistance;

    private void Start()
    {
        trans = GetComponent<Transform>();
        checkDistance = GetComponentInParent<CheckPlayerDistance>();
    }

    public override State RunCurrentState()
    {
        //chase code


        if (checkDistance.CheckDistance(trans, maxDistanceAttack)) return attack;
        else if (!checkDistance.CheckDistance(trans, idle.getMaxDistance())) return idle;
        
        return this;
    }

    public float getMaxDistance()
    {
        return maxDistanceAttack;
    }
}
