using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel_BattleScene : MonoBehaviour {

	
	[SerializeField]
	public int mapNumber ;

	[SerializeField]
	int conqueredLevel;

	[SerializeField]
	bool locked = true;

	[SerializeField]
	int mapForStage;
	// Use this for initialization

	Transform opaTrans;
	Button btnOfThis;

	void Start () {

		opaTrans =this.transform.Find("Opa");
		btnOfThis= this.GetComponent<Button>();
//맵 언락 하려면 parent 부터 확인
		if ( this.transform.parent.gameObject.name=="ScrollBar_Map" && ControlTowerScript.controlTowerScript.map[mapNumber]>0)
			{
				locked=false;
				transform.Find("opacity").gameObject.SetActive(false);
			}
	 	conqueredLevel	= ControlTowerScript.controlTowerScript.map[mapNumber];
		  
	}
 
	void Update () { 
		//for()
		mapForStage = ControlTowerScript.controlTowerScript.mapImg;

 		if ( this.transform.parent.gameObject.name=="ScrollBar_Stage"  &&  stageLevel <= ControlTowerScript.controlTowerScript.map[mapForStage])
			locked=false; 


		if(locked==false)
		{
			if(btnOfThis!=null)
			{

				btnOfThis.interactable=true;
			transform.Find("Text").GetComponent<Text>().color = new Color (1,1,1, 1);
				if(transform.Find("Text").Find("Opa")!=null)
				transform.Find("Text").Find("Opa").GetComponent<Image>().color = new Color (1,1,1,1f);
				if(transform.Find("Text_Achiv")!=null)		
				transform.Find("Text_Achiv").GetComponent<Text>().color = new Color (1,1,1, 1);

			}
		}

		else if(locked==true)
		{
			if(btnOfThis!=null)
			{
				btnOfThis.interactable=false;
				transform.Find("Text").GetComponent<Text>().color = new Color (1,1,1, 0.5f);
				if(transform.Find("Text_Achiv")!=null)
				transform.Find("Text_Achiv").GetComponent<Text>().color = new Color (1,1,1, 0.5f);

			}
			
		}	
			 


		if(this.transform.localScale.x<1.3f)
		{
			if(	this.btnOfThis!=null)
		//	this.btnOfThis.enabled=false;
			if(Input.GetKeyDown("y"))
			{Debug.Log("no");}
		}
		else{
		if(	this.btnOfThis!=null)
		this.btnOfThis.enabled=true;
		if(Input.GetKeyDown("y"))
			{Debug.Log("yes");}
		}



	}



[SerializeField]
private int stageLevel;
//mapNumber 는 종류 , mapImg는 다음 씬에서 받을 화면
	public void Send_BattleLevel()
	{
		BtnSounds.instance.Enter();

 		StartCoroutine("blinkBlink");

		ControlTowerScript.controlTowerScript.mapImg = mapNumber;
		//ControlTowerScript.controlTowerScript.LoadBattleStage(mapNumber, stageLevel);
 	} 

	public void Send_StageLevel()
	{
		BtnSounds.instance.Enter();

		StartCoroutine("blinkBlink");

		GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().battleStageLevel = stageLevel;
 

		
	} 

	public void ToStage()
	{
		 SubTowerScript.subTowerScript.LoadSelectCamp();
		// SubTowerScript.subTowerScript.LoadBattleStage();
	}

 
	public void ToMap()
	{
		BtnSounds.instance.Enter();

		GameObject SceneManager = GameObject.FindGameObjectWithTag("SceneManager").gameObject;
		SceneManager.GetComponent<SelectSceneManager>().SelectMap();
	}	
 
	public void StagePanel()
	{
		GameObject SceneManager = GameObject.FindGameObjectWithTag("SceneManager").gameObject;
		SceneManager.GetComponent<SelectSceneManager>().SelectStage();

	}



	[SerializeField]
	private bool blink = false;
	bool blinkBright = false;


[SerializeField]
int numberOfBlink;

[SerializeField]
private float blinkSeconds =0.07f;
	IEnumerator blinkBlink()
	{
		
 		yield return new WaitForSeconds(blinkSeconds);
 
		numberOfBlink++;
			

		if(this.blinkBright==false)
		{		 

			if(opaTrans!=null)
				opaTrans.GetComponent<Image>().color = new Color32 ( 255, 255, 255, 70 );

			else if(opaTrans==null)
				this.transform.Find("Text").transform.Find("Opa").GetComponent<Image>().color = new Color32 ( 169,158, 255, 70 );


			this.blinkBright=true;	
		}

		else if (this.blinkBright==true)
		{
 
 			if(opaTrans!=null)
				opaTrans.GetComponent<Image>().color = new Color32 ( 255, 255, 255, 0 );
			
			else if(opaTrans==null)
				this.transform.Find("Text").transform.Find("Opa").GetComponent<Image>().color = new Color32 ( 255, 255, 255, 0 );
				
			
			this.blinkBright=false;
		}
					StartCoroutine("blinkBlink");
 	
		if(this.transform.parent.gameObject.name=="ScrollBar_Stage")
		{
			if(numberOfBlink==12)			
				{
				GameObject.FindGameObjectWithTag("OtherManager").GetComponent<SpawnLoadingScript>().Loading();
				}
		
		}


	 	if( numberOfBlink>=12 )
		 				{
			///	StopCoroutine("blinkBlink");
 				if(opaTrans!=null)
				 	opaTrans.GetComponent<Image>().color = new Color32 ( 255, 255, 255, 0 );
			
				else if(opaTrans==null)
					this.transform.Find("Text").transform.Find("Opa").GetComponent<Image>().color = new Color32 ( 255, 255, 255, 0 );
				
			

						 if(this.transform.parent.gameObject.name=="ScrollBar_Stage")
						{
							ToStage();
						}


						numberOfBlink=0;
						blinkBright=false;
						StagePanel();
						StopCoroutine("blinkBlink");
						 }

	}


// bg setting add 
	public void selectMap()
	{
  		ControlTowerScript.controlTowerScript.mapImg = GetComponent<SelectLevel_BattleScene>().mapNumber;

 		GameObject.FindGameObjectWithTag("MainSceneManager").GetComponent<MainSceneManager>().selectMap(mapNumber);

		AudioManager.audioManager.BGON();

	}
}
	