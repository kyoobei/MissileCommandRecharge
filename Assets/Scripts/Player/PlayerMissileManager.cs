using UnityEngine;

public class PlayerMissileManager : MissileManager
{
    private GameObject m_shooter;
    protected override void Start()
    {
        base.Start();
        m_releaseInterval = 0f;
    }
    protected override void SpawnMissiles()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 touchTargetBaseOnScreen = m_targetCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPos = new Vector3(touchTargetBaseOnScreen.x, touchTargetBaseOnScreen.y, 0f);
            GameObject missile = m_pooler.GetClone();
            Transform startingMissilePosition = m_shooter.transform.GetChild(1);
            PlayerMissile pMissile = missile.GetComponent<PlayerMissile>();
            missile.transform.position = startingMissilePosition.position;
            pMissile.ReadyMissile(this,targetPos);
            missile.SetActive(true);
            m_releaseInterval = m_releaseHolder;
        }
    }
    public void SetShooter(GameObject shooter)
    {
        m_shooter = shooter;
    }
}
