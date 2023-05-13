using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInput", menuName = "InputController/PlayerInput")]

public class PlayerInput : InputController
{
    public override float retriveHoldingDown()
    {
        return Input.GetAxisRaw("Vertical");
    }

    public override bool retriveHoldingJump()
    {
        return Input.GetButton("Jump");
    }

    public override bool retriveJUmp()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float retriveMoving()
    {
        return Input.GetAxisRaw("Horizontal");
    }
}
