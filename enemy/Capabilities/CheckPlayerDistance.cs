using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerDistance : MonoBehaviour
{
    private Transform position;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private bool precise = false;

    private void Awake()
    {
        position = GetComponent<Transform>();
    }

    public bool CheckDistance(Transform trans, float maxDistance)
    {
        position = trans; ;

        var _offSet = position.position - playerPosition.position;

        if (!precise)
        {
            var _distance = _offSet.sqrMagnitude; //usa pitágoras, mas para antes de fazer raiz quadrada

            return _distance < maxDistance;

        }
        else
        {
            //cost more processing
            //faz a raiz quadrada
            var _preciseLength1 = Vector3.Distance(position.position, playerPosition.position);
            var _preciseLength2 = _offSet.magnitude;

        }

        return false;

    }
}
