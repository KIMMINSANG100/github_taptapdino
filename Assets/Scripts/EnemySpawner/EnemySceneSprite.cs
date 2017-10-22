using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySceneSprite : MonoBehaviour {

	void Awake()
	{
		int map = GameObject.FindGameObjectWithTag ("ControlTower").GetComponent<ControlTowerScript> ().mapImg;

		if(GetComponent<TrainingTarget> ()!=null)
		GetComponent<TrainingTarget> ().factorHp	= map;
	}
	// Use this for initialization
	void Start () {
		int map = GameObject.FindGameObjectWithTag ("ControlTower").GetComponent<ControlTowerScript> ().mapImg;

		GetComponent<SpriteRenderer>().sprite = spriteByScene[map];
		GetComponent<TrainingTarget> ().factorHp	= map;
 	}


	[SerializeField]
	Sprite[] spriteByScene;
	// Update is called once per frame
	void Update () 
	{

	}
}