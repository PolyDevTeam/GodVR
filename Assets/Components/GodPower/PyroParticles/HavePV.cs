using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavePV : MonoBehaviour
{

    public int pv = 3;

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.gameObject.name);

        if (collisionInfo.gameObject.name.Contains("Fire"))
        {
            pv--;
            Debug.Log(pv);
            if (pv == 0)
            {
                //this.GetComponent<Civil>().setLife(0);
                Destroy(this.gameObject);
            }
        }
    }
}
