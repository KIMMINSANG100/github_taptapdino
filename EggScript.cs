using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		
	}


string species;
int eggSpecNumber;
int green	=0;
int red		=1;
int yellow	=2;
int sky		=3;
int gray 	=4;

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



		}


/////
//알을 얻으면 컨트롤타워로 알정보가 날라감
/////
		if(this.tag=="Egg")
		{ 
			GameObject ControlTower = GameObject.FindGameObjectWithTag("ControlTower").gameObject; 
					for(int a=0 ; a <6 ; a++)
					{
						if(ControlTower.GetComponent<ControlTowerScript>().eggSpot[a]==false && k==0)
						{
							k++;
							ControlTower.GetComponent<ControlTowerScript>().Update_Eggs(a,true,eggSpecNumber,0);
							

						}		


					}
 
					GameObject parTmp = Instantiate(EggGetParticle);
					parTmp.transform.position = this.transform.position;
					parTmp.GetComponent<Rigidbody2D>().velocity =(InvenBtnPos - parTmp.transform.position).normalized * particleSpeed;

						
					Destroy(gameObject);
		}	
	
	}
}