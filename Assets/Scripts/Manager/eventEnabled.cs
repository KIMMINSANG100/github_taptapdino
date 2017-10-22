using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventEnabled : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(hiddenRewardsManager.Instances.event_coins==true)
		Destroy(gameObject);

		hiddenRewardsManager.Instances.event_coins=true;
	}
	
	// Update is called once per frame
	void Update () { 
		 
	}
}
