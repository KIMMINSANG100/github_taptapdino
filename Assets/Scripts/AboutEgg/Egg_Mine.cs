	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_Mine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		 EggSideImg = GameObject.FindGameObjectWithTag("Egg_SideImg");
 		
		 EggImageUpdate();
	}
		
	// Update is called once per frame
	void Update () {
		
	}

GameObject EggSideImg;

[SerializeField]
int thisEggNumb;

[SerializeField]
private GameObject thisParticle;
	void OnMouseDown()
	{
		if(GetComponent<SpriteRenderer>().sprite!=null)
		{
			
			//알 흔들
			GetComponent<Animator>().SetTrigger("EggShake");
			//번호 전송
			EggSideImg.GetComponent<Egg_SideImgScript>().eggSelectedNumb = thisEggNumb;
 


			//이미지 전송
			EggSideImg.GetComponent<SpriteRenderer>().sprite
			= GetComponent<SpriteRenderer>().sprite;


			EggSideImg.GetComponent<SpriteRenderer>().color
			= Color.white;
			//

			EggSideImg.transform.Find("EggTimeBar").gameObject.SetActive(true);
			EggSideImg.transform.Find("EggTimeBar").GetComponent<Bar_EggTimeScript>().ifItWasFirst =0;

			//알 번호 전송
//			EggSideImg.GetComponent<SpriteRenderer>().


			//클릭 파티클 위치
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			GameObject tmp = Instantiate(thisParticle);
			tmp.transform.position = MousePos + new Vector3 ( 0,0,10);


		}

	}


public void EggImageUpdate()
	{

			if(ControlTowerScript.controlTowerScript.eggSpot[thisEggNumb]==true)
			{
				ControlTowerScript.controlTowerScript.Update_EggSpotInfo(thisEggNumb, ControlTowerScript.controlTowerScript.eggSpecies[thisEggNumb]);
			}
	}
}
