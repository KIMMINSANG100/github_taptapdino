using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampSelectBtn : MonoBehaviour {

[SerializeField]
GameObject[] mode;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame 

int f =0;
	public void changeCamp()
	{
		
		for(int a=0; a<mode.Length ; a++ )
		{
			mode[a].SetActive(false);
		}
		f++;
		if(f>=mode.Length)
		f=0;


					mode[f].SetActive(true);
					ControlTowerScript.controlTowerScript.campNumber=f;
	} 
}
