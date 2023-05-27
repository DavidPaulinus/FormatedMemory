using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    public abstract void doDamage(float damage, float IframeTime, float numeroDeFlashes, bool darIframe);
}
