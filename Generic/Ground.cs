using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool Grounded(BoxCollider2D collider,LayerMask layer)
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0, Vector2.down, .1f, layer);
    }

    public bool Grounded(CircleCollider2D collider, LayerMask layer)
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0, Vector2.down, .1f, layer);
    }

    public bool Grounded(PolygonCollider2D collider, LayerMask layer)
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0, Vector2.down, .1f, layer);
    }

    public bool Grounded(CapsuleCollider2D collider, LayerMask layer)
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0, Vector2.down, .1f, layer);
    }
}
