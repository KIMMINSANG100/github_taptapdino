using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDinoInCamp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void getImageFromInven()
	{

		Debug.Log("deid");
		int b = this.GetComponent<Inven_Box>().inven_Number;
		GameObject a = transform.GetChild(0).gameObject;
		GameObject tmpImg =	Instantiate(a); 
	}
}
