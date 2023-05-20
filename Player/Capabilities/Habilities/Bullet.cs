using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet config")]
    [SerializeField] private Transform player;
    [SerializeField] private SpriteRenderer spr;

    [Header("Bullet data")]
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        body.velocity = (spr.flipX ? -transform.right : transform.right) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damageable"))
        {
            Damageable dm = collision.gameObject.GetComponent<Status>();
            dm.doDamage(damage);

        }

        if (collision.gameObject.CompareTag("Ground")) Destroy(gameObject);

    }

}
