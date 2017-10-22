using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void XbtnOn()
	{
		transform.parent.parent.gameObject.SetActive(false);
	}
}
