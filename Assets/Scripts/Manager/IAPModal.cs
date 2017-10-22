using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class IAPModal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject ControlTower = GameObject.FindGameObjectWithTag("ControlTower").gameObject; 
		if (ControlTower.GetComponent<ControlTowerScript> ().starterpack == true && this.name == "Hot_Deal_Starter") 
		{
 			gameObject.GetComponent<Button>().enabled=(false); 
			gameObject.transform.Find("CantUse").gameObject.SetActive (true);
			 
				
		}


 		if (hiddenRewardsManager.Instances.buyAuto == true && this.name == "Hot_Deal_AutoLv") 
		{
 			gameObject.GetComponent<Button>().enabled=(false); 
			gameObject.transform.Find("CantUse").gameObject.SetActive (true);
			 
				
		}
			
	}
	
	// Update is called once per frame 

	
		public void PRODUCT_CRST30000(){

			BtnSounds.instance.ShopBtns();

	 		IAPManager.Instance.Buy30000Crst();
 		}



		public void PRODUCT_CRST80(){

			BtnSounds.instance.ShopBtns();

	 		IAPManager.Instance.Buy80Crst();
 		}
		public void PRODUCT_CRST500(){

			BtnSounds.instance.ShopBtns();

	 		IAPManager.Instance.Buy500Crst();

		}
		public void PRODUCT_CRST1200(){

			BtnSounds.instance.ShopBtns();

 			IAPManager.Instance.Buy1200Crst();
		}
		public void PRODUCT_CRST3000(){

			BtnSounds.instance.ShopBtns();
	 		IAPManager.Instance.Buy3000Crst();
		}
		public void PRODUCT_CRST5000(){
			
			BtnSounds.instance.ShopBtns();
	 		IAPManager.Instance.Buy5000Crst();
		}
		public void PRODUCT_CRST10000(){

			BtnSounds.instance.ShopBtns();
		 	IAPManager.Instance.Buy10000Crst();
		}


//2. 패키지
        public void PRODUCT_STARTER_PACK(){
			
			BuyStarter ();
		//IAPManager.Instance.BuySarterPack();
		}
        public void PRODUCT_EGG_PACK(){
			
			BuyEggPack ();
	//	IAPManager.Instance.BuySarterPack();
		}
	 

        public void PRODUCT_BUY_AUTOATK(){
			
		 	IAPManager.Instance.BuyAutoAttack();
			 			StartCoroutine("buyAutoBought");

	//	IAPManager.Instance.BuySarterPack();
		}
	 
	public void BuyStarter()
	{

		BtnSounds.instance.ShopBtns();
		int k = 0;

		GameObject ControlTower = GameObject.FindGameObjectWithTag("ControlTower").gameObject; 
		for (int a = 0; a < 5; a++) {
			// 칸이 안차있으면
			if (ControlTower.GetComponent<ControlTowerScript> ().eggSpot [a] == true) {
				k++;
			}

		}
		// 있는게 세개이하
		if (k <=3) {

	 		IAPManager.Instance.BuySarterPack();
			StartCoroutine("starterPackBought");
		}

		else
		Alarm_EggFull();

	}


	IEnumerator starterPackBought()
	{

		yield return new WaitForSeconds(0.3f);
		if(ControlTowerScript.controlTowerScript.starterpack==true)
			{
			gameObject.GetComponent<Button>().enabled=(false);			
			gameObject.transform.Find("CantUse").gameObject.SetActive (true);
 			}
		else
			StartCoroutine("starterPackBought");


	}


	IEnumerator buyAutoBought()
	{

		yield return new WaitForSeconds(0.3f);
		if(hiddenRewardsManager.Instances.buyAuto == true)
			{
			gameObject.GetComponent<Button>().enabled=(false);			
			gameObject.transform.Find("CantUse").gameObject.SetActive (true);
 			}
		else
			StartCoroutine("buyAutoBought");


	}

		public void BuyEggPack()
	{

		BtnSounds.instance.ShopBtns();
		int k = 0;

		GameObject ControlTower = GameObject.FindGameObjectWithTag("ControlTower").gameObject; 
		for (int a = 0; a < 5; a++) {
			// 칸이 안차있으면
			if (ControlTower.GetComponent<ControlTowerScript> ().eggSpot [a] == true) {
				k++;
			}

		}
		// 있는게 세개이하
		if (k <=0) {
 	 		IAPManager.Instance.BuyEggsPack();
			gameObject.GetComponent<Button>().enabled=(false);			
			gameObject.transform.Find("CantUse").gameObject.SetActive (true);

		}

		else
		Alarm_EggFull();

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
