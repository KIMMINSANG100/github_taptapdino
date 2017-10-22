using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalService : MonoBehaviour {

	// Use this for initialization
	void Start () {
	if (GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().serviceCrst==true)
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

	void OnMouseDown()
	{
		k++;
		if(k==clickNumber)
		{
			GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().cristals+=rewardNumber;
			GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().serviceCrst=true;
			Destroy(gameObject);
		}
	}
}
