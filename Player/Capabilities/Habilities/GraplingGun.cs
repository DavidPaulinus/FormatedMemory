using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraplingGun : MonoBehaviour
{
    [SerializeField] private Transform grapplePoint;
   
    [SerializeField] private float grappleshootSpeed;
    [SerializeField] private float velocidadeMov;

    private Rigidbody2D body;

    private bool canGrap;

    public void canUseGrappling(bool can)
    {
        canGrap = can;
    }
}
