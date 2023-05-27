using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private float launchSp;
    [SerializeField] private float distanciaPlayer;

    [SerializeField] private float distanciaParede;
    [SerializeField] private LayerMask layerParede;

    [SerializeField] private string facingDirection;

    private bool attack;
    private Rigidbody2D body;
    private CheckPlayerDistance check;
    private Vector3 baseScale;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        check = GetComponent<CheckPlayerDistance>();
        baseScale = transform.localScale;
    }

    void Update()
    {
        var _lSp = launchSp;
        if (facingDirection == "left") _lSp = -_lSp;

        if (check.CheckDistance(transform, distanciaPlayer)) attack = true;

        if (attack) body.velocity = new Vector2(_lSp, body.velocity.y);

        if (hittingWall())
        {
            attack = false;
            StartCoroutine(waitToRecharge());
            ChangeDirection(facingDirection);
        }
    }

    private bool hittingWall()
    {
        var _castDist = distanciaParede;
        if (facingDirection == "left")
        {
            _castDist = -_castDist;
        }

        //determine the target destination based on the cast distance
        Vector3 _targetPos = transform.position;
        _targetPos.x += _castDist;

        return Physics2D.Linecast(transform.position, _targetPos, layerParede);
    }

    private void ChangeDirection(string facing)
    {
        var _newScale = baseScale;
        var _facing = facing == "left";

        _newScale.x = _facing ? baseScale.x : -baseScale.x;

        transform.localScale = _newScale;
        facingDirection = _facing ? "right" : "left";
    }

    private IEnumerator waitToRecharge()
    {
        //animation

        yield return new WaitForSeconds(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Status st = collision.gameObject.GetComponent<Status>();
            st.doDamage(1, 2, 3, true);
        }
    }
}
