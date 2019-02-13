using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*! 
 *  @brief     Script pour utiliser les bouttons de la manette dans le menu principale.
 *  @author    Clement STAMEGNA
 */
public class MenuManette : MonoBehaviour
{

    public GameObject playButton; /*!< Objet pour représenter le boutton "jouer" */
    public GameObject exitButton; /*!< Objet pour représenter le boutton "quitter le jeu" */


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("A Button"))
        {
            playButton.GetComponent<ChangeScene>().Changement("Game");
        }

        if (Input.GetButtonDown("B Button"))
        {
            exitButton.GetComponent<QuitApplication>().Exit();
        }
    }
}
