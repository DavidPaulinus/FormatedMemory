using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    [SerializeField] private float walkSp;
    [SerializeField] private float distanceWall;
    private Transform parentTransform;

    private void Awake()
    {
        parentTransform = transform.parent.transform;
    }

    public override State RunCurrentState()
    {

        parentTransform.position += new Vector3(walkSp, 0) *Time.deltaTime;

        if (Physics2D.Linecast(parentTransform.position, new Vector3(distanceWall, transform.position.y, 0)))
        {
            
        }

        return this;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(distanceWall, transform.position.y, 0));
    }

}
