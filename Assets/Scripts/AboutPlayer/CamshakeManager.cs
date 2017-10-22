using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamshakeManager : MonoBehaviour {
public static CamshakeManager camshakeManager;

	[SerializeField]
	GameObject exitCanvas ;
	public bool inShop;
	public bool camShake;


	void Awake(){


		if(camshakeManager==null)
		{
		//s	DontDestroyOnLoad(transform.gameObject);
			camshakeManager=this;
		}
		else if(camshakeManager != this)
		{
			Destroy(camshakeManager);
		}
	}
	// Use this for initialization
	void Start () {
				inShop=false;

	}
	
	// Update is called once per frame
	void Update () {
		
			if(Input.GetKeyDown(KeyCode.Escape))

			{ 
				GameObject exittmp =	Instantiate(exitCanvas);
				exittmp.transform.position = GameObject.FindGameObjectWithTag("MainCamera").transform.position + new Vector3(0,0,1);
		 		//Application.Quit();
			}

	}
}
