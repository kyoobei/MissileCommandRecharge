using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : Missile
{
    [SerializeField] GameObject explosionPrefab = null;
    private bool isStop = false;
    protected override void UpdateMissile()
    {
        if(!isStop)
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
    }
    public override void StopMissile()
    {
        SummonExplosion();
        base.StopMissile();
    }
    public override void ReadyMissile(MissileManager missileManager, Vector3 targetPosition)
    {
        isStop = false;
        base.ReadyMissile(missileManager, targetPosition);
    }
    public void SummonExplosion()
    {
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        Destroy(explosion, 2f);
    }
}
