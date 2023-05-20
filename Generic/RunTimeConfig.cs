using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTimeConfig : MonoBehaviour
{
    private SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!Application.isPlaying) spr.enabled = true;
        else spr.enabled = false;
    }
}
