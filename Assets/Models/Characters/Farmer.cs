/**
 * @file Farmer.cs
 * @brief IA des PNJ paysans
 * @author Guillaume MICHON
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @class Farmer
 * @brief IA des PNJ paysans
 */
public class Farmer : NPC
{
    /**
     * @enum Tasks
     * @brief Listes des tâches que peut faire un Farmer
     */
    new enum Tasks
    {
        MOVE_RANDOM = 1,
        DANCE = 2,
        CHICKEN = 3,
        LOOT = 4,
        FIGHT = 5 ,
        CRAFT = 6
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        Debug.Log("Load prefabs");
        
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    new public void Loot()
    {
        base.Loot();
    }

    /**
     * @fn void Craft()
     * @brief Crée un arbre à la position du Farmer
     */
    public void Craft()
    {
        base.Standing();
        //GameObject TreePrefab = Resources.Load("Prefabs/Tree") as GameObject;
        //Instantiate(TreePrefab, transform.position, transform.rotation);
    }

    /**
     * @fn void Fight()
     * @brief Combat le PNJ le plus proche
     */
    public void Fight()
    {
        GameObject opponentObject = GetClosestObject("NPC");
        base.target = opponentObject;
    }

    /**
     * @fn void ChoiceTask()
     * @brief Choisi une tache au hasard et l'execute
     */
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
            case Tasks.CHICKEN:
                Chicken();
                break;
            case Tasks.LOOT:
                Loot();
                break;
            case Tasks.FIGHT:
                Fight();
                break;
            case Tasks.CRAFT:
                Craft();
                break;
            default:
                Debug.Log("Unknown task for farmer NPC");
                break;
        }
    }
}
