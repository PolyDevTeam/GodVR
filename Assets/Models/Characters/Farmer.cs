using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : NPC
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public void loot()
    {
        anim.SetBool("DoLoot", DoLoot);
        DoLoot = !DoLoot;
    }
}
