using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : Missile
{
    protected override void UpdateMissile()
    {
        if(!IsNearTarget())
        {
            MoveMissileTowardsTarget();
        }
        else
        {
            ResetMissile();
            ReturnMissile();
        }
    }
}
