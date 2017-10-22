using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoPowerInSelectDef : MonoBehaviour {

[SerializeField]
Text DinoPower_def;

	// Use this for initialization
	void Start () {

		int a = ControlTowerScript.controlTowerScript.DefenseDinoPower();

		DinoPower_def.text="Dino Power : " + a.ToString();
		StartCoroutine(DinoPowerUpdate());
	}
	
	// Update is called once per frame
	IEnumerator DinoPowerUpdate () {

		while(true){

			updateDP();
			yield return new WaitForSeconds(0.1f);
		}
	}
	void updateDP()
	{
	
		int a = ControlTowerScript.controlTowerScript.DefenseDinoPower();

		DinoPower_def.text="Dino Power : " + a.ToString();	
	}
}
