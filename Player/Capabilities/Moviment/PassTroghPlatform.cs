using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassTroghPlatform : MonoBehaviour
{
    [SerializeField] private float disableTimer;
    [SerializeField] private LayerMask layer;
    [SerializeField] private InputController input;

    private EdgeCollider2D edge;
    private BoxCollider2D box;
    private Ground ground;

    private float down;
    private float disableCounter = 0;

    private void Awake()
    {
        ground = GetComponent<Ground>();
        box = GetComponent<BoxCollider2D>();
        edge = GetComponent<EdgeCollider2D>();

    }

    void Update()
    {
        down = input.retriveHoldingDown();

        if (disableCounter > 0)
        {
            disableCounter -= Time.deltaTime;
        }
        if (disableCounter <= 0)
        {
            box.enabled = true;
            edge.enabled = true;
        }
        if (ground.Grounded(box, layer) && down == -1 && disableCounter <= 0)
        {
            box.enabled = false;
            edge.enabled = false;

            disableCounter = disableTimer;
        }
    }
}
