using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{

    public GameObject spell;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("A Button"))
        {
            //Debug.Log("FIRE");

            Instantiate(spell, this.transform.position, this.transform.rotation);
        }
    }
}
