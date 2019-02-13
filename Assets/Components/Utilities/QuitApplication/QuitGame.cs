using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*! 
 *  @brief     Script pour quitter le jeu lors de l'appui de la touche B de la manette ou de la touche echap du clavier
 *  @author    Clement STAMEGNA
 */
public class QuitGame : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("B Button"))
        {
            //Debug.Log("Quit");
            Application.Quit(0);
        }
    }

}
