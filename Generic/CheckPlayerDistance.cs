using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerDistance : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private bool precise = false;
    public bool CheckDistance(Transform trans, float maxDistance)
    {
        var _offSet = trans.position - playerPosition.position;

        if (!precise)
        {
            var _distance = _offSet.sqrMagnitude; //usa pitágoras, mas para antes de fazer raiz quadrada

            return _distance <= maxDistance;

        }

        //cost more processing
        //faz a raiz quadrada
        //var _preciseLength2 = _offSet.magnitude;
        var _preciseLength1 = Vector3.Distance(trans.position, playerPosition.position);

        return _preciseLength1 <= maxDistance;

    }
}
