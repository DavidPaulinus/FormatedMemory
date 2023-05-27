using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private float forca = 25f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var _body = collision.gameObject.GetComponent<Rigidbody2D>();

            _body.AddForce(Vector2.up * forca, ForceMode2D.Impulse);
        }
    }
}
