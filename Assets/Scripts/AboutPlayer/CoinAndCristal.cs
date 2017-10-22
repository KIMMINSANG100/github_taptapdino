using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAndCristal : MonoBehaviour {

 
[SerializeField]
private double coin;

[SerializeField]
private double cristal;

Text coinTxt;
Text cristalTxt;

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("ControlTower").gameObject!=null)
 		coin = ControlTowerScript.controlTowerScript.coins;
		cristal = ControlTowerScript.controlTowerScript.cristals;

		if(this.name == "CoinTxt")
		{
			coinTxt = GetComponent<Text>();
			coinTxt.text = coin.ToString();
		}

		if(this.name == "CrstTxt")
		{
			cristalTxt = GetComponent<Text>();
			cristalTxt.text = cristal.ToString();
		}


		if(this.name == "CoinTxt_Battle")
		{
			coinTxt = GetComponent<Text>();
			coinTxt.text = 0.ToString();
		}

		if(this.name == "CrstTxt_Battle")
		{
			cristalTxt = GetComponent<Text>();
			cristalTxt.text = 0.ToString();
		}
	}
	

	// 코인 처리 : 배경 코인 크리스탈 txt , 샵 코인 크리스탈 txt
	
	void Update () {
 


			if(coin != ControlTowerScript.controlTowerScript.Coin_Battle&&this.name == "CoinTxt_Battle")
			{
					coin = ControlTowerScript.controlTowerScript.Coin_Battle;
					coinTxt.text = coin.ToString();
			}



			else if(cristal != ControlTowerScript.controlTowerScript.Crst_Battle&&this.name == "CrstTxt_Battle")
			{
					cristal = ControlTowerScript.controlTowerScript.Crst_Battle;
					cristalTxt.text = cristal.ToString();
			}


/////////////
			else if(coin != ControlTowerScript.controlTowerScript.coins&&this.name == "CoinTxt")
			{
					coin = ControlTowerScript.controlTowerScript.coins;
					coinTxt.text = coin.ToString();
 			}



			else if(cristal != ControlTowerScript.controlTowerScript.cristals&&this.name == "CrstTxt")
			{
					cristal =ControlTowerScript.controlTowerScript.cristals;
					cristalTxt.text = cristal.ToString();
			}
 
	
	}
	

	IEnumerator sizeBoom()
	{
		yield return new  WaitForSeconds(0.05f);
		this.GetComponent<Text>().fontSize+=4;
		yield return new  WaitForSeconds(0.05f);
		this.GetComponent<Text>().fontSize+=4;
		yield return new  WaitForSeconds(0.05f);
		this.GetComponent<Text>().fontSize+=4;

		yield return new  WaitForSeconds(0.05f);
		this.GetComponent<Text>().fontSize-=4;
		yield return new  WaitForSeconds(0.05f);
		this.GetComponent<Text>().fontSize-=4;
		yield return new  WaitForSeconds(0.05f);
		this.GetComponent<Text>().fontSize-=4;


 		StopCoroutine("sizeBoom");
	}

}
