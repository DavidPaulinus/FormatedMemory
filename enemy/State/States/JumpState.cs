using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    [SerializeField] private bool pularAtePlayer;
    [SerializeField] private Transform player;
    [SerializeField, Range(0f, 13f)] private float alturaPulo;
    [SerializeField] private LayerMask layer;
    [SerializeField] private State nextState;

    private Ground ground;
    private Rigidbody2D body;
    private bool jumped;
    private float distanciaPlayer;

    private void Awake()
    {
        body = GetComponentInParent<Rigidbody2D>();
        ground = GetComponentInParent<Ground>();

        jumped = false;
    }

    private void FixedUpdate()
    {
        Pulo();
    }

    public override State RunCurrentState()
    {   
         if (jumped) return nextState;

        return this;
    }

    private void Pulo()
    {
        if (pularAtePlayer) distanciaPlayer = player.position.x - transform.position.x;
        else distanciaPlayer = 0;

        if (ground.Grounded(GetComponent<BoxCollider2D>(), layer))
        {
            body.AddForce(new Vector2(distanciaPlayer, alturaPulo), ForceMode2D.Impulse);
            jumped = true;
        }
    }
}
