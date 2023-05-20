using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : Damageable
{
    [SerializeField] private float hp = 2;

    private void Update()
    {
        destroyObject();
    }

    public override void doDamage(float damage)
    {
        hp -= damage;
    }

    public void destroyObject()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
