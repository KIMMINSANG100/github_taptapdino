using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter_Event : MonoBehaviour {


	public Text timeUI;

	float startTime;
	public float ellapsedTime; 
	float reverseTime;
	bool startCounter;

	int minutes;
	int seconds;
	int hours;

	[SerializeField]
	private int CountTime=100;
	
	GameObject EggSideImg;
  void Awake() { 
	  
 
 	}
float tmpTime;
Button cardButton;
	void Start () { forInitESM();
	}
 
	public void StartTimeCounter(){

		//	startTime = Time.time;
		startTime = EggSpawnManager.Instances.EggTime_MainBonus;
			tmpTime= EggSpawnManager.Instances.EggStaticTime;


		startCounter = true;
 
	} 


	public void StopTimeCounter(){
		startCounter=false;

	}
	

	[SerializeField]
	private int eggNumber =1;

float minusTime;
	void FixedUpdate () {
 
		if(true){
			ellapsedTime = EggSpawnManager.Instances.EggTime_MainBonus ; 


// //	Debug.Log("TimeCounter_FixedUpdate"+ eggNumber +ellapsedTime);
// 		//	 = ellapsedTime;
// 			hours = (int)reverseTime / 3600;
// 			minutes = (int)reverseTime / 60;
// 			seconds = (int)reverseTime % 60 ;

// 		Debug.Log( "hours : " + hours +"min : " + minutes+"sec : " + seconds);
// 			this.GetComponent<Text>().text= hours + "+" + minutes +"+" + seconds .ToString() ;
// 		//	timeUI.text = reverseTime.ToString();
// 						EggSpawnManager.Instances.EggStaticTime = (int)ellapsedTime ;

// 		if(ellapsedTime<=0){
// 			ellapsedTime=0;
// 		if(	transform.parent.parent.GetComponent<Button>().interactable==false)	
// 		transform.parent.parent.GetComponent<Button>().interactable=true;
// 		enabled=false;	
// 		}
// 			if( reverseTime <= 0)
// 			{								this.GetComponent<Text>().text= hours + "+" + minutes +"+" + seconds .ToString() ;


// 			StopTimeCounter();
// 			}
		}
	}



	public void forInitESM()
	{
		minusTime=0;
		CountTime =	(int)	EggSpawnManager.Instances.EggStaticTime ; //시작값
		
		Debug.Log("Count tIme : " + CountTime);
		startCounter = false;
		timeUI =GetComponent<Text>();
		StartTimeCounter();
		
 
//					TimeBar.currentTime = 0;


		transform.parent. GetComponent<Bar_Event>().MaxTimeValue = CountTime; // 맥스값
			ellapsedTime = CountTime; // 표기되는 시간
			tmpTime= EggSpawnManager.Instances.EggStaticTime;
		
	}
}

	

