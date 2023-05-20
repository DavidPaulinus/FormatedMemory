using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private InputController input;
    private Animator ani;
    private SpriteRenderer spr;
    private Rigidbody2D body;

    private enum MovementState {idle, run, jump, fall };
    private MovementState state;

    private void Start()
    {
        ani = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var _moving = input.retriveMoving();

        if (_moving != 0)
        {
            state = MovementState.run;
            spr.flipX = _moving < 0;
        }
        else state = MovementState.idle;

        if (body.velocity.y > .1f) state = MovementState.jump;
        if (body.velocity.y < -.1f) state = MovementState.fall;


        ani.SetInteger("State", (int)state);
    }
}
