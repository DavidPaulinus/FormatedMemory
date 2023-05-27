using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageState : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Status st = collision.gameObject.GetComponent<Status>();
            st.doDamage(1, 2, 3, true);
        }
    }
}
