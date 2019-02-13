using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*! 
 *  @brief     Script pour realiser le mouvement via le stick gauche de la manette et la rotation de la camera via le regard
 *  @author    Clement STAMEGNA
 */
public class Mouvements : MonoBehaviour
{
    public float speed = 1f; /*!< vitesse de deplacement */
    public float sensitivity = 1f; /*!< sensibilite du regard */

    public GameObject cam; /*!< Objet representant la camera */

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Left Joystick Horizontale") != 0.0f || Input.GetAxis("Left Joystick Verticale") != 0.0f)
        {
            //Debug.Log(Input.GetAxis("Left Joystick Horizontale"));
            this.gameObject.transform.Translate(Input.GetAxis("Left Joystick Horizontale") * speed, 0, Input.GetAxis("Left Joystick Verticale") * speed);
        }

        //if (Input.GetAxis("Right Joystick Horizontale") != 0.0f || Input.GetAxis("Right Joystick Verticale") != 0.0f)
        //{
        //    //Debug.Log(Input.GetAxis("Left Joystick Horizontale"));
        //    this.transform.Rotate(0, Input.GetAxis("Right Joystick Horizontale") * sensitivity, 0);
        //    cam.transform.Rotate(Input.GetAxis("Right Joystick Verticale") * sensitivity, 0, 0);
        //}

        this.transform.rotation.Set(0, cam.transform.rotation.y * sensitivity, 0, 1);
    }
}
