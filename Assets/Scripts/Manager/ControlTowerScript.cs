using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ControlTowerScript : MonoBehaviour {

public static ControlTowerScript controlTowerScript;

[SerializeField]
int[] battleInv_pre;
public void updateCampPos(){ 

	if(battleInv[sharedCampPosNumber]<500)	
		sharedCampPosNumber++; 

	if(sharedCampPosNumber>= campPos.Length)
		sharedCampPosNumber=campPos.Length-1;


}
	public bool autoOn; 
///
	public int sharedCampPosNumber;
	public int campNumber;
	public int[] campPos;
	public int[] battleInv;
	public int campDinoNumber;

//////
	public int lastDay;

	public int language;
	public int dayGift;

	//0.english 1. korean 2. japanese. 3. french. 4.hindi

	public bool serviceCrst;
	public bool like;
	public bool insta;
	public bool starterpack;

	public bool loaded;

	public double totalMouseClick;


	public double playTime;
	public double smashed;

	public int SceneNumber;
	public int[] map;

/*
		BattleLevelNumber >0 면 bool locked= false;
		0부터 레벨 설정 


*/


	/*
	SceneNumber
	0. preloader
	1. main
	2. Battle
	3. BattleSelect
	4. getCristal
	7. shop

	*/

////////

	public double coins;

	public double cristals;


	public float sumOfPowers;

	public bool[] bookChar;


	public int childCount;
	public int childCount_Before;



	public int[] invenNumber;
	public bool[] thereIsMonster;
///////////////////////


	public int[] dinosSpecies;
 
	public string[] dinosName;
 
  /////////////////////
	public int[]	 dinosLevel; 
	public int[]	dinosHp;
	public float[] dinosMaxExp;
	public float[] dinosTotalExp;

	public float[] dinosExp;
/////////////////////
	public float[] totalPower;

    public float[] powerLevel;
    public float[] adrenalineLv;
    public float[] criticalRateLv;
    public float[] critPowerLv;
	public float[] evolutionNumb;
////////////////////
	public float[] autoLv;

	public float publicAutoLv;





	public int eggBoxNumber;

	public bool[]	eggSpot ;
//	public int[] eggNumber;
	public int[] eggSpecies;
	public float[]	eggExp;


[SerializeField]
	private Sprite[] EggImages;

//public List<int> list1 = new List<int>();

	// Use this for initialization

////////////// ====================ITEM 
	public int meat;
	public int potion;
	public int expHurb;
	public int aura;
	
	public int randomBox;
	
	
	public int Fairy;

////*********************///

	public int Crst_Battle;
	public int Coin_Battle;
	public int Exp_Battle; 



	public int invennumberShared;

	////////////////////////////////////////저장안하는변수들
	public int selectedDinoNumber;
	public int preSceneNumber;

	public bool hatched;

	//
 void Awake(){
	 campDinoNumber=6;
	 //campPos = new int[campDinoNumber];
	 battleInv = new int[campDinoNumber];
	for(int f=0; f<battleInv.Length ; f++)
	{
		battleInv[f] = 1000;
	}


	if(controlTowerScript==null)
	{
		DontDestroyOnLoad(transform.gameObject);
		controlTowerScript=this;
	}
	else if(controlTowerScript != this)
	{
		Destroy(controlTowerScript);
	}


	thereIsMonster = new bool[30];

			for(int i = 0 ; i <30 ; i++)
			{
				thereIsMonster[i]=false;
			}
		thereIsMonster[0] = true;

		serviceCrst=false;
		like = false;
		insta = false;
		starterpack = false;

	childCount=30;

	invenNumber			= new int[childCount];
 
	dinosSpecies		= new int[childCount];

 	dinosName			= new string[childCount];
	dinosLevel			= new int[childCount]	 ; 
	dinosHp				= new int[childCount];
	dinosMaxExp			= new float[childCount];
	dinosExp			= new float[childCount] ;
	dinosTotalExp		= new float[childCount];


	totalPower			= new float[childCount];

	powerLevel			= new float[childCount] ;
	adrenalineLv	= new float[childCount];
	criticalRateLv		= new float[childCount]		 ;
	critPowerLv			= new float[childCount] ;
	evolutionNumb		= new float[childCount]	 ;

	autoLv				= new float[childCount];
	

	eggBoxNumber= 5;	

	eggSpot		=	new bool[eggBoxNumber];
//	eggNumber	=	new int[5];
	eggSpecies	=	new int[eggBoxNumber];
	eggExp		=	new float[eggBoxNumber];



	map = new int[10];

	map[0]=1;

//Awake 부분 : 데이터로드 안하는 시작시 초기값 설정
	Update_Coins(0,0);
	Update_Name(0, 0	, "Gino");
	Update_DinoStats(0,1,1,1,1);
	Update_Exp(0, 1, 0, 100, 0);
	Update_AutoAttk(0,1);
	Update_Eggs(0,false,0,0);

	TotalPower(0);

	childCount_Before = childCount;
	publicAutoLv=1;
	cristals = 500;
	expHurb = 2;
	smashed = 0;

	Load();

Debug.Log("AwakeCT");
	
 }




void Start(){ 
	selectedDinoNumber=0;
	sumOfPowers=0;
	Load();
	
Debug.Log("startCT");
	
bool[] tmpBookChar = bookChar;

bookChar = new bool [120];

for(int f=0 ; f< tmpBookChar.Length ; f++ )
{
	bookChar[f] = tmpBookChar[f];
}

int[] tmpDinosHp= dinosHp;

dinosHp= new int[childCount];
for(int f=0 ; f< dinosHp.Length; f++ )
{
	dinosHp[f] = tmpDinosHp[f];
}


		saveTime = playTime;
	for(int a=0 ; a<5 ; a++)
	{
		Update_EggSpotInfo(a, eggSpecies[a]);
	}



	for(int i = 0 ;  i< thereIsMonster.Length ; i++)
	{
			if(thereIsMonster[i] ==true) //알이미지 비교
			{
  
				GetComponent<CharacterInstantiating>().invenNumber= i+1;
				

	
			}
		}

		StartCoroutine("COROUTINEUPDATE");

}
 

 


 	public void Update_Coins(float coins_input , int cristals_input)
	 {
		 coins = coins_input;
		 cristals = cristals_input;
	 }

	
	public void Update_Name( int i, int Species_input ,string Name_input)
	{
		invenNumber[i] = i;
		
		dinosSpecies[i] = Species_input;
		dinosName[i] = Name_input;


	}

	

	public void Update_Exp( int i, int Level, float Exp, float MaxExp, float TotalExp)
	{
		dinosLevel[i]  = Level;

		dinosExp[i] 	= Exp;

		dinosMaxExp[i]	= MaxExp;

		dinosTotalExp[i]= TotalExp;
	}


	 public void Update_DinoStats(int i,float pow, float adr, float crit, float critpow)
	 {
		 powerLevel[i] 			= pow;
		 adrenalineLv[i]	= adr;
		 criticalRateLv[i]		= crit;
		 critPowerLv[i]			= critpow;		 
		 TotalPower(i);
	 }

	 public void Update_AutoAttk(int i, float ato)
	 {
		 autoLv[i] = ato;

		 
		 
	 }
	
	public int DefenseDinoPower()
	{
		int sumOfDefensPow=0;
		for(int a=0; a < campPos.Length ; a++)
		{
			if(battleInv[a]<500)
			{
				sumOfDefensPow+=(int)totalPower[battleInv[a]];
			}
		}	

		return sumOfDefensPow;
		Debug.Log("DefPower : " + sumOfDefensPow);
	}

	 public void AutoAtkUpgrade()
	 {

		if (GameObject.FindGameObjectWithTag("InventoryBoxes")!=null){
		Transform invenBoxesTrans = GameObject.FindGameObjectWithTag("InventoryBoxes").transform;

			for(int i =0; i<invenBoxesTrans.childCount ; i++)
			{

				if(thereIsMonster[i]==true)
					autoLv[i] = publicAutoLv;
			}	
	 	}

		 InvenBoxesUpdate();
	 }	



	void TotalPower(int i)
	{
		if(sumOfPowers!=0)
		totalPower[i] = Mathf.Round((10*powerLevel[i])*((adrenalineLv[i]*5/100)+1));

	}
	
	void Update_whenEvolution()
	{
		GameObject playingMonster = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;

		playingMonster.GetComponent<Dino_Individual>().Update_DinoStatus();
		
	}
 
 
 

	 public void Update_Eggs(int i, bool Spot, int Species, float Exp )
	 {
		 

		eggSpot[i]			=Spot;
//		eggNumber[i]		=Number;
		eggSpecies[i]		=Species;
		eggExp[i]			=Exp;

		Update_EggSpotInfo(i, Species);
		
	 }


	 public void Update_EggSpotInfo(int i, int spec)
	 {
		 if(eggSpot[i]==true &&  GameObject.FindGameObjectWithTag("Nest")!=null)
		 {
			Transform EggSpot_i = GameObject.FindGameObjectWithTag("Nest").transform.Find("Nest_Circle").transform;

			EggSpot_i.GetChild(i).GetComponent<SpriteRenderer>().sprite = EggImages[spec];
			EggSpot_i.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;

			

		 } 

	 }
 	 public void Update_Maps(int mapNumber)
	 {
		 
		 map[mapNumber] = 1;
 
	 }

	 public void Update_Maps_Level(int mapNumber, int mapLevel)
	 {
		 map[mapNumber] = mapLevel;
 	 }


	 public void Update_Maps_Stage(int mapNumber, int mapLevel)
	 {
	 if(map[mapNumber]>10)
	 {
		 map[mapNumber]=10;
	 }


	 }


// update : egg Add : 알 추가
[SerializeField]
int whatKindOfEggs =10 ;

	public void EggCompareToInstantiate(Sprite EggImg, int invenNumber)
	{	if (invenNumber >= 29) {		
			for (int inv = 29; inv > 0; inv--) {	
				if (ControlTowerScript.controlTowerScript.thereIsMonster[inv] == false)
					invenNumber = inv;
			}
		}

		whatKindOfEggs = EggImages.Length;
		for(int eggNumber = 0 ;  eggNumber < whatKindOfEggs ; eggNumber++)
		{
			if(EggImg ==EggImages[eggNumber]) //알이미지 비교
			{
 
				this.GetComponent<CharacterInstantiating>().InstantiateCharacter_Egg(invenNumber, eggNumber);

				thereIsMonster[invenNumber] = true;
  
			}
		}

		Debug.Log("hatched");

	}

	 public void Start_EggExp(int i)
	 {

		 
			eggExp[i] += Time.deltaTime;
		 
	 }



	 public void Egg_Load()
	 {
		 for(int a=0 ; a <4 ; a++)
				{
					if(GetComponent<ControlTowerScript>().eggSpot[a]!=false  )
					{ 
						 
						Update_Eggs(a, eggSpot[a], eggSpecies[a], eggExp[a] );
						
					}		


				}
	 }


	public void InvenBoxesUpdate()
	{


		if (GameObject.FindGameObjectWithTag("InventoryBoxes")!=null){
		Transform invenBoxesTrans = GameObject.FindGameObjectWithTag("InventoryBoxes").transform;

		for(int i =0; i<invenBoxesTrans.childCount ; i++)
		{

			if(thereIsMonster[i]==true)
			invenBoxesTrans.GetChild(i).GetComponent<InventoryManager>(). Update_BoxImage(dinosSpecies[i]);//////변형중


			if(invenBoxesTrans.GetChild(i).gameObject.transform.GetChild(0). GetComponent<Image>().sprite!=null)
			{	
 				invenBoxesTrans.GetChild(i).GetComponent<InventoryManager>().Update_DinoStatus();//////변형중

				invenBoxesTrans.GetChild(i).GetComponent<InventoryManager>().Update_BoxImage(dinosSpecies[i]);
 			}	
		}	
		}
	}


//SAVE();
	public void Save()
	{						
		Debug.Log("saved");
		hiddenRewardsManager.Instances.SaveRD();		
		EggSpawnManager.Instances.SaveEggSpawn();


		if(!Directory.Exists(Application.persistentDataPath + "/savefolder"))
			Directory.CreateDirectory (Application.persistentDataPath + "/savefolder");
		 
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/savefolder/SaveData.dat");
 
		//savedata
		SaveData data		= new SaveData();
		

		data.language = language;

		data.dayGift = dayGift;

		data.serviceCrst = serviceCrst;
		data.like = like;
		data.insta = insta;
		data.starterpack = starterpack;

		data.playTime		= playTime;
		data.totalMouseClick = totalMouseClick;
		data.smashed	= smashed;

		data.childCount		= childCount;
	

		data.dinosSpecies = new int[childCount];

		
		data.coins		  = coins;
		data.cristals	  = cristals;

		data.bookChar 	  = bookChar;


		data.invenNumber  = invenNumber;
		data.thereIsMonster= thereIsMonster;



		data.dinosSpecies =	dinosSpecies;


		data.dinosName 		= dinosName;
		data.dinosLevel		= dinosLevel; 
		data.dinosHp		= dinosHp;
		data.dinosMaxExp	= dinosMaxExp;
		data.dinosExp		= dinosExp;
		data.dinosTotalExp 	= dinosTotalExp;


		data.totalPower = totalPower;

		data.powerLevel			= powerLevel;
		data.dinosAdrenalineLv	= adrenalineLv;
		data.criticalRateLv		= criticalRateLv;
		data.critPowerLv		= critPowerLv;

		data.evolutionNumb		= evolutionNumb;
		
		data.autoLv				= autoLv;
		data.publicAutoLv 		= publicAutoLv;

		data.childCount			= childCount;




		data.eggSpot 		= 	eggSpot;
		data.eggSpecies		=	eggSpecies;
		data.eggExp			=	eggExp;

	///여기까지 공룡정보

		// Use this for initialization

		////////////// ====================ITEM 
		data.meat 			= meat;
		data.potion			= potion;
		data.expHurb		= expHurb;
		data.aura			= aura;
		
		data.randomBox		= randomBox;

		data.Fairy			= Fairy;

	////*********************///

	//맵설정
		data.map			= map;



	


	bf.Serialize( file, data);

		file.Close(); 


	}


//LOAD();
	public void Load()
	{
		loaded=true;


		if(!(File.Exists(Application.persistentDataPath+ "/savefolder/SaveData.dat")))
		{

		}


		if(File.Exists(Application.persistentDataPath+ "/savefolder/SaveData.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/savefolder/SaveData.dat", FileMode.Open);
			SaveData data = (SaveData)bf.Deserialize(file);
			file.Close();
	//캐릭터정보


	language  = data.language;

	dayGift	  = data.dayGift;


	serviceCrst = data.serviceCrst;
	like = data.like;
	insta = data.insta;
	starterpack = data.starterpack;

	playTime			= data.playTime;
	totalMouseClick 	= data.totalMouseClick ;
	smashed 			= data.smashed;


	coins				=data.coins;
	cristals			=data.cristals;

	bookChar 			= data.bookChar;


	invenNumber			=data.invenNumber;
	thereIsMonster		=data.thereIsMonster;



	dinosSpecies		=data.dinosSpecies;

 	dinosName			=data.dinosName	;
	dinosLevel			=data.dinosLevel;
	dinosHp				=data.dinosHp	 ; 
	dinosMaxExp			=data.dinosMaxExp;
	dinosExp			=data.dinosExp	 ;
	dinosTotalExp		=data.dinosTotalExp;


	totalPower			=data.totalPower;


	powerLevel			=data.powerLevel		;
	adrenalineLv		=data.dinosAdrenalineLv	;
	criticalRateLv		=data.criticalRateLv	;
	critPowerLv			=data.critPowerLv		;
	evolutionNumb		=data.evolutionNumb		;

	autoLv				=data.autoLv;
	publicAutoLv		=data.publicAutoLv;
	childCount 			=data.childCount;



	eggSpot		=	data.eggSpot;
	//	eggNumber	=	data.eggNumber;
	eggSpecies	=	data.eggSpecies;
	eggExp		=	data.eggExp;



////////////// ====================ITEM 
	meat 			= data.meat;
	potion			= data.potion;
	expHurb			= data.expHurb;
	aura			= data.aura;
	
	randomBox		= data.randomBox;

	Fairy			= data.Fairy;

	////*********************///

	//맵설정
		map			= data.map;

	/*
			eggSpot 
			eggNumber
			eggSpecies
			eggStat
	*/
	///여기까지 공룡정보


//
InvenBoxesUpdate();

			Debug.Log("Loaded");

		}
	} 
	public void Delete()
	{
		if(File.Exists(Application.persistentDataPath + "/savefolder/SaveData.dat"))
		{
			File.Delete(Application.persistentDataPath + "/savefolder/SaveData.dat");
		}

	}




public void startToSave()
{		StopCoroutine("SaveAll");
		StartCoroutine("SaveAll");
}
IEnumerator SaveAll()
{
	while(true){
	yield return new WaitForSeconds(10);
	Save(); 

	if(GameObject.FindGameObjectWithTag("Player")!=null)
	if(GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.tag =="Dino"){
        Dino_Individual Player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Dino_Individual>();
        Player.Save_DinoStatus();

		Debug.Log("need save");
				}
	}
	
}







int countGameForAds=0;

float sumOfpow=0;
	double saveTime;
	// Update is called once per frame
	///////////////


IEnumerator COROUTINEUPDATE()
{
		

		if (countGameForAds >=2) 
		{	
			
			//GameObject.FindGameObjectWithTag("OtherManager").GetComponent<AdManager>().ShowVideo_interstitial ();
			countGameForAds = 0;
		}
 
 		for(int i = 0 ; i < eggBoxNumber ; i++)
		{
		 if(eggSpot[i]==true)
			Start_EggExp(i);

			
		 else
		 	eggExp[i] =0;
		}



	yield return new WaitForSeconds(5f);

}
 void Update() {
 

 // crystal, coin error
	 if(coins<0)
	 coins =0;
	 if(cristals<0)
	 cristals=0;


	if(publicAutoLv>30)
		publicAutoLv=10;

// egg exp
		for(int i = 0 ; i < eggBoxNumber ; i++)
		{
		 if(eggSpot[i]==true)
			Start_EggExp(i);

			
		 else
		 	eggExp[i] =0;
		}


//click count
	if(Input.GetMouseButtonDown(0)){
			totalMouseClick ++;
			
			}




		
//sum of power
			for(int i = 0 ; i <30 ; i++)
			{
				if(thereIsMonster[i]==true)
				sumOfpow+=totalPower[i];
			}


			sumOfPowers = sumOfpow;
			sumOfpow=0;
			



	if(Input.GetKeyDown("x")){
		Delete();
		Debug.Log("deleted");
		}

 



	if(Input.GetKeyDown("q")){

		SceneManager.LoadScene("GameMainScene");
		}


	if(Input.GetKeyDown("w")){

		SceneManager.LoadScene("SelectCamp");
		}

 


	playTime+= Time.deltaTime;

 }



[SerializeField]
int testCristal=40;
[SerializeField]
int testCoin=50;


[SerializeField]
public int battleStageLevel;
[SerializeField]
public int mapImg;
 	public void BattleReward()
	{

		coins += Coin_Battle;
		cristals += Crst_Battle;		
		
	
		for(int i =0; i<thereIsMonster.Length ; i++)
			{

				if(thereIsMonster[i]==true)
					dinosExp[i] +=Exp_Battle;
			}	
		Coin_Battle=0;
		Crst_Battle=0;
		Exp_Battle=0;
		countGameForAds++;
	}






}







[System.Serializable]
public class SaveData
{

	public int language;
	public int dayGift;

	public bool serviceCrst;
	public bool like;
	public bool insta;
	public bool starterpack;

	public double playTime;
	public double totalMouseClick;
	public double smashed;

	public double coins;
	public double cristals;


	public bool[] bookChar;

//	public List<int> list1 = new List<int>();

	public int[] invenNumber;

	public bool[] thereIsMonster;


	public int[] dinosSpecies;

	public string[] dinosName;
	public int[]	 dinosLevel; 
	public int[]	dinosHp;	
	public float[]	dinosMaxExp;
	public float[] dinosExp;

	public float[] dinosTotalExp;



	public float[] totalPower;

    public float[] powerLevel;
    public float[] dinosAdrenalineLv;
    public float[] criticalRateLv;
    public float[] critPowerLv;
	public float[] 	evolutionNumb;

	public float[] autoLv;
	public float publicAutoLv;


	public int childCount;




	public int eggBoxNumber;

	public bool[] eggSpot;
//	public int[] eggNumber;
	public int[] eggSpecies;
	public float[] eggExp;




	// Use this for initialization

////////////// ====================ITEM 
	public int meat;
	public int potion;
	public int expHurb;
	public int aura;
	
	public int randomBox;

	public int Fairy;

////*********************///

//맵설정
	public int[] map;



//------------------
 


public int currentAttack_Level;


public	 float currentPercent_Level ;

public float currentCritical_Level;


public float growthRate;	

public int chCount;

public int chCount_pre;

public int charIndex;
 

public int[] dinosEvolved;

public int[] dinosEvolvedSave;

//level 불러오기
//public int[] dinosLevel;


}
 