using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*! 
 *  @brief     Script pour quitter le jeu
 *  @author    Clement STAMEGNA
 */
public class QuitApplication : MonoBehaviour
{

    public void Exit()
    {
        Application.Quit(0);
    }
}
