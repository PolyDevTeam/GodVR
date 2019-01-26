using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : NPC
{
    // Mediter : de temps en temps, a voir
    new enum Tasks
    {
        MOVE_RANDOM = 1,
        DANCE = 2,
        MEDITATE = 3,
    }

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

    protected override void ChoiceTask()
    {
        Tasks task = (Tasks)Random.Range(1, Tasks.GetNames(typeof(Tasks)).Length + 1);

        switch (task)
        {
            case Tasks.MOVE_RANDOM:
                MoveRandomPoint();
                break;
            case Tasks.DANCE:
                Dance();
                break;
            case Tasks.MEDITATE:
                Medidate();
                break;
        }
    }
}
