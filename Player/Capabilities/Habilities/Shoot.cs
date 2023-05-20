using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}
