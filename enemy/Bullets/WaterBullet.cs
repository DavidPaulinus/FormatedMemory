using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private Rigidbody2D body;

    private float direction;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (transform.position.x > player.position.x) direction = -1;
        else direction = 1;

        var _moveSpeed = speed * Time.deltaTime * direction;
        body.AddForce(new Vector2(player.position.x, _moveSpeed), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
