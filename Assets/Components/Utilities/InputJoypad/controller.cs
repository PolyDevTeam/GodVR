using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*! 
 *  @brief     Script pour utiliser et tester les controlles a la manette
 *  @author    Clement STAMEGNA
 */
public class controller : MonoBehaviour {

    public GameObject A; /*!< Objet representant la touche A de la manette */
    public GameObject B; /*!< Objet representant la touche B de la manette */
    public GameObject Y; /*!< Objet representant la touche Y de la manette */
    public GameObject X; /*!< Objet representant la touche X de la manette */

    public GameObject leftStick; /*!< Objet representant le stick gauche de la manette */
    public GameObject rightStick; /*!< Objet representant le stick droit de la manette */

    private Vector3 initPosLeft; /*!< Position initiale du stick gauche */
    private Vector3 initPosRight; /*!< Position initiale du stick droit */

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
