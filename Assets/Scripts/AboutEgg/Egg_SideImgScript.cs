using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_SideImgScript : MonoBehaviour {
public static Egg_SideImgScript eggSideImgScript;



	[SerializeField]
	EvolAndSpawningScript evolAndSpawning;


	// Use this for initialization
	void Start () {
	eggSelectedNumb=6;
	eggNumbBefore=eggSelectedNumb;	
		}
	public int eggSelectedNumb;
	int eggNumbBefore;
	// Update is called once per frame



	public int eggBoxNumber;

	public bool[]	eggSpot = new bool[5];
//	public int[] eggNumber;
	public int[] eggSpecies = new int[5];

	public float[]	eggExp = new float[5];

	void Update () {
			if(eggSelectedNumb<eggSpecies.Length)
					evolAndSpawning.eggNumber = eggSpecies[eggSelectedNumb]	;		

		//if(eggNumb !=eggNumbBefore)
		{
			for(int a=0; a < 5 ; a++ )
			{	
				
				{
					eggSpot[a]		= ControlTowerScript.controlTowerScript.eggSpot[a];
					eggSpecies[a] 	= ControlTowerScript.controlTowerScript.eggSpecies[a];
					eggExp[a]		= ControlTowerScript.controlTowerScript.eggExp[a];
				}
			} 
			//eggNumbBefore= eggSelectedNumb;

		}


		
	}


	void IfPushHatch()
	{
		eggSpot[eggSelectedNumb]=false;
		eggSpecies[eggSelectedNumb]=0;
		eggExp[eggSelectedNumb]=0;



	}



	void OnMouseDown()
	{
 	}

}
