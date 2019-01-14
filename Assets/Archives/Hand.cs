using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public bool isLeftHand = true;

	// Use this for initialization
	void Start () {

        //  Creation du selecteur pour le menu 
        //          - creer la Sphere selecteur
        //          - adopter le selecteur
        //          - transform
        //          - collider
        //          - rigidbody

        GameObject selecteur = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        selecteur.name = "selecteurMenu";

        selecteur.transform.SetParent(this.transform);
        selecteur.transform.localPosition = Vector3.zero;

        selecteur.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        selecteur.GetComponent<SphereCollider>().isTrigger = true;

        selecteur.AddComponent<Rigidbody>();
        selecteur.GetComponent<Rigidbody>().useGravity = false;

        selecteur.AddComponent<CollisionCtrl>();

        //  Si main gauche on rajoute au selecteur le component pour le stick gauche sinon droit
        if (isLeftHand)
        {
            selecteur.AddComponent<LeftJoystick>();
        }
        else
        {

        }


        //  Creation du Menu
        //      - creation du noyau du menu
        //      - adopter le noyau
        //      - pour chaque item dans le menu
        //             - creer un cube
        //             - le faire adopter par le noyau

        //      fake menu items array
        ArrayList menuItems = new ArrayList();
        for(int i = 0; i < 5; i++)
        {
            menuItems.Add("action " + i);
            Debug.Log(menuItems[i]);
        }
        Debug.Log(menuItems.Count);

        GameObject noyau = new GameObject();
        noyau.name = "noyauMenu";
        noyau.transform.SetParent(this.transform);

        noyau.transform.localPosition = new Vector3(0, 0, 0);

        for (int i = 0; i < menuItems.Count; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = "menuItem_" + i ;
            cube.transform.SetParent(noyau.transform);

            Vector2 pos = MathHelpers.DegreeToVector2((360/(menuItems.Count) * i) + 90);
            cube.transform.localPosition = new Vector3(pos.x, pos.y, 0);

            cube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
