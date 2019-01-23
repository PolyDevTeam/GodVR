using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootFireball : MonoBehaviour
{

    public GameObject Fireball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("FIRE");

            Instantiate(Fireball, this.transform);
        }
    }
}
