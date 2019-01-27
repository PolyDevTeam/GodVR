using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvements : MonoBehaviour
{
    public float speed = 1f;
    public float sensitivity = 1f;

    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Left Joystick Horizontale") != 0.0f || Input.GetAxis("Left Joystick Verticale") != 0.0f)
        {
            //Debug.Log(Input.GetAxis("Left Joystick Horizontale"));
            this.gameObject.transform.Translate(Input.GetAxis("Left Joystick Horizontale") * speed, 0, Input.GetAxis("Left Joystick Verticale") * speed);
        }

        if (Input.GetAxis("Right Joystick Horizontale") != 0.0f || Input.GetAxis("Right Joystick Verticale") != 0.0f)
        {
            //Debug.Log(Input.GetAxis("Left Joystick Horizontale"));
            this.transform.Rotate(0, Input.GetAxis("Right Joystick Horizontale") * sensitivity, 0);
            cam.transform.Rotate(Input.GetAxis("Right Joystick Verticale") * sensitivity, 0, 0);
        }
    }
}
