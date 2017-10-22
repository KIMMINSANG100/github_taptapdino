using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCampManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadBattleScene()
	{
		SubTowerScript.subTowerScript.LoadBattleStage();

	}
}
