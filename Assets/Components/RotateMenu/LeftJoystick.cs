using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftJoystick : MonoBehaviour {

    public float multiplicateur = 2;

	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Left Joystick Horizontale") != 0.0f || Input.GetAxis("Left Joystick Verticale") != 0.0f)
        {
            //Debug.Log(Input.GetAxis("Left Joystick Horizontale"));
            Vector3 newPos = new Vector3(Input.GetAxis("Left Joystick Horizontale") * multiplicateur, Input.GetAxis("Left Joystick Verticale") * multiplicateur, 0);
            this.transform.localPosition = newPos;
        }
    }
}
