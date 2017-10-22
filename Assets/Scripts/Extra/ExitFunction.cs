using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitFunction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Exit()
	{
		if(Application.platform == RuntimePlatform.Android)

		Application.Quit();
	}
	public void Stay()
	{
		Destroy(transform.parent.gameObject);
	}

}
