using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {
  

	public Text timeUI;

	float startTime;
	public float ellapsedTime; 
	float reverseTime;
	bool startCounter;

	int minutes;
	int seconds;

	[SerializeField]
	private int CountTime=100;
	
	GameObject EggSideImg;
  void Awake() { 
	  
		EggSideImg = GameObject.FindGameObjectWithTag("Egg_SideImg").gameObject;		

 	}


	void Start () {
		startCounter = false;
		timeUI =GetComponent<Text>();
		StartTimeCounter();
 
//					TimeBar.currentTime = 0;

	 EggSideImg.transform.Find("EggTimeBar").GetComponent<Bar_EggTimeScript>().MaxTimeValue = CountTime;

	}

	public void StartTimeCounter(){

		startTime = Time.time;
		startCounter = true;
 
	} 


	public void StopTimeCounter(){
		startCounter=false;

	}
	

	[SerializeField]
	private int eggNumber =1;

	void FixedUpdate () {

        if(Input.GetKeyDown("h"))
        {
            
          //  Debug.Log( reverseTime );
        }

		if(true){

			

			eggNumber = EggSideImg.GetComponent<Egg_SideImgScript>().eggSelectedNumb;
			
			if(eggNumber<6)
			ellapsedTime =  (EggSideImg.GetComponent<Egg_SideImgScript>().eggExp[eggNumber]);
			reverseTime = CountTime - ellapsedTime;
			
//	Debug.Log("TimeCounter_FixedUpdate"+ eggNumber +ellapsedTime);
		//	 = ellapsedTime;
			minutes = (int)reverseTime / 60;
			seconds = (int)reverseTime % 60 ;

			this.GetComponent<Text>().text= string.Format("{0:00}:{1:00}",minutes,seconds);
		//	timeUI.text = reverseTime.ToString();
			
			if( reverseTime <= 0)
			{						this.GetComponent<Text>().text= string.Format("{0:00}:{1:00}",00,00);

			StopTimeCounter();
			}
		}
	}



}

	

