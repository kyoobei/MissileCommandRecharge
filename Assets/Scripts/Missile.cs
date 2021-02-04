using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] protected Rigidbody m_rigidBody = null;
    [SerializeField] protected float m_missileSpeed = 0f;
    protected Vector3 m_currentTarget = Vector3.zero;
    protected bool m_isReady = false;
    protected MissileManager m_missileManager = null;
    private void FixedUpdate()
    {
        if(!m_isReady)
        {
            return;
        }
        UpdateMissile();
    }
    protected virtual void UpdateMissile()
    {
        if(!IsNearTarget())
        {
            MoveMissileTowardsTarget();
        }
        else
        {
            ResetMissile();
        }
    }
    protected virtual void MoveMissileTowardsTarget()
    {
        Vector3 direction = (m_currentTarget - transform.position).normalized;
        m_rigidBody.MovePosition(transform.position + direction * m_missileSpeed * Time.fixedDeltaTime);
    }
    protected bool IsNearTarget()
    {
        float distance = Vector3.Distance(transform.position, m_currentTarget);
        if(distance > 0.1f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public virtual void ReadyMissile(MissileManager missileManager, Vector3 targetPosition)
    {
        m_missileManager = missileManager;
        m_rigidBody.velocity = Vector3.zero;
        m_currentTarget = targetPosition;
        transform.LookAt(m_currentTarget, Vector3.forward);
        m_isReady = true;
    }
    protected void ResetMissile()
    {
        m_isReady = false;
        m_rigidBody.velocity = Vector3.zero; 
    }
    public void ReturnMissile()
    {
        m_missileManager.ReturnThisMissile(this.gameObject);
    }
}
