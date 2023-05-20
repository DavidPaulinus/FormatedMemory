using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : State
{
    [SerializeField] private GameObject waterShoot;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject player;
    [SerializeField] private State nextState;
    public override State RunCurrentState()
    {
        Instantiate(waterShoot, firePoint.position, firePoint.rotation);

        return nextState;
    }

}
