using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManette : MonoBehaviour
{

    public GameObject playButton;
    public GameObject exitButton;


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
