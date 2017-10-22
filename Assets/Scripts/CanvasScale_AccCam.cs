using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScale_AccCam : MonoBehaviour {

	
	// Use this for initialization
	float initCamSize;
	
	Vector3 initScale;
	void Start () {
		
	initCamSize=this.transform.parent.GetComponent<Camera>().orthographicSize;
	initScale =GetComponent<RectTransform>().localScale;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<RectTransform>().localScale = initScale* this.transform.parent.GetComponent<Camera>().orthographicSize/initCamSize;
	}
}
