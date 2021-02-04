using System;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField] private GameObject m_objectToClone = null;
    [SerializeField] private Transform m_parentTransform = null;
    [SerializeField] private int m_numberOfClones = 0;
    private Queue<GameObject> m_cloneQueue = new Queue<GameObject>();
    private List<GameObject> m_cloneReleasedList = new List<GameObject>();

    void Awake()
    {
        for(int i = 0; i < m_numberOfClones; i++)
        {
            GameObject clone = Instantiate(m_objectToClone);
            clone.transform.SetParent(m_parentTransform);
            ResetTransform(clone);
            clone.SetActive(false);
            m_cloneQueue.Enqueue(clone);            
        }
    }
    public GameObject ReleaseClone()
    {
        GameObject clone = null;
        if(m_cloneQueue.Count > 0)
        {
            clone = m_cloneQueue.Dequeue();
            m_cloneReleasedList.Add(clone);
        }
        else if(m_cloneQueue.Count <= 0)
        {
            clone = Instantiate(m_objectToClone);
            clone.transform.SetParent(m_parentTransform);
            ResetTransform(clone);
            m_cloneReleasedList.Add(clone);
        }
        return clone;
    }
    public void ReturnClone(GameObject returnedObject)
    {
        if(m_cloneReleasedList.Contains(returnedObject))
        {
            m_cloneReleasedList.Remove(returnedObject);
        }
        returnedObject.SetActive(false);
        ResetTransform(returnedObject);
        m_cloneQueue.Enqueue(returnedObject);
    }
    private void ResetTransform(GameObject clone)
    {
        clone.transform.localPosition = Vector3.zero;
        clone.transform.localRotation = Quaternion.identity;
        clone.transform.localScale = Vector3.one;
    }
}
