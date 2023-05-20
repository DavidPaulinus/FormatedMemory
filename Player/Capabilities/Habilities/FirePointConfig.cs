using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointConfig : MonoBehaviour
{
    private SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponentInParent<SpriteRenderer>();
    }

    void Update()
    {
        var _rotate = spr.flipX ? -0.752 : 0.752;
        transform.localPosition = new Vector2((float)_rotate, 0);
    }
}
