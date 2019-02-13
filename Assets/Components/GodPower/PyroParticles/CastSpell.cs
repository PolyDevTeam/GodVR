using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*! 
 *  @brief     Script pour lancer un pouvoir en appuyant sur le boutton A de la manette.
 *  @author    Clement STAMEGNA
 */
public class CastSpell : MonoBehaviour
{

    public GameObject spell; /*!< Objet pour représenter le pouvoir actuellement utilise */


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
