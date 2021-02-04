using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollide : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Enemy")
        {
            col.transform.GetComponentInParent<Missile>().StopMissile();
        }
    }
}
