using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraplingPoint : MonoBehaviour
{
    [SerializeField] private float radius = 2.5f;
    [SerializeField] private GameObject player;

    private CheckPlayerDistance check;

    void Start()
    {
        check = GetComponent<CheckPlayerDistance>();
    }

    void Update()
    {
        player.GetComponentInChildren<GraplingGun>().canUseGrappling(check.CheckDistance(transform, radius * 4));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
