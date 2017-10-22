using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {
	[SerializeField]
	int coinValue=1;
	[SerializeField]
	GameObject[] tmpObj;
	// Use this for initialization
	void Start () {
		
	}

	void OnMouseDown()
	{
		if(this.name=="Hurb(Clone)"|| this.name=="Hurb")
		{
			ControlTowerScript.controlTowerScript.expHurb+=coinValue;
					

			CombatTextManager.Instance.CreateExpText(transform.position , "+"+coinValue.ToString(), new Color32(0,255,206,255) , true);
 

		}


		if(this.name=="Meat(Clone)"|| this.name=="Meat")
		{
			ControlTowerScript.controlTowerScript.meat+=coinValue;
			CombatTextManager.Instance.CreateExpText(transform.position , "+"+coinValue.ToString(), new Color32(242,113,125,255) , true);
		}


		if(this.name=="Potion(Clone)"|| this.name=="Potion")
		{
			ControlTowerScript.controlTowerScript.potion+=coinValue;
			CombatTextManager.Instance.CreateExpText(transform.position , "+"+coinValue.ToString(), new Color32(203,74,255,255) , true);
		}


		if(this.name=="Cristal(Clone)"|| this.name=="Cristal")
		{
			ControlTowerScript.controlTowerScript.cristals+=coinValue;
			CombatTextManager.Instance.CreateExpText(transform.position , "+"+coinValue.ToString(), new Color32(203,74,255,255) , true);

		}
		if(this.name=="Coins(Clone)"|| this.name=="Coins")
		{
			ControlTowerScript.controlTowerScript.coins+=coinValue;
			CombatTextManager.Instance.CreateExpText(transform.position , "+"+coinValue.ToString(), Color.yellow , true);
		}

		if(this.name=="HelperBox_HelperTeam(Clone)"|| this.name=="HelperBox_HelperTeam")
		{
			
			GameObject tmp = Instantiate (tmpObj[Random.Range(1,tmpObj.Length)]);
			tmp.transform.position = this.transform.position + new Vector3(0,4,0);
			CombatTextManager.Instance.CreateExpText(transform.position , "???" .ToString(), Color.yellow , true);
		}
		if(this.name=="HelperBox_SuperPower(Clone)"|| this.name=="HelperBox_SuperPower")
		{
			GameObject tmp = Instantiate (tmpObj[0]);
			tmp.transform.position = this.transform.position + new Vector3(0,4,0);
			CombatTextManager.Instance.CreateExpText(transform.position , "???" .ToString(), Color.yellow , true);
		}
		
					Destroy(gameObject);

	}

	// Update is called once per frame
	void Update () {
		
	}
}
