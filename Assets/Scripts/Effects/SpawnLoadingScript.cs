using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoadingScript : MonoBehaviour {
public static SpawnLoadingScript instance;

 void Awake(){


	if(instance==null)
	{
		DontDestroyOnLoad(transform.gameObject);
		instance=this;
	}
	else if(instance != this)
	{
		Destroy(instance);
	}
 }
[SerializeField]
GameObject loading;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Loading() {

		GameObject tmp = Instantiate(loading);
		tmp.transform.position = GameObject.FindGameObjectWithTag("MainCamera").transform.position + new Vector3(0,0,1);
	}
}
