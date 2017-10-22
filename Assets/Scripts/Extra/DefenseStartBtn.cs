using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseStartBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine(updateStartBtnState());	
	}
		bool k;
	IEnumerator updateStartBtnState()
	{		

		while(true)
		{
		for(int a=0; a<ControlTowerScript.controlTowerScript.battleInv.Length ; a++)
			{
				if(ControlTowerScript.controlTowerScript.battleInv[a]<500)
				{
					k=true;
				}
			
			}

		if(k==true)
		{
			this.GetComponent<Button>().enabled=true;
		}
		
		else
		{
			this.GetComponent<Button>().enabled=false;
		}
			yield return new WaitForSeconds(0.03f);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
