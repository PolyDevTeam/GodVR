using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject magicMaleNPC;
    private GameObject magicFemaleNPC;
    private GameObject farmerMaleNPC;
    private GameObject farmerFemaleNPC;
    private GameObject civilMaleNPC;
    private GameObject civilFemaleNPC;

    private const float RANGE = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        magicMaleNPC = Resources.Load("Prefabs/magic_male") as GameObject;
        magicFemaleNPC = Resources.Load("Prefabs/magic_female") as GameObject;
        farmerMaleNPC = Resources.Load("Prefabs/farmer_male") as GameObject;
        farmerFemaleNPC = Resources.Load("Prefabs/farmer_female") as GameObject;
        civilMaleNPC = Resources.Load("Prefabs/Civil_male") as GameObject;
        civilFemaleNPC = Resources.Load("Prefabs/Civil_female") as GameObject;
    }

    private float time = 0.0f;
    public float period = 2f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= period)
        {
            time = 0.0f;

            int npcSelect = Random.Range(1, 4);
            bool isMale = (Random.value <= 0.5 ? true : false);
            GameObject entity;

            switch(npcSelect)
            {
                case 1:
                    entity = (isMale ? magicMaleNPC : magicFemaleNPC);
                    break;
                case 2:
                    entity = (isMale ? farmerMaleNPC : farmerFemaleNPC);
                    break;
                case 3:
                    entity = (isMale ? civilMaleNPC : civilFemaleNPC);
                    break;
                default:
                    entity = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    break;
            }

            //  Do Stuff
            Debug.Log("2sec passed");
            //GameObject entity = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Vector3 newPos = this.transform.position;
            newPos.x += Random.Range(-RANGE, RANGE);
            newPos.y += Random.Range(RANGE, 3.0f);
            newPos.z += Random.Range(-RANGE, RANGE);

            Quaternion rotation = Quaternion.identity;

            Instantiate(entity, newPos, rotation);
        }
        
    }
}
