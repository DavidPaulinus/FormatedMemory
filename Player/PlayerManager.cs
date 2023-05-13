using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private bool disableControll = false;

    private Jump jump;
    private Move move;
    private PassTroghPlatform pass;

    private void Awake()
    {
        jump = GetComponent<Jump>();
        move = GetComponent<Move>();
        pass = GetComponent<PassTroghPlatform>();

    }

    public void DisableControll()
    {
        if (disableControll)
        {
            jump.enabled = false;
            move.enabled = false;
            pass.enabled = false;
        }
        else
        {
            jump.enabled = true;
            move.enabled = true;
            pass.enabled = true;
        }
    }
}
