using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfBtnClicked2 : MonoBehaviour {

string originalStr ;
	// Use this for initialization
	void Start () {
		if(this.GetComponent<Text>()!=null)
		originalStr = this.GetComponent<Text>().text;
	}
	
	// Update is called once per frame
	void Update () {

		if(this.name == "TotalPlayingTime")
		{
			GetComponent<Text>().text = originalStr +((int)GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().playTime + "  Seconds" ).ToString();
			
		}
		if(this.name == "TotalTapTimes")
		{
			GetComponent<Text>().text = originalStr +((int)GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().totalMouseClick + "  Times" ).ToString();
		}


		if(this.name == "Smashed")
		{
			GetComponent<Text>().text = originalStr +((int)GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().smashed  ).ToString();
		}


		if(this.name == "DinoPower")
		{
			GetComponent<Text>().text = originalStr +((int)GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().sumOfPowers ).ToString();
 		}


		if(this.name=="Right" || this.name=="Left" ){
		moveToSide();


		if(Input.GetMouseButtonUp(0))	
			{
			move=false;	
			this.GetComponent<Image>().color = new Color32 ( 199,248,255,152);

			}
		}
	}

	void OnMouseDown()
	{
		move=true;
	}
	
	bool move;
    public void moveToSide()
    {
		if(move==true){
			GameObject MainCam= GameObject.FindGameObjectWithTag("MainCamera").gameObject;

			this.GetComponent<Image>().color = new Color32 ( 199,248,255,255);
			if(this.name=="Right")
			MainCam.transform.position += new Vector3(15,0)*Time.deltaTime;

			if(this.name=="Left")
			MainCam.transform.position += new Vector3(-15,0)*Time.deltaTime;
		}
    }

}
