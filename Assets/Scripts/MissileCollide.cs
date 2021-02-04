using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollide : MonoBehaviour
{
    [SerializeField] Missile playerMissile;
    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Enemy")
        {
            playerMissile.StopMissile();
            col.transform.GetComponentInParent<Missile>().StopMissile();
        }
    }
}
