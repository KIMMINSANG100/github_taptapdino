using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggPaymentCondition : MonoBehaviour {

	string eggSpec;
	Button btnOfThis;

	[SerializeField]
	string stringForSwitch;

	[SerializeField]
	int comparingNumber;

	// Use this for initialization
	void Start () {
		eggSpec = GetComponent<Products_Available>().eggSpec;
		btnOfThis = GetComponent<Button>();
		
		UpdateContents();
	}

	void UpdateContents()
	{
		thisTitle.text = thisTitleStr;
		thisPackageName.text = thisPackageNameStr;
		thisCondition.text = thisConditionStr;
		thisCost.text = thisCostInt.ToString();

		call_UpdateContents =false;
	}


	[SerializeField]
	bool call_UpdateContents;

	[SerializeField]
	bool canBuyIt;

	[SerializeField]
	Text thisTitle;
	[SerializeField]
	string thisTitleStr;

	[SerializeField]
	Text thisPackageName;
	[SerializeField]
	string thisPackageNameStr;



	[SerializeField]
	Text thisCondition;
	[SerializeField]
	string thisConditionStr;
	
	



	[SerializeField]
	Text thisCost;

	[SerializeField]
	int thisCostInt;





	// Update is called once per frame
	void Update () {
		

	
		switch(stringForSwitch) 
		{
			case "power": // 디노파워 얼마 이상일때

			if(ControlTowerScript.controlTowerScript.sumOfPowers > comparingNumber)
			{
							canBuyIt= true;	
			}
			else
							canBuyIt= false;	


			break;

			case "time": // 플레이시간이 얼마 이상일때

			if(ControlTowerScript.controlTowerScript.playTime > comparingNumber)
			{
							canBuyIt= true;	
			}
			else
							canBuyIt= false;	
			break;
			
			case "click": // 클릭이 얼마 이상일때

			if(ControlTowerScript.controlTowerScript.totalMouseClick > comparingNumber)
			{
							canBuyIt= true;	
			}
			else
							canBuyIt= false;	
			break;



			case "dino": // 어떤 디노를 보듀하고 이쓸때

			if(ControlTowerScript.controlTowerScript.bookChar[comparingNumber] ==true )
			{
							canBuyIt= true;	
			}
			else
							canBuyIt= false;	
			break;



			case "buyCrystal":


			if(EggSpawnManager.Instances.canbuyCrystal ==true )
			{
							canBuyIt= true;	
								transform.Find("CantUse").gameObject.SetActive((false));

			}
			else
							canBuyIt= false;	
			break;



		} 



 			if(canBuyIt==true)
					{
						btnOfThis.interactable=true ;
 					}
					else
					{
						btnOfThis.interactable=false ;
 					}


			
			 if(call_UpdateContents==true)
			 UpdateContents();
 
		 }


		public void cantbuycrystal()
		{
			EggSpawnManager.Instances.canbuyCrystal =false;
			EggSpawnManager.Instances.canbuyCrystal_time =0;
		}


	
	}



