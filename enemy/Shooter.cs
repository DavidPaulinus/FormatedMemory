using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private readonly int idleAnimation = Animator.StringToHash("Idle");
    private readonly int shootAnimation = Animator.StringToHash("Shoot");

    [Header("Objs para referencia")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject waterBullet;
    [SerializeField] private Transform player;

    [Header("Valores para referência")]
    [SerializeField] private float maxDistanceToShoot;
    [SerializeField] private float timeToShoot;

    private CheckPlayerDistance check;
    private Animator ani;

    private float counter;
    private bool shoot;
    private int state;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        check = GetComponent<CheckPlayerDistance>();

        counter = timeToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        var _distance = check.CheckDistance(transform, maxDistanceToShoot);

        if (player.position.x > transform.position.x) transform.rotation = new Quaternion(0,180,0,0);
        else transform.rotation = new Quaternion(0, 0, 0, 0); ;

        if (counter <= 0)
        {
            shoot = true;
            counter = timeToShoot;
        }
        counter -= Time.deltaTime;

        if (_distance && shoot)
        {
            shoot = false;
            Instantiate(waterBullet, firePoint.position, firePoint.rotation);
        }

        if (counter <= 1.1 && _distance) state = shootAnimation;
        else state = idleAnimation;

        ani.CrossFade(state,0,0);
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
