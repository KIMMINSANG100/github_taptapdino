using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ExtraFunction : MonoBehaviour {

	// Use this for initialization
	void Start () {
			inShop=false;
	}
	[SerializeField]
	GameObject exitCanvas ;


	public bool inShop;
	public bool camShake;
	// Update is called once per frame 
 
 
	public void camShakeChange()
	{
		if(CamshakeManager.camshakeManager.camShake==true)
		{
				CamshakeManager.camshakeManager.camShake=false;
				transform.Find("OnOff").GetComponent<Text>().text = "Off".ToString();
		}		
		else
		{
				CamshakeManager.camshakeManager.camShake=true;
				transform.Find("OnOff").GetComponent<Text>().text = "On".ToString();
	
		}

	}

	public void GoMainScene_Hatched()
	{
		ControlTowerScript.controlTowerScript.hatched=true;
		
		SpawnLoadingScript.instance.Loading();
 		Invoke("LoadMain",0.1f);

 				ControlTowerScript.controlTowerScript.preSceneNumber=2;
		
		
////알부화시켜오기
		int b=0;
				for(int k=0 ; k < ControlTowerScript.controlTowerScript.dinosSpecies.Length ; k++)
				{
					if(ControlTowerScript.controlTowerScript.thereIsMonster[k]==true)
					b++;	
				}
					ControlTowerScript.controlTowerScript.invennumberShared=b-1;
	}


// 확인 amShakeGoShop() : 샵들어갈때 카메라 흔들림 x
	public void camShakeGoShop()
	{ 
				CamshakeManager.camshakeManager.inShop =true;
	}

// 확인 amShakeGoShop() : 샵들어갈때 카메라 흔들림 x
	public void camShakeOutShop()
	{ 
			CamshakeManager.camshakeManager.inShop =false;
	}


	public void GoMainScene()
	{
		        BtnSounds.instance.Enter();

		SpawnLoadingScript.instance.Loading();
 		Invoke("LoadMain",0.1f);

 				ControlTowerScript.controlTowerScript.preSceneNumber=2;
		System.GC.Collect();

	}

	void LoadMain()
	{
		
		SceneManager.LoadScene("GameMainScene");
        AdManager.Instance.ShowBanner();
		System.GC.Collect();
	}
	public void GoNest()
	{
        BtnSounds.instance.Enter();
		ControlTowerScript.controlTowerScript.preSceneNumber=4;


		SpawnLoadingScript.instance.Loading();
				Invoke("LoadNest",0.1f);
		System.GC.Collect();
	}

	public void LoadNest()
	{
		SceneManager.LoadScene("Nest");
		AdManager.Instance.HideBanner();

	}

	 
	public void GoBook()
	{
		        BtnSounds.instance.Enter();

		SpawnLoadingScript.instance.Loading();
				Invoke("LoadBook",0.1f);
		System.GC.Collect();
 	}
	public void LoadBook()
	{
		SceneManager.LoadScene("Book");
		AdManager.Instance.HideBanner();

	}

	public void GoInventory()
	{
		        BtnSounds.instance.Enter();

		SpawnLoadingScript.instance.Loading();
		Invoke("LoadInventory",0.1f);
		ControlTowerScript.controlTowerScript.preSceneNumber=5;
		AdManager.Instance.HideBanner();
		System.GC.Collect();
	}

	void LoadInventory()
	{

		SceneManager.LoadScene("Inventory");
 
	}
	
	
	
	public void GoSetting()
	{
		        BtnSounds.instance.Enter();

		SpawnLoadingScript.instance.Loading();
		Invoke("LoadSetting",0.1f);
		System.GC.Collect();
 	}	
	
	void LoadSetting()
		{ 
		SceneManager.LoadScene("Setting");
        AdManager.Instance.HideBanner();

	}

	public void GoShop()
	{
			BtnSounds.instance.Enter();
			SpawnLoadingScript.instance.Loading();
			Invoke("LoadShop",0.1f);
			System.GC.Collect();

	}

	void LoadShop()
		{ 
		SceneManager.LoadScene("Shop");
        AdManager.Instance.HideBanner();

	}

	public void Xbtn()
	{
		        BtnSounds.instance.Enter();

				SpawnLoadingScript.instance.Loading();

		if(ControlTowerScript.controlTowerScript.preSceneNumber==4)
			GoNest();
		else if(ControlTowerScript.controlTowerScript.preSceneNumber==5)
			GoInventory();
		else
			GoMainScene();	
			System.GC.Collect();
	}
	// public void Save()
	// {						
	// 	if(!Directory.Exists(Application.persistentDataPath + "/savefolder"))
	// 		Directory.CreateDirectory (Application.persistentDataPath + "/savefolder");
		 
	// 	BinaryFormatter bf = new BinaryFormatter ();
	// 	FileStream file = File.Create(Application.persistentDataPath + "/savefolder/OptionData.dat");
 
	// //savedata
	// OptionData data		= new OptionData();
	// data.camShake =camShake;

	public void ScreenShot()
	{
		UnityEngine.ScreenCapture.CaptureScreenshot("TapTapDino.png");
	}


	// bf.Serialize( file, data);

	// 	file.Close(); 


	[SerializeField]
	Text AutoOnOffTxt;
	public void AutoOnOff()
	{
		bool autoON = ControlTowerScript.controlTowerScript.autoOn;

		if(autoON==true)
		{
			autoON=false;
			AutoOnOffTxt.text = "Auto" + "\n"+"Off".ToString();
		
		}

		else if(autoON==false)
		{
			autoON=true;
			AutoOnOffTxt.text = "Auto" + "\n"+"On".ToString();
		
		}
		
		ControlTowerScript.controlTowerScript.autoOn = autoON;
	}



    public void SaveDinosInfo_Inven()
    {
        //BtnSounds.instance.Enter();

         
        Dino_Individual Player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Dino_Individual>();

        Player.Save_DinoStatus();


    }


    public void Q_Mark()
    {
        transform.Find("Help").gameObject.SetActive(true);
    }

	// }




    public void MapFromHome()
    {
        BtnSounds.instance.Enter();

        AdManager.Instance.HideBanner();

        if (GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("SelectMap") != null)
            GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("SelectMap").gameObject.SetActive(true);

    }


}


[System.Serializable]
public class OptionData
{

	public bool camShake;	
}