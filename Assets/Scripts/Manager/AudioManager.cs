using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
public static AudioManager audioManager;
	public int bgNumber;
	
	
	public AudioClip[] BGM;
	// Use this for initialization
	public AudioClip BGM_Battle;
	
	
 void Awake(){


	if(audioManager==null)
	{
		DontDestroyOnLoad(transform.gameObject);
		audioManager=this;
	}
	else if(audioManager != this)
	{
		Destroy(audioManager);
	}
 }

	void Start () {		


		mapChange=false;
	
		bgNumber = GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().mapImg;
	
		GetComponent<AudioSource>().clip = BGM[bgNumber];
		//BGON();
	}
	
	public bool mapChange=false;
	

	// Update is called once per frame
	void Update () {
	

	if(mapChange==true)
	{
				Debug.Log("Mapchanged");

		
		bgNumber = ControlTowerScript.controlTowerScript.mapImg;

		BGON();
		if(ControlTowerScript.controlTowerScript.SceneNumber!=2)
		GetComponent<AudioSource>().clip = BGM[bgNumber];
		
		else if(ControlTowerScript.controlTowerScript.SceneNumber==2)
		GetComponent<AudioSource>().clip = BGM_Battle;

		mapChange=false;
	}
		
	}



	
	public void BGON()
	{

//		if(bgNumber != ControlTowerScript.controlTowerScript.mapImg)
		{	bgNumber = ControlTowerScript.controlTowerScript.mapImg;
			GetComponent<AudioSource>().clip = BGM[bgNumber];

			BGOFF();
			StartCoroutine("soundd");
		}
	}
	public void BGOFF()
	{
		StopCoroutine("sounddd");

		GetComponent<AudioSource>().enabled=false;
 	}
	IEnumerator soundd()
	{
		//BGOFF();z
		
 		yield return new WaitForSeconds(0.1f);
		
		GetComponent<AudioSource>().enabled=true;
		
		StartCoroutine("sounddd");
 				StopCoroutine("soundd");		

		}

	IEnumerator sounddd()
	{
//	yield return new WaitForSeconds(0.003f);
//	GetComponent<AudioSource>().Play();

while(true){		
		yield return new WaitForSeconds(95);
		BGOFF();
		yield return new WaitForSeconds(0f);	
		GetComponent<AudioSource>().enabled=true;


}
	}

}
