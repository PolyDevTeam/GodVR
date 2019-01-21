using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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

            //  Do Stuff
            Debug.Log("2sec passed");
            GameObject entity = GameObject.CreatePrimitive(PrimitiveType.Cube);
            entity.AddComponent<Rigidbody>();
            Vector3 newPos = this.transform.position;
            newPos.x += Random.Range(-5.0f, 5.0f);
            newPos.y += Random.Range(1.0f, 3.0f);
            newPos.z += Random.Range(-5.0f, 5.0f);
            entity.transform.position = newPos;
        }
        
    }
}
