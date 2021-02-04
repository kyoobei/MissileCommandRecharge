using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour
{
    [SerializeField] protected Camera m_targetCamera = null;
    [SerializeField] protected Pooler m_pooler = null;
    [SerializeField] protected float m_releaseInterval = 0f;
    private bool isReady = false;
    protected float m_releaseHolder = 0f;
    protected virtual void Start()
    {
        m_releaseHolder = m_releaseInterval;
    }
    private void Update()
    {
        if(!isReady)
        {
            return;
        }
        if(IsReadyToSpawnMissile())
        {
            SpawnMissiles();
        }
    }
    protected virtual void SpawnMissiles()
    {

    }
    protected bool IsReadyToSpawnMissile()
    {
        if(m_releaseInterval > 0f)
        {
            m_releaseInterval -= Time.deltaTime;
            return false;
        }
        else
        {
            return true;
        }
    }
    public virtual void ReturnThisMissile(GameObject missile)
    {
        m_pooler.ReturnClone(missile);
    }
    public virtual void Ready()
    {
        isReady = true;
    }
}
