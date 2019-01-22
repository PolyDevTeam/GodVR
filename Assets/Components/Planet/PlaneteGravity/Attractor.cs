using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {


    public GameObject planet;
    public float G = 9.8f;


	// Use this for initialization
	void Start () {
        Debug.Log("planet is " + planet.name);
	}
	
    void FixedUpdate()
    {
        Rigidbody rbp = planet.GetComponent<Rigidbody>();
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();

        Vector3 direction = - rb.position + rbp.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = G * (rb.mass * rbp.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rb.AddForce(force);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
