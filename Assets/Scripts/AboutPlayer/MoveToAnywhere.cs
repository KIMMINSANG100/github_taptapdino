using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAnywhere : MonoBehaviour {
	[SerializeField]
	Vector3 moveDir;
	[SerializeField]
	Vector3 scaleFactor;
	[SerializeField]
	bool moving = false;
	[SerializeField]
	bool scaling= false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(moving==true) 
			transform.position += moveDir*Time.deltaTime;

		if (scaling == true)
			transform.localScale += scaleFactor * Time.deltaTime;
	}
}
