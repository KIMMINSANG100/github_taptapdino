using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageAchievement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int mapNumb = transform.parent.GetComponent<SelectLevel_BattleScene> ().mapNumber;

		GameObject Controltower = GameObject.FindGameObjectWithTag ("ControlTower");
		int k = Controltower.GetComponent<ControlTowerScript>().map [mapNumb];	

		if(k >10) k =10;
		GetComponent<Text> ().text = k  + "/ 10".ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
