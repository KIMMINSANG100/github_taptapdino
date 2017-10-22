using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyEgg : MonoBehaviour {
	public static BuyEgg Instance;	


	public string eggSpec;
	[SerializeField]
	int eggSpecNumber;

	public int coin;
	public int crst;
	// Use this for initialization 
 


	// Update is called once per frame
	public void GetEgg () {  
			int k = 0;
			switch (eggSpec)
			{
				case "green":
					eggSpecNumber = 0;
					break;
				case "red":
					eggSpecNumber = 1;
					break;
				case "gray":
					eggSpecNumber = 2;
					break;
				case "electro":
					eggSpecNumber = 3;
					break;
				case "ska":
					eggSpecNumber = 4;
					break; 
				case "woods" :
					eggSpecNumber = 5;
					break;
				case "ice" :
					eggSpecNumber = 6;
					break;
				case "iron" :
					eggSpecNumber = 7;
					break;
				case "dark" :
					eggSpecNumber = 8;
					break;
				case "light" :
					eggSpecNumber = 9;
					break;



				case "don" :
					eggSpecNumber = 10;
					break;
				case "kera" :
					eggSpecNumber = 11;
					break;
				case "tego" :
					eggSpecNumber = 12;
					break;

				case "zino" :
					eggSpecNumber = 13;
					break;
				case "tera" :
					eggSpecNumber = 14;
					break;

				case "sinryu" :
					eggSpecNumber = 15;
					break;

				
				

				case "random" :
					int randEggNumb = Random.Range(1,9);
					eggSpecNumber = randEggNumb;
					break;

				//case "dark" :

				//	eggSpecNumber = 10;
				//	break;
			}

		if (this.name == "OtherManager") {

			eggSpecNumber = Random.Range (0,7 );
		}
 
					for(int a=0 ; a <5 ; a++)
					{
						if(ControlTowerScript.controlTowerScript.eggSpot[a]==false && k==0)
						{
							k++;
							// egg 부화시키기
							ControlTowerScript.controlTowerScript.Update_Eggs(a,true,eggSpecNumber,0);
 

						}		

						
				}
				ControlTowerScript.controlTowerScript.cristals -= crst ;
				ControlTowerScript.controlTowerScript.coins -= coin ;

				coin=0;
				crst=0;

		if (this.name != "OtherManager") {
			
			this.gameObject.SetActive (false);
			this.transform.parent.gameObject.SetActive (false);
		}
	}

	public void AlarmOff()
	{
		this.transform.parent.Find("yes").gameObject.SetActive(false);
				this.transform.parent.gameObject.SetActive(false);


	}
}
