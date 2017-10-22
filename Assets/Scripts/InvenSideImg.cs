using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSideImg : MonoBehaviour {

[SerializeField]
GameObject Inventory;

[SerializeField]
SpriteRenderer thisSprite;


[SerializeField]
Text levelTxt;

[SerializeField]
Text InfoTxt;
	public int invenNumber;


	ControlTowerScript CT;
	// Use this for initialization
	void Start () {
				int theseNumber = ControlTowerScript.controlTowerScript.invennumberShared;
				thisSprite.sprite	=	Inventory.transform.GetChild(theseNumber).Find("Inven_Image").GetComponent<Image>().sprite;

	CT = ControlTowerScript.controlTowerScript;
	


			StartCoroutine(SideImgUpdate());
	}
	
	// Update is called once per frame

	IEnumerator SideImgUpdate()
	{
		while(true)
		{

			int theseNumber = CT.invennumberShared;
 
				thisSprite.sprite	=	Inventory.transform.GetChild(theseNumber).Find("Inven_Image").GetComponent<Image>().sprite;
 
		string	spec = GetComponent<SpecScript>().spec[CT.dinosSpecies[theseNumber]];

		if(level==null){
		levelTxt.text = "LV." +	 CT.dinosLevel[theseNumber].ToString();
		InfoTxt.text 
		= "NAME 	: 	" + CT.dinosName[theseNumber] +"\n"+
		  "POWER 	: 	" + CT.totalPower[theseNumber] +"\n"+
		  "SPEC     : 	" + spec +"\n"+
		  "EXP 		: 	" + CT.dinosExp[theseNumber] + "/" +CT.dinosMaxExp[theseNumber]
		 .ToString();
		}

		else if (level !=null)
		{
			SideUpdate_Camp();
		}
			yield return new WaitForSeconds(0.1f);


		}
	} 
	public void SideUpdate()
	{

	}



 
 [SerializeField]
 Text dinoname;

[SerializeField]
 Text level;
 [SerializeField]
 Text hp;
 
 [SerializeField]
 Text atk;
 
 [SerializeField]
 Text speed;
 
 [SerializeField]
 Text species;
 
 [SerializeField]
 Text exp;

 [SerializeField]
 Text StageLv;

 [SerializeField]
 Text MapName;
 [SerializeField]
 Text dinoPower;
	public void SideUpdate_Camp()
	{
			int theseNumber = CT.invennumberShared;
		string	spec = GetComponent<SpecScript>().spec[CT.dinosSpecies[theseNumber]];

		
		dinoname.text = CT.dinosName[theseNumber].ToString();
		level.text = "Lv." + CT.dinosLevel[theseNumber].ToString();
		hp.text = CT.dinosHp[theseNumber].ToString();
		atk.text = CT.totalPower[theseNumber].ToString();
		speed.text = "updating".ToString();
		species.text = spec.ToString();
		exp.text =  CT.dinosExp[theseNumber] + "/" + CT.dinosMaxExp[theseNumber] .ToString();


		MapName.text = findMapName(ControlTowerScript.controlTowerScript.mapImg).ToString();
		
		StageLv.text  = ControlTowerScript.controlTowerScript.battleStageLevel + "/" + 10 .ToString();

		dinoPower.text = "DinoPower : "+  SumOfDinoPower() .ToString();
	}
		string findMapName(int mapNumber)
	{
		switch (mapNumber)
		{
			case 0: return "Dawn"; 
			case 1: return "Night";
			case 2: return "Forest";
			case 3: return "Ice";
			case 41: return "PinkSnow";
			case 5: return "Space";
			

			default:
			return "NoNamed";
		}

	}

	int SumOfDinoPower()
	{
		return ControlTowerScript.controlTowerScript.DefenseDinoPower();
	}
}