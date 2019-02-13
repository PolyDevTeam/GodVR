using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*! 
 *  @brief     Script pour changer de pouvoir.
 *  @author    Clement STAMEGNA
 */
public class ChangeSpell : MonoBehaviour
{
    public GameObject spellText; /*!< Objet pour représenter le nom du pouvoir a afficher */

    public GameObject spell0; /*!< le premier pouvoir */
    public GameObject spell1; /*!< le deuxieme pouvoir */

    public GameObject spellLauncher; /*!< Objet pour représenter l objet qui va lancer les sorts */
    public GameObject viseur; /*!< Objet pour représenter le viseur lorsque nous utilisons certains pouvoir */

    private List<GameObject> spellList;

    private bool once = true;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        spellList = new List<GameObject>();
        spellList.Add(spell0);
        spellList.Add(spell1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("DPadX") != 0 && once)
        {
            //Debug.Log("D pad OK : " + Input.GetAxis("DPadX"));
            i = (i + 1) % spellList.Count;

            spellLauncher.GetComponent<CastSpell>().spell = spellList[i];
            Debug.Log("activ spell is : " + spellList[i].name + " " + i);
            
            if (spellList[i % spellList.Count].name.Contains("Fire"))
            {
                spellText.GetComponent<Text>().text = "Boule de feu";
                viseur.GetComponent<Renderer>().material.color = Color.white;

            }

            if (spellList[i % spellList.Count].name.Contains("Meteor"))
            {
                spellText.GetComponent<Text>().text = "Météorite";
                viseur.GetComponent<Renderer>().material.color = Color.clear;
            }

            once = false;
        }

        if (Input.GetAxis("DPadX") == 0 && !once)
        {
            //Debug.Log("D pad a zero : " + Input.GetAxis("DPadX"));
            once = true;
        }


    }
}
