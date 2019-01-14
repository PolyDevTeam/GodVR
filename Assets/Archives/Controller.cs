using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public GameObject A;
    public GameObject B;
    public GameObject Y;
    public GameObject X;

    public GameObject leftStick;
    public GameObject rightStick;

    private Vector3 initPosLeft;
    private Vector3 initPosRight;

    // Use this for initialization
    void Start () {
        initPosLeft = leftStick.transform.position;
        initPosRight = rightStick.transform.position;

    }

    // Update is called once per frame
    void Update () {
		if (Input.GetButton("A Button"))
        {
            A.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            A.GetComponent<Renderer>().material.color = Color.white;
        }

        if (Input.GetButton("B Button"))
        {
            B.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            B.GetComponent<Renderer>().material.color = Color.white;
        }

        if (Input.GetButton("Y Button"))
        {
            Y.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            Y.GetComponent<Renderer>().material.color = Color.white;
        }

        if (Input.GetButton("X Button"))
        {
            X.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            X.GetComponent<Renderer>().material.color = Color.white;
        }



        if (Input.GetAxis("Left Joystick Horizontale") != 0.0f || Input.GetAxis("Left Joystick Verticale") != 0.0f)
        {
            //Debug.Log(Input.GetAxis("Left Joystick Horizontale"));
            Vector3 newPos = new Vector3(initPosLeft.x + Input.GetAxis("Left Joystick Horizontale"), initPosLeft.y + Input.GetAxis("Left Joystick Verticale"), initPosLeft.z);
            leftStick.transform.position = newPos;
        }

        if (Input.GetAxis("Right Joystick Horizontale") != 0.0f || Input.GetAxis("Right Joystick Verticale") != 0.0f)
        {
            //Debug.Log(Input.GetAxis("Left Joystick Horizontale"));
            Vector3 newPos = new Vector3(initPosRight.x + Input.GetAxis("Right Joystick Horizontale"), initPosRight.y + Input.GetAxis("Right Joystick Verticale"), initPosRight.z);
            rightStick.transform.position = newPos;
        }

    }
}
