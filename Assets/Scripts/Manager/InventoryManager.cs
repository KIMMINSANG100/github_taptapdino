using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {


public static InventoryManager Inventory;
////////////////////

//************ 인벤토리 최상위 스크립트
// 이 스크립트는
// 1) 하위에 있는 버튼이 눌리면 그 정보를 CT로부터 받아온다
// 2) 받아온 정보를 왼쪽 창에 띄운다.
// 3) 메인씬에 캐릭터를 생성한다.


// 여기가 인벤토리임 스태틱함수를위해 설정
 
 void Awake(){
	if(Inventory==null)
	{
		DontDestroyOnLoad(transform.gameObject);
		Inventory=this;
	}
	else if(Inventory != this)
	{
		Destroy(Inventory);
	}
				Debug.Log("this is inventory : " + this.name);
	call_invenCoroutine();

 }


	[SerializeField]
	Image[] ImageOfChildBox;





// inven number : 어떤 인벤토리창이 선택되었는지 판별하기위한 변수 / pre는 이전에 선택된 변수

	[SerializeField]
	public int inven_Number ;

	[SerializeField]
	int invenNumberPre;
	
	
///////
	[SerializeField] 
	public int dinosSpecies;
	[SerializeField] 
	public string dinosName;
  /////////////////////
	[SerializeField] 
	public int	 dinosLevel; 
	[SerializeField] 
	public float dinosMaxExp; 
	[SerializeField] 
	public float dinosHp;
	[SerializeField] 
	private float dinosTotalExp;

	[SerializeField] 
	private float dinosExp;
/////////////////////
	[SerializeField] 
	private float totalPower;

    [SerializeField] 
	private float powerLevel;
    [SerializeField] 
	private float adrenalineLv;
    [SerializeField] 
	private float criticalRateLv;
    [SerializeField] 
	private float critPowerLv;
	[SerializeField] 
	private float evolutionNumb;	
	[SerializeField]
	private float autoLv;


	GameObject ControlTower ;

	// Use this for initialization
	
	
	[SerializeField]
	int dinosSpecies_before; 

	void Start () {


		invenInit(); 

	inven_Number= ControlTowerScript.controlTowerScript.invennumberShared;

			Update_DinoStatus();	
		 
			Update_BoxImage(dinosSpecies);

			RegenChar(inven_Number); 
		dinosMaxExp =100 *dinosLevel;

 	}
	
// 확인 inven init : 씬 실행시 CT로부터 인벤토리 화면에 띄울 정보들을 가져오고 띄운다
	public void invenInit()
	{
	// 하위 박스들에 이미지 입력
	
		inven_Number =ControlTowerScript.controlTowerScript.invennumberShared ;

		for(int k = 0 ; k < transform.childCount ; k++)
		{
			ImageOfChildBox[k] =transform.GetChild(k).GetChild(0).GetComponent<Image>();
			//	transform.GetChild(k).GetComponent<Image>()
			
		} 


		for(int k = 0 ; k < transform.childCount ; k++)
		{
		 	
			 if(ControlTowerScript.controlTowerScript.thereIsMonster[k]==true)
			{ 
 				ImageOfChildBox[k].sprite = GetComponent<CharacterBook>().CharacterImage[ControlTowerScript.controlTowerScript.dinosSpecies[k]];
				ImageOfChildBox[k].color = new Color32 (255,255,255,255); 
			}
			else { 
 				ImageOfChildBox[k].sprite = null;
				ImageOfChildBox[k].color = new Color32 (0,0,0,0); 
			}

		}


		Update_BoxImage(dinosSpecies);
		Update_ToLeftImage();
		StartCoroutine(ToLeftImgCorout());

	}

public void dinosBoxImgUpdate()
{
			inven_Number =ControlTowerScript.controlTowerScript.invennumberShared ;

		if (ControlTowerScript.controlTowerScript.thereIsMonster [inven_Number] == true) {
			Update_DinoStatus ();
			int dinoSpriteFromCT = ControlTowerScript.controlTowerScript.dinosSpecies[inven_Number];
			Update_BoxImage (dinoSpriteFromCT);
		} else { 
			this.transform.Find("Inven_Image").GetComponent<Image>().sprite = null; 
			this.transform.Find("Inven_Image").GetComponent<Image>().color = new Color32 (0,0,0,0);
		}


		
	}


	public bool released;

	// Update is called once per fram
	int invenNoGet =0;	


	public void call_invenCoroutine()
	{
		StopCoroutine(coroutineInvenUpdate());
		StartCoroutine(coroutineInvenUpdate());

	}


	IEnumerator coroutineInvenUpdate()
	{
				inven_Number =ControlTowerScript.controlTowerScript.invennumberShared ;

		while(true){
 		if(inven_Number!=invenNumberPre)
		{ 
			Update_DinoStatus();
			Update_BoxImage(dinosSpecies);

			RegenChar(inven_Number); 


		/////////업데이트 되어있을때만
			invenNumberPre=inven_Number;

  		}
		
		if(released)
		{ 
			invenInit();
			released =false;	
		}



		yield return new WaitForSeconds(10f);
		}	

}	 



	public void Update_Character(int charNumber)
	{

	//	inven_Number =ControlTowerScript.controlTowerScript.invennumberShared ;

				ControlTower 	= GameObject.FindGameObjectWithTag("ControlTower").gameObject;
				ControlTower.GetComponent<CharacterInstantiating>().InstantiateCharacter(inven_Number,charNumber);

	}

	public void Update_BoxImage(int charNumber)
	{
		Sprite thisSprite = GetComponent<CharacterBook>().CharacterImage[charNumber];

		// this.transform.Find("Inven_Image").GetComponent<Image>().sprite = thisSprite; 

		// this.transform.Find("Inven_Image").GetComponent<Image>().color = Color.white;

 	//	Invoke("Update_ToLeftImage",0.1f);

	}

	public void Update_Neccesity()
	{
			dinosLevel		= ControlTowerScript.controlTowerScript.dinosLevel[inven_Number];
			dinosTotalExp	= ControlTowerScript.controlTowerScript.dinosTotalExp[inven_Number];
			dinosExp		= ControlTowerScript.controlTowerScript.dinosExp[inven_Number];
			

	}


	IEnumerator ToLeftImgCorout()
	{
		yield return new WaitForSeconds(0.05f);
 		Update_ToLeftImage();
	}


[SerializeField]
GameObject SideImg;


	public void Update_ToLeftImage()
	{ 

		Update_DinoStatus();
		
		
		//GameObject SideImg = GameObject.FindGameObjectWithTag("Inven_SideImage");
		inven_Number= ControlTowerScript.controlTowerScript.invennumberShared;
		SideImg.GetComponent<InvenSideImg>().invenNumber = ControlTowerScript.controlTowerScript.invennumberShared;


		SideImg.GetComponent<SpriteRenderer>().sprite	=	transform.GetChild(inven_Number).Find("Inven_Image").GetComponent<Image>().sprite;

//		SpecCalculator( GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Dino_Individual>().specialChar);
		// spec = GetComponent<SpecScript>().spec[dinosSpecies];
	
		// if(		SideImg.transform.Find("LevelText") != null &&SideImg.transform.Find("InfoText") !=null ){
		// SideImg.transform.Find("LevelText").GetComponent<Text>().text = "LV." +	 dinosLevel.ToString();
		// SideImg.transform.Find("InfoText").GetComponent<Text>().text 
		// = "NAME 	: 	" + dinosName +"\n"+
		//   "POWER 	: 	" + totalPower +"\n"+
		//   "SPEC     : 	" + spec +"\n"+
		//   "EXP 		: 	" + dinosExp + "/" + dinosMaxExp 
		//  .ToString();
		// }
		// 개방버튼
		//////////////	SideImg.transform.Find("ReleaseButton").GetComponent<ReleaseButton>().invenNumber= inven_Number;
 
		if(level!=null)
		{
			GiveNumbersInCampSelect();
 		}


		//캐릭터 instant
		//ControlTower.GetComponent<CharacterInstantiating>().InstantiateCharacter(0,0);				
		 
		//SideImg.transform.localScale

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

	public void GiveNumbersInCampSelect()
	{
		// dinoname.text = dinosName.ToString();
		// level.text = "Lv." + dinosLevel.ToString();
		// hp.text = dinosHp.ToString();
		// atk.text = totalPower.ToString();
		// speed.text = autoLv.ToString();
		// species.text = spec.ToString();
		// exp.text =  dinosExp + "/" + dinosMaxExp .ToString();


		// MapName.text = findMapName(ControlTowerScript.controlTowerScript.mapImg).ToString();
		
		// StageLv.text  = ControlTowerScript.controlTowerScript.battleStageLevel + "/" + 10 .ToString();

		// dinoPower.text = "DinoPower : "+  SumOfDinoPower() .ToString();

		boxColActiveSelf();
	}

	public void boxColActiveSelf()
	{

		StartCoroutine(boxColActive());
	}

	IEnumerator boxColActive()
	{
		yield return new WaitForSeconds(0.04f);


		for(int a=0; a< 30 ; a++){	
			
			if(ControlTowerScript.controlTowerScript.thereIsMonster[a]){
			transform.GetChild(a).GetComponent<BoxCollider2D>().enabled = true;
			transform.GetChild(a).GetChild(0).GetComponent<Image>().color = new Color (1,1,1,1);
			}
		}

		for(int b=0; b< ControlTowerScript.controlTowerScript.battleInv.Length ; b++)
		{

			int k = ControlTowerScript.controlTowerScript.battleInv[b];
			
			if(k<=500){
				transform.GetChild(k).GetComponent<BoxCollider2D>().enabled = false;
				transform.GetChild(k).GetChild(0).GetComponent<Image>().color = new Color (1,1,1,0.6f);
			
			}
			
		}
				StopCoroutine(boxColActive());

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

public string spec;
	void SpecCalculator( int specNumber )
	{
		
			switch(specNumber)
			{
				case 0:
					spec = "woods";
 					break;
				case 1:
					spec = "fire";
 					break; 

				case 2:
					spec = "water";
 					break;
				case 3:
					spec = "elctro";
 					break;
				case 4:
					spec = "wind";
 					break;
				case 5:
					spec = "earth";
 					break;
				case 6:
					spec = "dark";
 					break;
				case 7:
					spec = "light";
 					break;

				case 8:
					spec = "iron";
 					break;

				case 9:
					spec = "ice";
 					break;
			}
		

	}

	public 	void Update_DinoStatus()
	{ 
		
		if(	ControlTowerScript.controlTowerScript.childCount > inven_Number)
		{

			dinosSpecies	= ControlTowerScript.controlTowerScript.dinosSpecies[inven_Number];
			dinosName		= ControlTowerScript.controlTowerScript.dinosName[inven_Number];	
			dinosLevel		= ControlTowerScript.controlTowerScript.dinosLevel[inven_Number];
			dinosHp			= ControlTowerScript.controlTowerScript.dinosHp[inven_Number];


			dinosMaxExp		= ControlTowerScript.controlTowerScript.dinosMaxExp[inven_Number];
			dinosTotalExp	= ControlTowerScript.controlTowerScript.dinosTotalExp[inven_Number];
			dinosExp		= ControlTowerScript.controlTowerScript.dinosExp[inven_Number];
			

			totalPower		= ControlTowerScript.controlTowerScript.totalPower[inven_Number];
			powerLevel		= ControlTowerScript.controlTowerScript.powerLevel[inven_Number];
			adrenalineLv	= ControlTowerScript.controlTowerScript.adrenalineLv[inven_Number];
			criticalRateLv	= ControlTowerScript.controlTowerScript.criticalRateLv[inven_Number];
			critPowerLv		= ControlTowerScript.controlTowerScript.critPowerLv[inven_Number];
			evolutionNumb	= ControlTowerScript.controlTowerScript.evolutionNumb[inven_Number];
		
			autoLv			= ControlTowerScript.controlTowerScript.autoLv[inven_Number];
		}
	
	}



	public void RegenChar(int NumberFromBox)
	{
		
		ControlTowerScript.controlTowerScript.invennumberShared= inven_Number;
//		GameObject.FindGameObjectWithTag("ControlTower").GetComponent<CharacterInstantiating>().InstantiateCharacter(inven_Number, dinosSpecies);
		Update_ToLeftImage();
			//Invoke("Update_ToLeftImage",0.1f);

	}

}

