using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    private readonly int jump = Animator.StringToHash("Jump");
    private readonly int fall = Animator.StringToHash("Fall");

    [Header("Config Pulo")]
    [SerializeField, Range(0f, 20f)] private float jumpHeight;
    [SerializeField, Range(0f, 20f)] private float timeToNextJump;

    [Header("Jump data config")]
    [SerializeField] private Collider2D coll;
    [SerializeField] private LayerMask layer;

    private Animator ani;
    private Ground ground;
    private Rigidbody2D body;

    private int state;
    private bool jumping;
    private float counter;

    private void Awake()
    {
        ground = GetComponent<Ground>();

        body = GetComponent<Rigidbody2D>();
        counter = timeToNextJump;

        ani = GetComponent<Animator>();
    }

    //animação
    private void Update()
    {
        if (body.velocity.y > .1f) state  = jump;
        if (body.velocity.y < -.1f) state = fall;

        ani.CrossFade(state, 0, 0);
    }

    //pulo
    void FixedUpdate()
    {
        if (counter <= 0)
        {
            counter = timeToNextJump;
            jumping = false;
        }
        counter -= Time.deltaTime;

        if (ground.Grounded(coll, layer) && !jumping)
        {
            body.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            jumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Status st = collision.gameObject.GetComponent<Status>();
            st.doDamage(1, 2, 3, true);
        }
    }
}
