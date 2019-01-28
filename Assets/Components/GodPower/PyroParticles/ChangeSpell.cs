using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpell : MonoBehaviour
{
    public GameObject spellText;

    public GameObject spell0;
    public GameObject spell1;

    public GameObject spellLauncher;

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
            }

            if (spellList[i % spellList.Count].name.Contains("Meteor"))
            {
                spellText.GetComponent<Text>().text = "Météorite";
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
