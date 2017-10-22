using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggTimeBar_Instances : MonoBehaviour {
	[SerializeField]
	GameObject[] Characters;

	GameObject ControlTower;

	// Use this for initialization 
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MakeInstanceOfChars(int charNumber)
	{
		GameObject tmp			= Instantiate( Characters[charNumber]);
		tmp.transform.position	= GameObject.FindGameObjectWithTag("Player").transform.position;

				ControlTower 	= GameObject.FindGameObjectWithTag("ControlTower").gameObject;
				ControlTower.GetComponent<CharacterInstantiating>().InstantiateCharacter(0,charNumber);
	}
}
