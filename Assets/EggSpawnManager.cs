
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class EggSpawnManager : MonoBehaviour {

public static EggSpawnManager Instances;

	
 void Awake(){ 
	 		initEventValues();

	if(Instances==null)
	{
		DontDestroyOnLoad(transform.gameObject);
		Instances=this;
	}
	else if(Instances != this)
	{
		Destroy(Instances.gameObject);
	}	

		LoadEggSpawn ();
 
	//Awake 부분 : 데이터로드 안하는 시작시 초기값 설정 
}
	// Use this for initialization
	void Start () {
  		//EggTime_MainBonus=0;
		LoadEggSpawn();
	}
	





	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("x"))
		Delete();

		canbuyCrystal_time+=Time.deltaTime;
		if(canbuyCrystal_time>=18000)
		canbuyCrystal=true;
		else
		canbuyCrystal=false;



		//////////////

		if(true){
			
//			minusTime+=Time.deltaTime;
			
			EggTime_MainBonus -=Time.deltaTime; // 표기되는 시간
			
 			

			if(EggTime_MainBonus>=0){
			
			
			
			
			}
			else
			EggTime_MainBonus = 0 ;

		}

			managing2Times_adreward();
			managingAuto_adreward();
	}

	void initEventValues() //광고관련 초기값 설정
	{
		ad5mAtk2times_left = adRW_2timesStart;
		ad10mAuto_left = 600;
		whatAdsTake =0;
		}


	void managing2Times_adreward()// 두배공격 관리
	{

		if(ad5mAtk2times==true)
		{
			ad5mAtk2times_left-=Time.deltaTime;
		
			if(ad5mAtk2times_left<=0)
			{
				ad5mAtk2times_left=adRW_2timesStart;
				ad5mAtk2times=false;
			}
		
		}
	}

	void managingAuto_adreward() // 오토공격 관리
	{
		if(ad10mAuto==true)
		{
			ControlTowerScript.controlTowerScript.autoOn=true;

			ad10mAuto_left-=Time.deltaTime;
		
			if(ad10mAuto_left<=0)
			{
				ad10mAuto_left=adRW_2timesStart*2;
				ad10mAuto=false;
			}
		
		}
	}


	public float minusTime;
	public float ellapsedTime;
	
	
	
	public float EggTime_MainBonus;
	public float EggStaticTime;

	public int EggOrder;
/////

	public bool canbuyCrystal;
	
	public float canbuyCrystal_time;
	
	float canbuyCrystalNorm;
/////////

	
	public bool ad10mAuto;
	public float ad10mAuto_left;

	public bool ad5mAtk2times;
	public float ad5mAtk2times_left;

	public int whatAdsTake;
[SerializeField] float adRW_2timesStart=180;

	[SerializeField]
	GameObject randomEgg;
	public void GotEgg_ChangeTime()
	{
	
		EggOrder++;
		int a = UnityEngine.Random.Range(0,4);
		
		if(a==0 || a==1 || a==2)
		{
			GameObject tmp = Instantiate(randomEgg);
			tmp.transform.position = new Vector3(0,0,0);
			//egg instant
		}

		else if( a==3)
		{
			ControlTowerScript.controlTowerScript.cristals+=100;

		}
		else
		{
			ControlTowerScript.controlTowerScript.expHurb+=5;

		}

		int b = UnityEngine.Random.Range(0,5);

		if(b==0)
		{
			EggStaticTime=1200;
		}
		else if( b==1)
		{
			EggStaticTime =1500;
		}
		else if(b==2)
		{
			EggStaticTime =800;
		}
		else if(b==3)
		{
			EggStaticTime =2100;
		}
		else if(b==4)
		{
			EggStaticTime = 600;
		}
		else if(b==5)
		{
			EggStaticTime = 1800;
		}

		EggTime_MainBonus=EggStaticTime;
	}





	public void SaveEggSpawn()
	{						//	Debug.Log("dinospecies: "+Species[0]); 
 
	if(!Directory.Exists(Application.persistentDataPath + "/savefolderEgg"))
			Directory.CreateDirectory (Application.persistentDataPath + "/savefolderEgg");
		 
	BinaryFormatter bf = new BinaryFormatter ();
	FileStream file = File.Create(Application.persistentDataPath + "/savefolderEgg/EggDataSave.dat");
  
	//savedata
	EggSpawnData data = new EggSpawnData();
//캐릭터정보
			data.EggTime_MainBonus		=	EggTime_MainBonus ;
    
			data.EggStaticTime 			=	EggStaticTime;
			data.EggOrder	 			=	EggOrder;

	

			data.canbuyCrystal 			=canbuyCrystal;
			data.canbuyCrystal_time		=canbuyCrystal_time;


			data.ad10mAuto 				=	ad10mAuto;
			data.ad10mAuto_left			=	ad10mAuto_left;
			data.ad10mAtk2times			=	ad5mAtk2times;
			data.ad10mAtk2times_left	=	ad5mAtk2times_left;
	
	bf.Serialize( file, data);

		file.Close(); 

		//Debug.Log("powerLevel" + powerLevel);z
				Debug.Log("EggoSave");

	}

 

	public void LoadEggSpawn()
	{
	Debug.Log("EggLoaded");



		if(!(File.Exists(Application.persistentDataPath+ "/savefolderEgg/EggDataSave.dat")))
		{

		}


		if(File.Exists(Application.persistentDataPath+ "/savefolderEgg/EggDataSave.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/savefolderEgg/EggDataSave.dat", FileMode.Open);
			EggSpawnData data = (EggSpawnData)bf.Deserialize(file);
			file.Close();
			
			
			EggTime_MainBonus		=	data.EggTime_MainBonus ;
			EggStaticTime 			=	data.EggStaticTime;
			EggOrder	 			=	data.EggOrder;





			canbuyCrystal 			=data.canbuyCrystal;
			canbuyCrystal_time		=data.canbuyCrystal_time;



			//

			
			ad10mAuto 			= 	data.ad10mAuto;
			ad10mAuto_left		=	data.ad10mAuto_left;
			ad5mAtk2times		=	data.ad10mAtk2times;
			ad5mAtk2times_left	=	data.ad10mAtk2times_left;
		}
	}
  

	public void Delete()
	{
		if(File.Exists(Application.persistentDataPath + "/savefolderEgg/EggDataSave.dat"))
		{
			File.Delete(Application.persistentDataPath + "/savefolderEgg/EggDataSave.dat");
		}
	}

}





[System.Serializable]
public class EggSpawnData
{
	public float EggTime_MainBonus;

	public float EggStaticTime;

	public int EggOrder;



	public bool canbuyCrystal;
	
	public float canbuyCrystal_time;



	public bool ad10mAuto;
	public float ad10mAuto_left;
	public bool ad10mAtk2times;
	public float ad10mAtk2times_left;
	
	}
 //캐릭터정보