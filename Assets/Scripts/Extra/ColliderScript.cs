using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderScript : MonoBehaviour {

public int rand;
	// Use this for initialization
	void Start () {
		
		if(this.name=="MultipleFactor")
		{

			int realRand = Random.Range(1,9);

			if(realRand <=5)
			rand = 2;
			else if(realRand <=8)
			rand = 3;
			else if(realRand<=9)
			rand = 4;
			else
			rand = 5;

			this.GetComponent<Text>().text = rand.ToString();
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	int rewa=0;
	void OnMouseDown()
	{

		if(this.name=="Skip")
		{
			GetComponent<ExtraFunction>().GoMainScene_Hatched();
		}
		else if(this.name=="SkipMain")
		{
			if(ControlTowerScript.controlTowerScript.sumOfPowers<3)
			SubTowerScript.subTowerScript.Load_Trailler();	
			else
				SubTowerScript.subTowerScript.LoadMain();
		}
		else if(this.name=="MultipleFactor")
		{ 
			if (rewa == 0) {
				AdManager.Instance.ShowVideo ();
				rewa++;
			}
		}

		
		else
		{ 
				//AdManager.Instance.ShowVideo ();
		}
	}
}
