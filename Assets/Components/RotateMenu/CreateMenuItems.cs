using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMenuItems : MonoBehaviour {

    public int nbItems = 4;
    public Transform item;

	// Use this for initialization
	void Start () {

        ArrayList menuItems = new ArrayList();
        for (int i = 0; i < nbItems; i++)
        {
            menuItems.Add("action " + i);
            Debug.Log(menuItems[i]);
        }
        Debug.Log(menuItems.Count);

        for (int i = 0; i < menuItems.Count; i++)
        {

            Vector2 pos = MathHelpers.DegreeToVector2((360 / (menuItems.Count) * i) + 90);
            Transform Cube = Instantiate(item, new Vector3(pos.x + this.transform.position.x, pos.y + this.transform.position.y, 0), Quaternion.identity, this.transform);
            Cube.name = "Item_" + i;

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
