using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool Grounded(Collider2D collider, LayerMask layer)
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0, Vector2.down, .1f, layer);
    }
}
