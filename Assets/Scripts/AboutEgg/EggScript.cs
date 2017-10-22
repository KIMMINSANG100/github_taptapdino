using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggScript : MonoBehaviour {

	[SerializeField]
	GameObject EggGetParticle;
 	Vector3  InvenBtnPos;


	[SerializeField]
	private string eggSpec;

	[SerializeField]
	float particleSpeed = 30;
	// Use this for initialization
	void Start () {
				 InvenBtnPos = GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("InvenBtn").transform.position;

	}


	// Update is called once per frame
	void Update () {
		if(transform.position.y<-2.6f)
		{
			Destroy(this.GetComponent<Rigidbody2D>());
		}
	}


string species;
int eggSpecNumber;
int green	=0;
int red		=1;
int gray	=2;
int electro	=3;
int ska 	=4;

	void OnMouseDown()
	{
		int k = 0;



 		switch (eggSpec)

		{	case "green":
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
					
					int randNumber = Random.Range(0,5);
					int randEggNumb_GodLegend;
					if(randNumber==0)
					randEggNumb_GodLegend = Random.Range(13,15);
					
					else if(randNumber==1)
					randEggNumb_GodLegend = Random.Range(6,9);

					else
					randEggNumb_GodLegend = Random.Range(1,5);


					eggSpecNumber = randEggNumb_GodLegend;
					break;
				

		}


/////
//알을 얻으면 컨트롤타워로 알정보가 날라감
/////
		if(this.tag=="Egg" )
		{ 
			GameObject ControlTower = GameObject.FindGameObjectWithTag("ControlTower").gameObject; 
					for(int a=0 ; a <5 ; a++)
					{
						if(ControlTower.GetComponent<ControlTowerScript>().eggSpot[a]==false && k==0)
						{
							k++;
							ControlTower.GetComponent<ControlTowerScript>().Update_Eggs(a,true,eggSpecNumber,0);

	if(EggGetParticle!=null)
	{
							GameObject parTmp = Instantiate(EggGetParticle);
							parTmp.transform.position = this.transform.position;
							parTmp.GetComponent<Rigidbody2D>().velocity =(InvenBtnPos - parTmp.transform.position).normalized * particleSpeed;
	
							Destroy(gameObject);
	}

						}		

						else 
						{
							int c=0 ;
 							for(int b=0 ; b <5 ; b++)
							{			
								if(ControlTower.GetComponent<ControlTowerScript>().eggSpot[b]==true)
								c++;
							}
									if(c==5)
										Alarm_EggFull();
						}
				} 
		}	
	}




	public void Alarm_EggFull()
	{

		GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera").gameObject;

		Cam.transform.Find("NoticeCanvas").transform.Find("Alarm").gameObject.SetActive(true);
		
		GameObject AlarmText = GameObject.FindGameObjectWithTag("AlarmText").gameObject;
		
		AlarmText.transform.parent.GetComponent<Animator>().SetTrigger("Alarm");
		
		AlarmText.GetComponent<Text>().text =  "it's full".ToString();
	}
}