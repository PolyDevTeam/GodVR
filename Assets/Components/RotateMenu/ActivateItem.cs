using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateItem : MonoBehaviour {

    private GameObject last = null;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
        if (MathHelpers.Distance2Points(new Vector2(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y), Vector2.zero) < 1 && last != null)
        {
            Debug.Log("Activation menu" + last.name);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        //other.gameObject.GetComponent<Item>().Activate();
        other.gameObject.GetComponent<Renderer>().material.color = Color.green;
        other.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        last = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        other.transform.localScale = new Vector3(1f, 1f, 1f);

    }
}
