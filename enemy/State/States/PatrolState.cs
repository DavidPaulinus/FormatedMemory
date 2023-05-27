using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    private const string LEFT = "left";
    private const string RIGHT = "right";

    [Header("Data config")]
    [SerializeField] private float baseCastDistance;
    [SerializeField] private LayerMask layer;

    [Header("Walking config")]
    [SerializeField] private float walkSp;
    [SerializeField] private string facingDirection;

    [Header("Next State config")]
    [SerializeField] private bool haveNextState;
    [SerializeField] private State nextState;
    [SerializeField] private float maxDistance;

    private CheckPlayerDistance check;
    private Transform parentTransform;
    private Rigidbody2D body;
    private Vector3 baseScale;

    private void Awake()
    {
        parentTransform = transform.parent.transform;
        body = GetComponentInParent<Rigidbody2D>();
        baseScale = parentTransform.localScale;

        check = GetComponentInParent<CheckPlayerDistance>();
    }

    public override State RunCurrentState()
    {
        var _vSp = facingDirection == LEFT? -walkSp : walkSp;

        body.velocity = new Vector2(_vSp, body.velocity.y);

        if (hittingWall() || !hittingGround()) ChangeFacingDirection(facingDirection);

        if (haveNextState)
        {
            if (check.CheckDistance(parentTransform, maxDistance)) return nextState;
        }

        return this;
    }

    #region Collision
    private bool hittingWall()
    {
         //define cast distance for left and right
        var _castDist = baseCastDistance;
        if (facingDirection == LEFT)
        {
            _castDist = -_castDist;
        }

        //determine the target destination based on the cast distance
        Vector3 _targetPos = transform.position;
        _targetPos.x += _castDist;

        return Physics2D.Linecast(transform.position, _targetPos, layer);
    }
    private bool hittingGround()
    {

        //define cast distance for left and right
        var _castDist = baseCastDistance;

        //determine the target destination based on the cast distance
        Vector3 _targetPos = transform.position;
        _targetPos.y -= _castDist;

        Debug.DrawLine(transform.position, _targetPos);

        return Physics2D.Linecast(transform.position, _targetPos, layer);
    }
    #endregion

    #region Direction
    //concertar
    private void ChangeFacingDirection(string facing)
    {
        var _newScale = baseScale;
        var _facing = facing == LEFT;

        _newScale.x = _facing ? baseScale.x : -baseScale.x;

        parentTransform.localScale = _newScale;
        facingDirection = _facing ? RIGHT : LEFT;

    }
    #endregion
}
