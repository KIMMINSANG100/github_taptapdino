using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour {
public int destroyLvTxt=0;


[SerializeField]
private Sprite[] BG;
	// Use this for initialization
	void Start () {
		
		AudioManager.audioManager.mapChange=true;

		int invn = ControlTowerScript.controlTowerScript.invennumberShared;
		GameObject.FindGameObjectWithTag("ControlTower").GetComponent<CharacterInstantiating>().InstantiateCharacter( invn, ControlTowerScript.controlTowerScript.dinosSpecies[invn]);


		ControlTowerScript.controlTowerScript.startToSave();
		Invoke("createOthers",1);

		Invoke("InvoLv",2);
	
		GameObject ControlTower = GameObject.FindGameObjectWithTag ("ControlTower").gameObject;
		ControlTowerScript.controlTowerScript.SceneNumber =1;		
		//ControlTowerScript.controlTowerScript.Load();
 
		for(int i=0; i< ControlTowerScript.controlTowerScript.map.Length ; i++)
			if(ControlTowerScript.controlTowerScript.mapImg ==i)
			{

				if(transform.Find("BackGround")!=null){
					transform.Find("BackGround").GetComponent<SpriteRenderer>().sprite= BG[i];
					if(i==0)
					{
						if(transform.Find("BackGround").transform.Find("Clouds")!=null)
						transform.Find("BackGround").transform.Find("Clouds").gameObject.SetActive(true);
					}
					else if(i==1)
					{
						if(transform.Find("BackGround").transform.Find("Clouds")!=null)
						transform.Find("BackGround").transform.Find("Clouds").gameObject.SetActive(true);
						transform.Find("BackGround").transform.Find("Stars").gameObject.SetActive(true);
					} 
				}
			}

			if(ControlTowerScript.controlTowerScript.hatched==true)
			{
				GiveCharacterName();
			}
		}	

	public void createOthers()
	{
		if(GetComponent<CreateManagers>()!=null)
		GetComponent<CreateManagers>().createAll();
	}
		
	// Update is called once per frame 
	public void selectMap(int i)
	{
 		
		

		{
			transform.Find("BackGround").GetComponent<SpriteRenderer>().sprite= BG[i];
			if(i==0)
			{
 				 transform.Find("Clouds").gameObject.SetActive(true);
			}
			else if(i==1)
			{
 				 transform.Find("Clouds").gameObject.SetActive(true);
				 transform.Find("Stars").gameObject.SetActive(true);
			}

			else if(i==2)
			{	
 				 transform.Find("Clouds").gameObject.SetActive(false);
				 transform.Find("Stars").gameObject.SetActive(false);
			}
			else if(i==3)
			{	
 				 transform.Find("Clouds").gameObject.SetActive(false);
 				 transform.Find("Stars").gameObject.SetActive(true);
			}

		}
	
	}

	public void LoadMain()
	{
		SubTowerScript.subTowerScript.LoadMain();
		
		
	}

	public void LoadTutorial()
	{
		SubTowerScript.subTowerScript.LoadTutorial();	
	}
	public void Loading()
	{
		
		SpawnLoadingScript.instance.Loading();
		
	}

	void InvoLv()
	{
		destroyLvTxt=1;
	}


	public void GiveCharacterName()
	{
		
		 Transform mainCanvasTrans = GameObject.FindGameObjectWithTag("MainCanvas").transform;

		 mainCanvasTrans.Find("NameInputPanel").gameObject.SetActive(true);
		 ControlTowerScript.controlTowerScript.hatched=false;

	}
}
