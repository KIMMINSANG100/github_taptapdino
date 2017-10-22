using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownSetFalse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


[SerializeField]
GameObject ObjectFalse;
	void OnMouseDown()
	{
		Debug.Log("x");

		ObjectFalse.gameObject.SetActive(false);


	}

}
