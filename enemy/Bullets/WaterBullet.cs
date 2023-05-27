using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    private readonly int up = Animator.StringToHash("Up");
    private readonly int down = Animator.StringToHash("Down");

    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    [SerializeField] private float damage;

    private Rigidbody2D body;
    private Animator ani;

    private int state;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        var _positionX = player.position.x - transform.position.x;

        body.AddForce(new Vector2(_positionX, speed), ForceMode2D.Impulse);
    }
    
    private void FixedUpdate()
    {
        if (body.velocity.y > .1f) state = up;
        else state = down;

        ani.CrossFade(state, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Status st = collision.gameObject.GetComponent<Status>();
            st.doDamage(1, 2, 3, true);
        }

        Destroy(gameObject);
    }
}
