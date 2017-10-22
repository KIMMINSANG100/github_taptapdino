using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Products_Available : MonoBehaviour {

	// Use this for initialization

	GameObject ControlTower;

	Text thisPrice ;
	double price_Coin;
	double price_Crst;

	double myCoin;
	double myCrst;


	[SerializeField]
	public string eggSpec;

	int eggSpecNumber;

	Button btnOfThis;
	void Start () {

		btnOfThis = GetComponent<Button>();

		if(eggSpec=="sinryu"&&hiddenRewardsManager.Instances.sinRyuEgg==true)
			Destroy(gameObject);


		if(eggSpec=="zino"&&hiddenRewardsManager.Instances.zinoEgg==true || ControlTowerScript.controlTowerScript.sumOfPowers >300)
			btnOfThis.interactable=false ;


		if(eggSpec=="tego"&&hiddenRewardsManager.Instances.tegoEgg==true || ControlTowerScript.controlTowerScript.sumOfPowers <400)
			btnOfThis.interactable=false ;



				ControlTower = GameObject.FindGameObjectWithTag("ControlTower").gameObject;		


		if(this.name =="autoAtk")
		{

			
			
			int k= (int)ControlTowerScript.controlTowerScript.publicAutoLv;
			
			if(k<29)
			{
				double price = 100*((double)Mathf.Pow(2,(k-1)));

				float time = Mathf.Round((3- k*0.1f )*100)/100;
				float nexttime = Mathf.Round((3- (k+1)*0.1f)*100)/100 ;

				this.transform.Find("Cost_Coin").GetComponent<Text>().text = price.ToString();
				this.transform.Find("CONTENT").GetComponent<Text>().text = "LEVEL " + k.ToString();			
				this.transform.Find("display").GetComponent<Text>().text = " now :  each " + time + " s ".ToString();
				this.transform.Find("display_n").GetComponent<Text>().text = " next : each " + nexttime + " s ".ToString();
				if (ControlTowerScript.controlTowerScript.language == 1) {
					this.transform.Find("display").GetComponent<Text>().text = " 현재 : " + time + " 초마다 공격 ".ToString();
					this.transform.Find("display_n").GetComponent<Text>().text = " 다음 : " + nexttime + " 초마다 공격".ToString();

				}

			}

			else
			{
				float time = Mathf.Round((3- k*0.1f )*100)/100;

				this.transform.Find("Cost_Coin").GetComponent<Text>().text = " x ".ToString();
				if (ControlTowerScript.controlTowerScript.language == 1) {
					this.transform.Find("Cost_Coin").GetComponent<Text>().text = " 만렙 ".ToString();
 
				}
				this.transform.Find("CONTENT").GetComponent<Text>().text = "LEVEL " + k.ToString();

				this.transform.Find("display").GetComponent<Text>().text = " Max lv: each" + time + " s ".ToString();
				this.transform.Find("display_n").GetComponent<Text>().text = "  ".ToString();

				this.btnOfThis.interactable= false;
				transform.Find("CantUse").gameObject.SetActive((true));
				this.GetComponent<IfBtnClicked>().gameObject.SetActive(false);
			}
		ControlTowerScript.controlTowerScript.Save();

		}


		
		if(transform.Find("Cost_Coin")!=null)
			{
				thisPrice = transform.Find("Cost_Coin").GetComponent<Text>();
				price_Coin = double.Parse(thisPrice.text);
			}
		if(transform.Find("Cost_Crst")!=null)
			{
				thisPrice = transform.Find("Cost_Crst").GetComponent<Text>();
				price_Crst =  double.Parse(thisPrice.text);
			}
		
 		myCoin = ControlTowerScript.controlTowerScript.coins;
		myCrst = ControlTowerScript.controlTowerScript.cristals;


		
	//	call_productCorout();
	}
	

	public void call_productCorout()
	{
		StopCoroutine("productCorout");
		StartCoroutine("productCorout");
	}
	
	// Update is called once per frame
	

void Update(){
//////////////////코인 과 크리스탈이 충분한지 판단
///////////가격은 하위 오브젝트 이름이 Cost_Coin에 text에 기입되어있음


		if(transform.Find("Cost_Coin")!=null)
		{		
			myCoin = ControlTowerScript.controlTowerScript.coins;

			if(price_Coin>myCoin )
			{
				this.btnOfThis.interactable= false;
				transform.Find("CantUse").gameObject.SetActive((true));
				price_Coin = int.Parse(thisPrice.text);
			}
			else
			{
					
				this.btnOfThis.interactable= true;
				transform.Find("CantUse").gameObject.SetActive((false));
			

			}

			if(this.name=="buycristal"&&EggSpawnManager.Instances.canbuyCrystal==false)
			{btnOfThis.interactable=false;
				Debug.Log("xx"+ btnOfThis.interactable );

				transform.Find("CantUse").gameObject.SetActive((true));
			}
		}


		if(transform.Find("Cost_Crst")!=null)
		{
		myCrst = ControlTowerScript.controlTowerScript.cristals;

			if(price_Crst>myCrst){
				this.btnOfThis.interactable= false;
				transform.Find("CantUse").gameObject.SetActive((true));
				price_Crst = int.Parse(thisPrice.text);
			}

			else
			{
				this.btnOfThis.interactable= true;
				transform.Find("CantUse").gameObject.SetActive((false));
			

			}
		}
/////////////////////////	///////////////이벤트 카드란 ( 조건 )	

//	yield return new WaitForSeconds(0.02f);


	}

 // price , egg number 

 // to alarm
	public void BuyThis()
	{

		BtnSounds.instance.ShopBtns();

		if(transform.Find("Cost_Coin")!=null)
			{
				price_Crst =  double.Parse(thisPrice.text);
				thisPrice = transform.Find("Cost_Coin").GetComponent<Text>();

				ControlTowerScript.controlTowerScript.coins -= price_Coin ;	
				Increase_Item();
				StartCoroutine(BeBig());				
				}
		if(transform.Find("Cost_Crst")!=null)
			{
				thisPrice = transform.Find("Cost_Crst").GetComponent<Text>();

				price_Crst =  double.Parse(thisPrice.text);

				ControlTowerScript.controlTowerScript.cristals -= price_Crst ;
		 		Increase_Item();
				 StartCoroutine(BeBig());	
			}
		 
	}

	public void BuyEggsAlarm()
	{

		if(transform.Find("Cost_Coin")!=null)
			{ 
				StartCoroutine(BeBig());				
			}
		if(transform.Find("Cost_Crst")!=null)
			{ 
				 StartCoroutine(BeBig());	
			}
	}

	public void BuyEggs()
	{

		BtnSounds.instance.ShopBtns();
			int k = 0;

			GameObject ControlTower = GameObject.FindGameObjectWithTag("ControlTower").gameObject; 
					for(int a=0 ; a <5 ; a++)
					{
						// 칸이 안차있으면
						if(ControlTowerScript.controlTowerScript.eggSpot[a]==false && k==0)
						{
							k++;
 						
							if(transform.Find("Cost_Coin")!=null)
								{
									Alarm_Buy_Yes();
								 StartCoroutine(BeBig());	

								}
							if(transform.Find("Cost_Crst")!=null)
								{
									Alarm_Buy_Yes();
  								 StartCoroutine(BeBig());	

								}
							if(eggSpec=="sinryu"||eggSpec!="tego" ||eggSpec!="zino" )
							{

									Alarm_Buy_Yes();
  								 StartCoroutine(BeBig());		
								   btnOfThis.interactable= false;
							}

						}		



					// 알 칸이 차있으면
						else 

						{
							int c=0 ;
 							for(int b=0 ; b <5 ; b++)
							{			
								if(ControlTowerScript.controlTowerScript.eggSpot[b]==true)
								c++;
							}
									if(c==5)
										Alarm_EggFull();
						}
				}

	}

 


	public void Increase_Item()
	{
		if(this.gameObject.name == "meat")
		{
			ControlTowerScript.controlTowerScript.meat++;
		}

		if(this.gameObject.name == "potion")
		{
			ControlTowerScript.controlTowerScript.potion++;
		}

		if(this.gameObject.name == "exp_hurb")
		{
			ControlTowerScript.controlTowerScript.expHurb++;
		}

		if(this.gameObject.name == "buycristal")
		{
			ControlTowerScript.controlTowerScript.cristals+=1200;
		}
		if(this.gameObject.name == "buygold")
		{
			ControlTowerScript.controlTowerScript.coins+=1000000;
		}


		if(this.gameObject.name == "autoAtk")
		{

			if(hiddenRewardsManager.Instances.buyAuto ==false || ControlTowerScript.controlTowerScript.publicAutoLv >=27 )
			{
			
			ControlTowerScript.controlTowerScript.publicAutoLv++;

			}


int k= (int)ControlTowerScript.controlTowerScript.publicAutoLv;
			
			if(k<29){
				ControlTowerScript.controlTowerScript.AutoAtkUpgrade();
				
				double price = 100*((double)Mathf.Pow(2,(k-1)));
				
				this.transform.Find("Cost_Coin").GetComponent<Text>().text = price.ToString();
				this.transform.Find("CONTENT").GetComponent<Text>().text = "LEVEL " + k.ToString();
				
				//GameObject.FindGameObjectWithTag("Dino").GetComponent<Dino_Individual>().autoLv++;
								
				float time = Mathf.Round((3- k*0.1f )*100)/100;
				float nexttime = Mathf.Round((3- (k+1)*0.1f)*100)/100 ;
				this.transform.Find("display").GetComponent<Text>().text = " now :  each " + time + " s ".ToString();
				this.transform.Find("display_n").GetComponent<Text>().text = " next : each " + nexttime + " s ".ToString();


				if (ControlTower.GetComponent<ControlTowerScript> ().language == 1) {
					this.transform.Find("display").GetComponent<Text>().text = " 현재 : " + time + " 초마다 공격 ".ToString();
					this.transform.Find("display_n").GetComponent<Text>().text = " 다음 : " + nexttime + " 초마다 공격".ToString();

				}

			
				thisPrice = transform.Find("Cost_Coin").GetComponent<Text>();
				price_Coin = double.Parse(thisPrice.text);
			}

			else
			{
				float time = Mathf.Round((3- k*0.1f )*100)/100;

				this.transform.Find("Cost_Coin").GetComponent<Text>().text = " x ".ToString();
				this.transform.Find("CONTENT").GetComponent<Text>().text = "LEVEL " + k.ToString();
				
				this.transform.Find("display").GetComponent<Text>().text = " Max lv: each" + time + " s ".ToString();
				this.transform.Find("display_n").GetComponent<Text>().text = "  ".ToString();

				this.btnOfThis.interactable= false;
				transform.Find("CantUse").gameObject.SetActive((true));
				this.GetComponent<IfBtnClicked>().gameObject.SetActive(false);
			}
			ControlTowerScript.controlTowerScript.Save();
 

		if(GameObject.FindGameObjectWithTag("Player")!=null){
      	  Dino_Individual Player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Dino_Individual>();
       	 Player.Save_DinoStatus();
			}
		}
	
// update : egg Add : 알 추가

	//알 판매
		if(this.gameObject.name== "egg")
		{
 
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

				case "random" :
					int randEggNumb = Random.Range(1,9);
					eggSpecNumber = randEggNumb;
					break;
				//case "dark" :
				//	eggSpecNumber = 10;
				//	break;
			}

 					for(int a=0 ; a <5 ; a++)
					{
						if(ControlTowerScript.controlTowerScript.eggSpot[a]==false && k==0)
						{
							k++;
							// egg 부화시키기
							ControlTowerScript.controlTowerScript.Update_Eggs(a,true,eggSpecNumber,0);
 

						}		

						else 
						{
							int c=0 ;
 							for(int b=0 ; b <5 ; b++)
							{			
								if(ControlTowerScript.controlTowerScript.eggSpot[b]==true)
								c++;
							}
									if(c==5)
										Alarm_EggFull();
						}
				}
	
		}
	}




	public void Alarm_Buy_Yes()
	{

		GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera").gameObject;

		GameObject Alarm = 	Cam.transform.Find("NoticeCanvas").Find("Alarm").gameObject;
		Alarm.SetActive(true);
		Alarm.transform.Find("yes").gameObject.SetActive(true);

		GameObject AlarmText = GameObject.FindGameObjectWithTag("AlarmText").gameObject;
		
		AlarmText.transform.parent.GetComponent<Animator>().SetTrigger("Alarm");
		
		AlarmText.GetComponent<Text>().text =  "Buy This Egg?".ToString(); //------------------------------------<글씨

		if (ControlTower.GetComponent<ControlTowerScript> ().language == 1) {

			AlarmText.GetComponent<Text>().text =  "알을 구매하시겠습니까?".ToString();  
		}

		Alarm.transform.Find("yes").GetComponent<BuyEgg>().eggSpec=eggSpec;



		if(transform.Find("Cost_Crst")!=null)
			Alarm.transform.Find("yes").GetComponent<BuyEgg>().crst = (int) price_Crst;
		
		else if(transform.Find("Cost_Coin")!=null)
			Alarm.transform.Find("yes").GetComponent<BuyEgg>().coin = (int) price_Coin ;

		
		
	}


	public void CallBuy()
	{

	}
	



	public void Alarm_EggFull()
	{

		GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera").gameObject;

		Cam.transform.Find("NoticeCanvas").transform.Find("Alarm").gameObject.SetActive(true);
		
		GameObject AlarmText = GameObject.FindGameObjectWithTag("AlarmText").gameObject;
		
		AlarmText.transform.parent.GetComponent<Animator>().SetTrigger("Alarm");
		
		AlarmText.GetComponent<Text>().text =  "it's full".ToString();
	}	


	IEnumerator BeSmall()
	{
		yield return new WaitForSeconds(0.001f);
		
		this.transform.localScale -= new Vector3 (1f,1f,1f) *0.1f;

		if(this.transform.localScale.x >1)
		StartCoroutine(BeSmall());
		else
		{
		this.transform.localScale = new Vector3(1,1,1);
		StopCoroutine(BeBig());
		StopCoroutine(BeSmall());

		}
	}
	
	IEnumerator BeBig()
	{
		yield return new WaitForSeconds(0.001f);
		
		this.transform.localScale += new Vector3 (1f,1f,1f) *0.1f;

		if(this.transform.localScale.x <1.1)
		StartCoroutine(BeBig());
		else
		{
		StartCoroutine(BeSmall());
		}
	}

}
	