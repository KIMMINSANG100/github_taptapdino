using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventItemCardScript : MonoBehaviour {

	string eggSpec;
	Button btnOfThis;
	// Use this for initialization
	void Start () {
		eggSpec = GetComponent<Products_Available>().eggSpec;
		btnOfThis = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.Find("Cost_Crst")==null&&transform.Find("Cost_Coin")==null)
		{
			if(eggSpec!="sinryu" || eggSpec!="tego" || eggSpec!="zino"  )
			{							
				if(	this.btnOfThis!=null)
				this.btnOfThis.interactable= true;
			}
		

			if(eggSpec=="sinryu")
				{
					Debug.Log("sinryu");
					if(hiddenRewardsManager.Instances.sinRyuEgg==true || ControlTowerScript.controlTowerScript.bookChar[75]==true || hiddenRewardsManager.Instances.sinryuTime >2)
					{
						btnOfThis.interactable=false ;
						Debug.Log("abcde");
					}
					else
					{
						btnOfThis.interactable=true ;
						Debug.Log("ghiij");
					}
				}
			if(eggSpec=="zino")
				{
					if((hiddenRewardsManager.Instances.zinoEgg==true || ControlTowerScript.controlTowerScript.sumOfPowers >300))
					{
					btnOfThis.interactable=false ;
					}else
					btnOfThis.interactable=true ;
					}

			if(eggSpec=="tego")
			{
				if((hiddenRewardsManager.Instances.tegoEgg==true || ControlTowerScript.controlTowerScript.sumOfPowers <400))
				{	Debug.Log("tego");
					
					btnOfThis.interactable=false ;
				}
				else
					btnOfThis.interactable=true ;
			}
 
		}
	}
}
