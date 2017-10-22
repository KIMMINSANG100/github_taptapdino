using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenHurbScrpt : MonoBehaviour {

	// Use this for initialization

	void Start () {
	if (hiddenRewardsManager.Instances.hiddenHurb1018==true)
		Destroy(gameObject);		
	}
	[SerializeField]
	int clickNumber;
	[SerializeField]
	int rewardNumber;		
	// Update is called once per frame
	void Update () {
		
	}
	int k=0;


	[SerializeField]
	string rewardItem;
	void OnMouseDown()
	{
		k++;
		if(k==clickNumber)
		{ 
		
			hiddenRewardsManager.Instances.hiddenHurb1018=true;
			Destroy(gameObject);




	
		switch(rewardItem) 
		{
			case "hurb": //  
			ControlTowerScript.controlTowerScript.expHurb+=rewardNumber;
			break;

			case "crystal": // 
			ControlTowerScript.controlTowerScript.cristals+=rewardNumber;

		 	break;
			
			case "dino": //
 			break;

			default:
			break;
		} 

		}

	}
}
