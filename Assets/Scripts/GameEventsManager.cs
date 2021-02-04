using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    [SerializeField] GameDisplayManager m_displayManager = null;
    [SerializeField] PlayerMissileManager m_playerMissileManager = null;
    [SerializeField] EnemyMissileManager m_enemyMissileManager = null;
    private void OnEnable()
    {
        m_displayManager.OnCreatedPlayerShooter += m_playerMissileManager.Ready;
        m_displayManager.OnSetPlayerShooter += m_playerMissileManager.SetShooter;

        m_displayManager.OnCreatedTargets += m_enemyMissileManager.Ready;
        m_displayManager.OnSetTargets += m_enemyMissileManager.SetTargets;
    }
    private void OnDisable()
    {
        m_displayManager.OnCreatedPlayerShooter -= m_playerMissileManager.Ready;
        m_displayManager.OnSetPlayerShooter -= m_playerMissileManager.SetShooter;

        m_displayManager.OnCreatedTargets -= m_enemyMissileManager.Ready;
        m_displayManager.OnSetTargets -= m_enemyMissileManager.SetTargets;
    }
}
