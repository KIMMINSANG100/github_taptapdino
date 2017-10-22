using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBook : MonoBehaviour {

[SerializeField]
public int dayGift;

[SerializeField]
RewardEgg rewardEggScrpt;
	// Use this for initialization
	void Start () {
		//dayGift = ControlTowerScript.controlTowerScript.dayGift;	
		//buyEggScrpt.eggSpec.
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int dayFromInstall=0;


	public void GetReward()
	{
		

		StartCoroutine(giveReward());

	}
	

// 현재일자 선언
// 저번일자 선언 
// 저번일자 시작시 현재일자를 저번일자에 저장
// 저번일자와 처음 비교. 보상지급 후 저번일자 : ++
// 비교 했는지 안했는지 선별하는 변수저장

//1. 저번 일자 불러오기
//2. REWARD 불러오기
//	3. 현재 일자와 비교 => 1차이 이상시 저번일자 ++
// //4.
// int dayFromInstal;

	IEnumerator giveReward()
	{

//
//		lastDay = System.DateTime.Now.Date;

	yield return new WaitForSeconds(0.1f);
		//if()
		switch(dayGift)
		{
			case 1 :
				
				getExpHurb(5);
				break;

			case 2 :

				getCoins(10000);
 				break;
				
			case 3 :
				
				getEgg("ska");
				break;
				
			case 4 :
				getMeat(20);
				break;
				
			case 5 :
				getPotion(5);
				break;
				
			case 6 :
				getCrystal(100);
				break;
				
			case 7 :
				
				break;
				
			case 8:
				getExpHurb(8);
				break;
				
			case 9 :
				getCrystal(100);
				break;
			
			case 10 :

				getPotion(10);
				break;
				
			case 11 :
				getCoins(50000);
				break;

			case 12 :
				getExpHurb(15);
				break;
				
			case 13 :
				getCrystal(200);
				break;
				
			case 14 :
				//알알알
				break;
				
			case 15 :
				getCoins(800000);
				break;
				
			case 16 :
				getMeat(50);
				break;
				
			case 17 :
				
				break;
				
			case 18:
				getExpHurb(20);
				break;
				
			case 19 :
				getMeat(100);
				break;
			case 20 :
				getPotion(20);
				break;
				
			case 21 :
				///godgod알
				break;

			case 22 :
				
				getExpHurb(5);
				break;
				
			case 23 :
				getExpHurb(5);
				break;
				
			case 24 :
				getCrystal(400);
				break;
				
			case 25 :
				getMeat(50);
				break;
				
			case 26 :
				getExpHurb(1);
				break;
				
			case 27 :
				getExpHurb(1);
				break;
				
			case 28:
				//하쿠하쿠알
				break;
				 
		}

	}




void getCrystal(int howMuch)
{
	ControlTowerScript.controlTowerScript.cristals+=howMuch;
}

void getCoins(int howMuch)
{
	ControlTowerScript.controlTowerScript.coins+=howMuch;
}

void getExpHurb(int howMuch)
{
	ControlTowerScript.controlTowerScript.expHurb+=howMuch;
}
void getMeat(int howMuch)
{
	ControlTowerScript.controlTowerScript.meat+=howMuch;
}

void getPotion(int howMuch)
{
	ControlTowerScript.controlTowerScript.potion+=howMuch;
}


void getEgg(string WhatEgg)
{
	rewardEggScrpt.sendEggInfo_andGet(WhatEgg);
}







}
