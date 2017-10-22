using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour {

	public bool paused;
	
	[SerializeField]
	Sprite[] buttonImg;
	// Use this for initialization
	void Start () {
		
		paused = false;

		
	}
	
	// Update is called once per frame
	void Update () {
 

	}


	public void Pause()
	{


 		paused = !paused;
		

		if(paused)
		{
			Time.timeScale = 0;
			this.GetComponent<Image>().sprite = buttonImg[1];
			transform.parent.transform.Find("PauseBlock").gameObject.SetActive(true);
			transform.Find("HomeBtn").gameObject.SetActive(true);
			transform.Find("SideBtn").gameObject.SetActive(false);

		
		}
		else if(!paused)
		{
			this.GetComponent<Image>().sprite = buttonImg[0];
			Time.timeScale = 1;
			transform.parent.transform.Find("PauseBlock").gameObject.SetActive(false);

						transform.Find("HomeBtn").gameObject.SetActive(false);
						transform.Find("SideBtn").gameObject.SetActive(true);

		}
		
	}

	public void Home()
	{	Time.timeScale = 1;
		SubTowerScript.subTowerScript.LoadMain();
			GameObject.FindGameObjectWithTag("OtherManager").GetComponent<SpawnLoadingScript>().Loading();

	}

	public void MoveSideTrue()
	{

		paused = !paused;
		

		if(paused)
		{

		BtnSounds.instance.Enter();
 			//this.GetComponent<Image>().color =  new ;
			//transform.parent.transform.FindChild("PauseBlock").gameObject.SetActive(true);
			transform.Find("Right").gameObject.SetActive(true);
			transform.Find("Left").gameObject.SetActive(true);

		
		}
		else if(!paused)
		{

		BtnSounds.instance.Enter();
			//this.GetComponent<Image>().sprite = buttonImg[0];
		//	Time.timeScale = 1;
		//	transform.parent.transform.FindChild("PauseBlock").gameObject.SetActive(false);

			transform.Find("Right").gameObject.SetActive(false);
			transform.Find("Left").gameObject.SetActive(false);

		}
	}


		public void AutoOnOff()
	{

		paused = !paused;
		

		if(paused)
		{	
		BtnSounds.instance.Enter();
			
			transform.Find("Text").GetComponent<Text>().text ="Auto" +"\n" +"On".ToString();

			GameObject[] Dinos = GameObject.FindGameObjectsWithTag("Dino");

 			for(int a= 0; a < Dinos.Length ; a++)
			{
				if(Dinos[a].gameObject.GetComponent<Dino_Individual>()!=null){
				Dinos[a].gameObject.GetComponent<Dino_Individual>().autoOnOff=true;
			
				}
			}
		
		}
		else if(!paused)
		{

		BtnSounds.instance.Enter();
			transform.Find("Text").GetComponent<Text>().text ="Auto" +"\n" +"Off".ToString();

			GameObject[] Dinos = GameObject.FindGameObjectsWithTag("Dino");

  			for(int a= 0; a < Dinos.Length ; a++)
			{
				if(Dinos[a].gameObject.GetComponent<Dino_Individual>()!=null){
				Dinos[a].gameObject.GetComponent<Dino_Individual>().CancelAuto();
				Dinos[a].gameObject.GetComponent<Dino_Individual>().autoOnOff=false;

				}
			}
		}
	}
}
