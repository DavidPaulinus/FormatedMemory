using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private InputController input;
    private Animator ani;
    private SpriteRenderer spr;
    private Rigidbody2D body;

    private static readonly int idle = Animator.StringToHash("Idle");
    private static readonly int run = Animator.StringToHash("Run");
    private static readonly int jump = Animator.StringToHash("Jump");
    private static readonly int fall = Animator.StringToHash("Fall");

    private static readonly int idleShoot = Animator.StringToHash("IdleShoot");
    private static readonly int runShoot = Animator.StringToHash("RunShoot");
    private static readonly int jumpShoot = Animator.StringToHash("JumpShoot");
    private static readonly int fallShoot = Animator.StringToHash("FallShoot");

    private int state;

    private void Start()
    {
        Animator.StringToHash("Idle");

        ani = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var _moving = input.retriveMoving();

        if (_moving != 0)
        {
            if (Input.GetKey(KeyCode.D)) state = runShoot;
            else state = run;

            spr.flipX = _moving < 0;
        }
        else if (Input.GetKey(KeyCode.D)) state = idleShoot;
        else state = idle;

        if (body.velocity.y > .1f)
        {
            if (Input.GetKey(KeyCode.D)) state = jumpShoot;
            else state = jump;
        }
        if (body.velocity.y < -.1f)
        {
            if (Input.GetKey(KeyCode.D)) state = fallShoot;
            else state = fall;
        }

        ani.CrossFade(state, 0, 0);
    }

}
