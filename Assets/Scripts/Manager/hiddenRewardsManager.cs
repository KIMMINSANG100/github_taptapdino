
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class hiddenRewardsManager : MonoBehaviour {
public static hiddenRewardsManager Instances;

	
 void Awake(){ 
	if(Instances==null)
	{
		DontDestroyOnLoad(transform.gameObject);
		Instances=this;
	}
	else if(Instances != this)
	{
		Destroy(Instances.gameObject);
	}	

		LoadRD ();
 
	//Awake 부분 : 데이터로드 안하는 시작시 초기값 설정 
}
	// Use this for initialization
	void Start () {
		sinryuTime=25200;
		buyAuto=false;
		sinRyuEgg=false;
		tegoEgg=false;


		hiddenHurb1018 =false;
		LoadRD();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("x"))
		Delete();
	}
	
	
	
	public bool buyAuto;
	public bool sinRyuEgg;
	public int sinryuTime;
	public bool tegoEgg;
	public bool zinoEgg;
	public bool hiddenHurb1018;



	public bool event_crst;
	public bool event_hurb;
	public bool event_coins;

	public bool hiddenCryst_oncry;	

	public void SaveRD()
	{						//	Debug.Log("dinospecies: "+Species[0]); 
 
	if(!Directory.Exists(Application.persistentDataPath + "/savefolderRD"))
			Directory.CreateDirectory (Application.persistentDataPath + "/savefolderRD");
		 
	BinaryFormatter bf = new BinaryFormatter ();
	FileStream file = File.Create(Application.persistentDataPath + "/savefolderRD/rewardDataSave.dat");
  
	//savedata
	rewardData data = new rewardData();
//캐릭터정보
	data.buyAuto		=	buyAuto ;
   
	data.sinRyuEgg 		=   sinRyuEgg;
	data.sinryuTime  	=   sinryuTime;
	

	data.tegoEgg		=   tegoEgg;
	data.zinoEgg		= 	zinoEgg;



	data.event_crst = event_crst;
	data.event_hurb = event_hurb;
	data.event_coins= event_coins;


	data.hiddenCryst_oncry =  hiddenCryst_oncry;	
	data.hiddenHurb1018 =  hiddenHurb1018;

	


	bf.Serialize( file, data);

		file.Close(); 

		//Debug.Log("powerLevel" + powerLevel);z
				Debug.Log("savedbuyAuto");

	}

 

	public void LoadRD()
	{
	Debug.Log("Loaded");



		if(!(File.Exists(Application.persistentDataPath+ "/savefolderRD/rewardDataSave.dat")))
		{

		}


		if(File.Exists(Application.persistentDataPath+ "/savefolderRD/rewardDataSave.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/savefolderRD/rewardDataSave.dat", FileMode.Open);
			rewardData data = (rewardData)bf.Deserialize(file);
			file.Close();
 

	buyAuto 	= data.buyAuto;
	
	sinRyuEgg	= 	data.sinRyuEgg;
	sinryuTime  =   data.sinryuTime;



	tegoEgg		= 	data.tegoEgg ;
	zinoEgg		=	data.zinoEgg ;


	event_crst	= 	data.event_crst ;
	event_hurb 	=   data.event_hurb;
	event_coins = 	data.event_coins;

	hiddenCryst_oncry =  data.hiddenCryst_oncry;	

	hiddenHurb1018 = data.hiddenHurb1018;


		}
	}
  

	public void Delete()
	{
		if(File.Exists(Application.persistentDataPath + "/savefolderRD/rewardDataSave.dat"))
		{
			File.Delete(Application.persistentDataPath + "/savefolderRD/rewardDataSave.dat");
		}
	}

}


[System.Serializable]
public class rewardData
{
	public bool buyAuto;
 
	public bool sinRyuEgg;
		public int sinryuTime;

	public bool tegoEgg;

	public bool zinoEgg;



	public bool event_crst;
	public bool event_hurb;
	public bool event_coins;

	public bool hiddenCryst_oncry;	
	public bool hiddenHurb1018;

}
 //캐릭터정보