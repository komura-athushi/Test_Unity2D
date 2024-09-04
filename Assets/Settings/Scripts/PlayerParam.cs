using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Player Setting", fileName = "PlayerParam")]
public class PlayerParam : ScriptableObject
{
    public float MoveSpeed;
    public float JumpPower;
    public string Id;
    public int Hp;
    public int Attack;
    public int Defense;
}
