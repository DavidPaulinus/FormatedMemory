using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : Damageable
{
    [SerializeField] private float hp = 2;

    private Rigidbody2D body;
    private SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        destroyObject();
    }

    public override void doDamage(float damage, float IframeTime, float numeroDeFlashes, bool darIframes)
    {
        hp -= damage;
        StartCoroutine(Iframes(IframeTime, numeroDeFlashes, darIframes));
    }

    public void destroyObject()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Iframes(float IframesTime, float numeroDeFlashes, bool darIframes)
    {
        //arrumar. Ir pra tras com dano (player)
        if (darIframes)
        {
            body = GetComponent<Rigidbody2D>();

            body.AddForce(new Vector2(-3, body.velocity.y), ForceMode2D.Impulse);
        }

        Physics2D.IgnoreLayerCollision(9, 10, darIframes);
        for (int i = 0; i < numeroDeFlashes; i++)
        {
            spr.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(IframesTime / (numeroDeFlashes * 2));
            spr.color = Color.white;
            yield return new WaitForSeconds(IframesTime / (numeroDeFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }
}
