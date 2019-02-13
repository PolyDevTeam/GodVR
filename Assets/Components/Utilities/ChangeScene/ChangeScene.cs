using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*! 
 *  @brief     Script permettant le changement de scene Unity
 *  @author    Clement STAMEGNA
 */
public class ChangeScene : MonoBehaviour
{
    /*! 
     *  @brief     fonction pour changer de scene unity
     *  @author    Clement STAMEGNA
     *  @param[in]  string name  le nom de la scene a charger
     */
    public void Changement(string name)
    {
        SceneManager.LoadScene(name);
    }
}
