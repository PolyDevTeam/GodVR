using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civil : NPC
{
    new enum Tasks
    {
        MOVE_RANDOM = 1,
        DANCE = 2,
        CRAFT = 3,
        FIGHT = 4
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        if (Input.GetKeyDown(KeyCode.T))
        {
            MovePosition(new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public void Craft()
    {
        base.Standing();
        // TODO : Mettre un autre prefab
        //GameObject TreePrefab = Resources.Load("Prefabs/Tree") as GameObject;
        //Instantiate(TreePrefab, transform.position, transform.rotation);
    }

    public void Fight()
    {
        GameObject opponentObject = GetClosestObject("NPC");
        base.target = opponentObject;
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
            case Tasks.CRAFT:
                Craft();
                break;
            case Tasks.FIGHT:
                Fight();
                break;
        }
    }
}
