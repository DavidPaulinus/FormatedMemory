using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{

    [SerializeField] private float maxDistanceAttack;
    [SerializeField] private float chaseSpeed = 1;
    [SerializeField] private AttackPlayerState attack;
    [SerializeField] private IdleState idle;
    [SerializeField] private Transform playerPosition;

    private Transform trans;
    private Transform parentTransform;
    private CheckPlayerDistance checkDistance;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        checkDistance = GetComponentInParent<CheckPlayerDistance>();
        parentTransform = transform.parent.transform.parent.transform;
    }

    public override State RunCurrentState()
    {
        //chase code
        if (parentTransform.position.x > playerPosition.position.x)
        {
            parentTransform.rotation = new Quaternion(0, 180, 0, 0);
            parentTransform.position -= new Vector3(chaseSpeed, 0, 0) * Time.deltaTime;
        }
        else
        {
            parentTransform.rotation = new Quaternion(0, 0, 0, 0);
            parentTransform.position += new Vector3(chaseSpeed, 0, 0) * Time.deltaTime;
        }

        //state
        if (checkDistance.CheckDistance(trans, maxDistanceAttack)) return attack;
        else if (!checkDistance.CheckDistance(trans, idle.getMaxDistance())) return idle;
        
        return this;
    }

    public float getMaxDistance()
    {
        return maxDistanceAttack;
    }
}
