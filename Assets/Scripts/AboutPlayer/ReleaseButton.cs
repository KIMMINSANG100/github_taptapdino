using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReleaseButton : MonoBehaviour {
	public int invenNumber;
	// Use this for initialization 
	// Update is called once per frame
	void Update () {
		invenNumber=InventoryManager.Inventory.inven_Number;
		if (invenNumber == 0) {
			GetComponent<Button> ().interactable = false;
		}
		else 
			if (invenNumber != 0) {
				GetComponent<Button> ().interactable = true;
			}

	}

	public void releaseChar()
	{
		GameObject ControlTower = GameObject.FindGameObjectWithTag("ControlTower").gameObject;

		int totalDinosNumber = ControlTower.GetComponent<CharacterInstantiating> ().invenNumber;


		for(int a= invenNumber ; a< totalDinosNumber-1 ; a++)
		{

			ControlTowerScript.controlTowerScript.dinosSpecies[a] = ControlTowerScript.controlTowerScript.dinosSpecies[a+1] ;
			ControlTowerScript.controlTowerScript.dinosName[a] = ControlTowerScript.controlTowerScript.dinosName[a+1];	
			ControlTowerScript.controlTowerScript.dinosLevel[a]=ControlTowerScript.controlTowerScript.dinosLevel[a+1];

			ControlTowerScript.controlTowerScript.dinosMaxExp[a]=	ControlTowerScript.controlTowerScript.dinosMaxExp[a+1];
			ControlTowerScript.controlTowerScript.dinosTotalExp[a]=ControlTowerScript.controlTowerScript.dinosTotalExp[a+1];
			ControlTowerScript.controlTowerScript.dinosExp[a]=ControlTowerScript.controlTowerScript.dinosExp[a+1];


			ControlTowerScript.controlTowerScript.totalPower[a]=ControlTowerScript.controlTowerScript.totalPower[a+1];
			ControlTowerScript.controlTowerScript.powerLevel[a]=ControlTowerScript.controlTowerScript.powerLevel[a+1];
			ControlTowerScript.controlTowerScript.adrenalineLv[a]=ControlTowerScript.controlTowerScript.adrenalineLv[a+1];
			ControlTowerScript.controlTowerScript.criticalRateLv[a]=ControlTowerScript.controlTowerScript.criticalRateLv[a+1];
			ControlTowerScript.controlTowerScript.critPowerLv[a]=ControlTowerScript.controlTowerScript.critPowerLv[a+1];
			ControlTowerScript.controlTowerScript.evolutionNumb[a]=ControlTowerScript.controlTowerScript.evolutionNumb[a+1];

			ControlTowerScript.controlTowerScript.autoLv[a]=ControlTowerScript.controlTowerScript.autoLv[a+1] ;
		}
			


		ControlTowerScript.controlTowerScript.invenNumber[totalDinosNumber-1]=0;
		ControlTowerScript.controlTowerScript.thereIsMonster[totalDinosNumber-1]=false;
		ControlTowerScript.controlTowerScript.invennumberShared--;		
		ControlTower.GetComponent<CharacterInstantiating> ().invenNumber --;

		int invNum = ControlTower.GetComponent<CharacterInstantiating> ().invenNumber - 1; 

		Invoke ("updateBoxImg", 0.2f);
	}


	void updateBoxImg()
	{

		GameObject ControlTower	= GameObject.FindGameObjectWithTag("ControlTower").gameObject;

		GameObject boxes = GameObject.FindGameObjectWithTag ("InventoryBoxes").gameObject;

 //////변형중
 			InventoryManager.Inventory.released=true;
	
		Invoke ("updateLBox", 0.9f);
	}

	void updateLBox()
	{
		GameObject ControlTower = GameObject.FindGameObjectWithTag("ControlTower").gameObject;

		GameObject boxes = GameObject.FindGameObjectWithTag ("InventoryBoxes").gameObject;

		int invNum = ControlTower.GetComponent<CharacterInstantiating> ().invenNumber; 
 
	} 
	public void ReleaseButtonActive()
	{	

		transform.Find ("PopUp_Release").gameObject.SetActive (true);
		transform.Find("PopUp_Release").Find("ReleaseButton").gameObject.GetComponent<ReleaseButton> ().invenNumber = 	invenNumber ; 
	}
	public void ReleaseButtonActiveFalse()
	{
		transform.parent.gameObject.SetActive (false);
	}
}
