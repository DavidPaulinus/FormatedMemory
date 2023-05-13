using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField, Range(0f, 50f)] private float moveSp = 10f;
    [SerializeField, Range(0f, 50f)] private float moveAirSp = 8f;
    [SerializeField] private InputController input;
    [SerializeField] private LayerMask layer;

    private Ground ground;
    private Rigidbody2D body;

    private float x;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();

    }

    private void Update()
    {
        x = input.retriveMoving();
    }

    void FixedUpdate()
    {
        var _velocity = ground.Grounded(GetComponent<BoxCollider2D>(), layer) ? moveSp : moveAirSp;

        body.velocity = new Vector2(x * _velocity , body.velocity.y);

    }
}
