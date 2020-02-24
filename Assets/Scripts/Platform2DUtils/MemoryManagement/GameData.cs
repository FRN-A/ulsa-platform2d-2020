using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    [SerializeField]
    Player player;
    [SerializeField]
    Vector3 playerPosition;

    public Vector3 PlayerPos 
    { 
        get => playerPosition;
        set => playerPosition = value; 
    }
    public Player Player
    {
        get => player;
        set => player = value;
    }
}
