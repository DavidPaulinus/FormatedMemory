using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : ScriptableObject
{
    public abstract float retriveMoving();
    public abstract float retriveHoldingDown();
    public abstract bool retriveJUmp();
    public abstract bool retriveHoldingJump();
}
