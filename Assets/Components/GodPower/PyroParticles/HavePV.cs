using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavePV : MonoBehaviour
{
    public NPC npc;

    void OnCollisionEnter(Collision collisionInfo)
    {
        int life = npc.getLife();

        if (collisionInfo.gameObject.name.Contains("Fire"))
        {
            life = (life >= 0 ? life - 50 : 0);
            npc.setLife(life);
        }
        else if(collisionInfo.gameObject.name.Contains("Meteor"))
        {
            life = 0;
            npc.setLife(0);
        }
    }
}
