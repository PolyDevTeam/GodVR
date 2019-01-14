using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCtrl : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        other.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        other.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }


}
