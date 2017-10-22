using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitInvenAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
		
	}
	[SerializeField]
	Transform PlayerTransform;
	public void InitInvenAllAgain()
	{ 
			transform.GetComponent<InventoryManager>().invenInit();
	
		Invoke("delay",0.05f);
	}
	void delay()
	{

        int invNo = PlayerTransform	.GetChild(0).GetComponent<Dino_Individual>().inven_Number;

        GameObject invBox = GameObject.FindGameObjectWithTag("InventoryBoxes").transform.GetChild(invNo).gameObject;
        // invBox.GetComponent<InventoryManager>().Update_ToLeftImage();

	}
}
