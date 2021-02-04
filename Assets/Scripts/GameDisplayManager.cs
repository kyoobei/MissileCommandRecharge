using System;
using System.Collections.Generic;
using UnityEngine;
public class GameDisplayManager : MonoBehaviour
{
    [SerializeField] private Camera m_targetCamera = null;
    [SerializeField] private GameObject m_playerShooterPrefab = null;
    [SerializeField] private Pooler m_targetPooler = null;
    [SerializeField] private int m_numberOfTargetsOnLeft = 0;
    [SerializeField] private int m_numberOfTargetsOnRight = 0;
    [SerializeField] private float m_targetPadding = 0f;
    private List<GameObject> m_listOfSpawnedTargets = new List<GameObject>();
    public Action OnCreatedPlayerShooter;
    public Action OnCreatedTargets;
    public Action<GameObject> OnSetPlayerShooter;
    public Action<List<GameObject>> OnSetTargets;
    
    void Start()
    {
        SetPlayerShooterInTheMiddle();
        //left
        SetTargetPositions(m_numberOfTargetsOnLeft, Screen.width/6f);
        //right
        SetTargetPositions(m_numberOfTargetsOnRight, Screen.width/1.64f);
        OnSetTargets?.Invoke(m_listOfSpawnedTargets);
        OnCreatedTargets?.Invoke();
    }
    private void SetPlayerShooterInTheMiddle()
    {
        Vector3 middleCameraPosition = m_targetCamera.ScreenToWorldPoint(new Vector2(Screen.width/2f, 0f));
        GameObject shooter = Instantiate(m_playerShooterPrefab);
        shooter.transform.position = new Vector3(middleCameraPosition.x, middleCameraPosition.y, 0f);
        OnSetPlayerShooter?.Invoke(shooter);
        OnCreatedPlayerShooter?.Invoke();
    }
    private void SetTargetPositions(int numberOfTargets ,float startingPosition)
    {
        //for three on the left
        Vector3 startPos = m_targetCamera.ScreenToWorldPoint(new Vector2(startingPosition, 0f));
        float currentPadding = 0f;
        for(int i = 0; i < numberOfTargets; i++)
        {
            GameObject target = m_targetPooler.GetClone();
            target.transform.position = new Vector3(startPos.x + currentPadding, startPos.y, 0f);
            currentPadding += m_targetPadding;
            target.SetActive(true);
            m_listOfSpawnedTargets.Add(target);
        }
        
    }
}
