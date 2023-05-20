using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "level/LevelConnectoin")]

public class LevelConnection : ScriptableObject
{
    public static LevelConnection activeConnection { get; set; }
}
