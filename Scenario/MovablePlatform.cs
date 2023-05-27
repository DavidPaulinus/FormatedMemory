using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private float movSp;
    [SerializeField] private bool startOnTheRight;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x >= end.position.x)
        {
            print("AAAAAAAAAAAAAA");
            movSp = -movSp;
        }
        transform.position += new Vector3(-3,0,0);
    }
    
}
