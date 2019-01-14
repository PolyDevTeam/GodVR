using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    private bool active = false;


    public void Activate()
    {
        this.GetComponent<Renderer>().material.color = Color.green;
        active = true;
    }

    public void SetActive(bool b)
    {
        active = b;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
