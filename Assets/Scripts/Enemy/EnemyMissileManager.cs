using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileManager : MissileManager
{
    private List<GameObject> m_listOfTargets;
    public void SetTargets(List<GameObject> targets)
    {
        m_listOfTargets = new List<GameObject>(targets);
    }
    protected override void SpawnMissiles()
    {
        Vector3 randomPointInCamera = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0,Screen.width), Screen.height));
        GameObject missile = m_pooler.GetClone();
        EnemyMissile eMissile = missile.GetComponent<EnemyMissile>();
        missile.transform.position = new Vector3(randomPointInCamera.x, randomPointInCamera.y, 0f);
       
        Vector3 targetPosition = Vector3.zero;
        Vector3 defaultPositionInCamera = new Vector3
            (
                missile.transform.position.x, 
                0f, 
                missile.transform.position.z
            );
        int randomTargetIndex = Random.Range(0, m_listOfTargets.Count - 1);
        targetPosition = m_listOfTargets[randomTargetIndex].transform.position;
        
        missile.transform.LookAt(defaultPositionInCamera, Vector3.back);
        eMissile.ReadyMissile(this, targetPosition);
        missile.SetActive(true);
        m_releaseInterval = m_releaseHolder;
    }
}
