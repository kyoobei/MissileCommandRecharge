using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : Missile
{
    [SerializeField] GameObject explosionPrefab = null;
    protected override void UpdateMissile()
    {
        if(!IsNearTarget())
        {
            MoveMissileTowardsTarget();
        }
        else
        {
            ResetMissile();
            SummonExplosion();
            ReturnMissile();
        }
    }
    public void SummonExplosion()
    {
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        Destroy(explosion, 2f);
    }
}
