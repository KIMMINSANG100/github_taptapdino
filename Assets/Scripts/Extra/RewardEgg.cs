using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardEgg : MonoBehaviour {  
	public string eggSpec;
	[SerializeField]
	int eggSpecNumber;

	public int coin;
	public int crst;
	// Use this for initialization 
 
	public void sendEggInfo_andGet(string dinoName)
	{
		eggSpec=dinoName;
		GetEgg();
	}

	// Update is called once per frame
	public void GetEgg () {  /// buy EGG 도 수정해야함 . 인스턴스로 만들까했는데 확인이 오래걸릴거같아서 구찮.!--.!--.
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
				
				
				case "random_GodLegend" :
					
					int randNumber = Random.Range(0,1);
					int randEggNumb_GodLegend;
					if(randNumber==0)
					randEggNumb_GodLegend = Random.Range(13,15);
					
					else
					randEggNumb_GodLegend = Random.Range(6,9);


					eggSpecNumber = randEggNumb_GodLegend;
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

			this.gameObject.SetActive (false); 
		
	}

	public void AlarmOff()
	{
		this.transform.parent.Find("yes").gameObject.SetActive(false);
				this.transform.parent.gameObject.SetActive(false);


	}
}
