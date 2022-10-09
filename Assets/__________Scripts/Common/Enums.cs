using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState : byte
{
    Walk = 0,
    Run
}
public enum ControlMode : byte 
{
    Normal = 0, 
    AimMode,
    LockedOn 
}

public enum Weapons : byte
{
    Sword = 0,
    Bow,
}

public enum Skills : byte
{
    Heal,
    SpecialAttack_Sword,
    SpecialAttack_Archer,
    SkillCount
}

public enum EnemyState : byte
{
    Idle = 0,
    Patrol,
    Track,
    Attack,
    Knockback,
    Die,
}
