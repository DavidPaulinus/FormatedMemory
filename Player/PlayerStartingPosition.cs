using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingPosition : MonoBehaviour
{
    [SerializeField] private Transform startingPposition;

    void Start()
    {
        transform.position = startingPposition.position;
    }
}
