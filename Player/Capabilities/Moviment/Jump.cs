using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputController input;
    [SerializeField] private LayerMask layer;

    [Header("NORMAL JUMP")]
    [SerializeField, Range(0f, 20f)] private float jumpSp = 4f;
    [SerializeField, Range(0f, 20f)] private float upwardValueMultiplier = 1.7f;
    [SerializeField, Range(0f, 20f)] private float downwardValueMultiplier = 4f;

    [Header("BONUS FEATURES")]
    [SerializeField, Range(0f, 0.4f)] private float coyteTimer = .2f;
    [SerializeField, Range(0f, 0.4f)] private float jumpBufferTimer = .2f;
    [SerializeField, Range(0f, 10f)] private int maxAirJump = 0;


    private Ground ground;
    private Rigidbody2D body;
    private Vector2 velocity;

    private float defaultValueMultiplier = 1f;
    private float coytoCounter;
    private float jumpPhase;
    private float jumpBufferCounter;

    private bool desireToJump;
    private bool isJumping;


    private void Awake()
    {
        ground = GetComponent<Ground>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        desireToJump |= input.retriveJUmp();
    }

    void FixedUpdate()
    {
        velocity = body.velocity;
        var _onGround = ground.Grounded(GetComponent<BoxCollider2D>(), layer);

        //coyote
        if (_onGround && velocity.y == 0)
        {
            coytoCounter = coyteTimer;
            jumpPhase = 0;
            isJumping = false;
        }
        else
        {
            coytoCounter -= Time.deltaTime;
        }

        //jump buffer
        if (desireToJump)
        {
            desireToJump = false;
            jumpBufferCounter = jumpBufferTimer;
        }
        else if(!desireToJump && jumpBufferCounter > 0)
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0)
        {
            JumpAction();
        }

        //hold jump
        if (input.retriveHoldingJump() && body.velocity.y > .1f) body.gravityScale = upwardValueMultiplier;
        else if (!input.retriveHoldingJump() || body.velocity.y < .1f) body.gravityScale = downwardValueMultiplier;
        else if (body.velocity.y == 0) body.gravityScale = defaultValueMultiplier;

        body.velocity = velocity;
    }

    private void JumpAction()
    {

        if (coytoCounter > 0 || (jumpPhase < maxAirJump && isJumping))
        {
            if (isJumping)
            {
                jumpPhase++;
            }
            coytoCounter = 0;
            jumpPhase = 0;
            isJumping = true;

            velocity.y += jumpSp;
        }
    }
}
