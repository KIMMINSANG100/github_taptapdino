using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class MapSave : MonoBehaviour {

public static MapSave instance;


	public bool loaded;


	public int SceneNumber;
	public int BattleLevelNumber;

	/*
	SceneNumber
	0. preloader
	1. main
	2. BattleSelect
	3. BattleScene
	4. getCristal


	*/

////////

	public float coins;

	public int cristals;



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

//맵설정
	public int[] map;





 void Awake(){

 }


void Start(){
}
 
 
 


	public void Save( 

	 )
	{						
		if(!Directory.Exists(Application.persistentDataPath + "/savefolder"))
			Directory.CreateDirectory (Application.persistentDataPath + "/savefolder");
		 
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/savefolder/SaveMap.dat");
 
	//savedata
	SaveMap data		= new SaveMap();
	data.childCount		= childCount;
	

	data.dinosSpecies = new int[childCount];


	data.coins		  = coins;
	data.cristals	  = cristals; 

	bf.Serialize( file, data);

		file.Close(); 


	}




	public void Load()
	{
		loaded=true;


		if(!(File.Exists(Application.persistentDataPath+ "/savefolder/SaveMap.dat")))
		{

		}


		if(File.Exists(Application.persistentDataPath+ "/savefolder/SaveMap.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/savefolder/SaveMap.dat", FileMode.Open);
			SaveMap data = (SaveMap)bf.Deserialize(file);
			file.Close();
//캐릭터정보

	coins				=data.coins;
	cristals			=data.cristals;

	bookChar 			= data.bookChar;


	invenNumber			=data.invenNumber;
	thereIsMonster		=data.thereIsMonster;
 
		}
	}
 
/*
		spec = dinosSpecies[i];

		name = dinosName[i];
		dinosLevel[i]			= lv	 	; 
		dinosMaxExp[i]			= maxEx	;
		dinosExp[i]				= Exp	 ;
		dinosTotalExp[i]		= totalEx;


		totalPower[i]			= totP;

		powerLevel[i]			= pow ;
		dinosAdrenalineLv[i]	= adr	;
		criticalRateLv[i]		= crit		 ;
		critPowerLv[i]			= critpow ;
		evolutionNumb[i]		= number;

		autoLv[i]			= auto;

*/		 
	


	public void Delete()
	{
		if(File.Exists(Application.persistentDataPath + "/savefolder/SaveData.dat"))
		{
			File.Delete(Application.persistentDataPath + "/savefolder/SaveData.dat");
		}

	}

	// Update is called once per frame
	void Update () { 
	}


 
}







[System.Serializable]
public class SaveMap
{
	public float coins;
	public int cristals;


	public bool[] bookChar;

//	public List<int> list1 = new List<int>();

	public int[] invenNumber;

	public bool[] thereIsMonster;


	public int[] dinosSpecies;

	public string[] dinosName;
	public int[]	 dinosLevel; 
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
 