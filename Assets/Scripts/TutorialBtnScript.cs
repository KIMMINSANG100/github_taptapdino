using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBtnScript : MonoBehaviour {

	[SerializeField]
	Text[] thisTxt;

	[SerializeField]
	GameObject TutClick;

	[SerializeField]
	Tutorial_Dino tutDin;

// 4에서 클릭 등장
// 5번 클릭시 자동으로 넘어가기

// 7이 될때 자동으로 페이드아웃하고 게임넘어가기
	public	int a=0;

	void Start()
	{
		StartCoroutine(starttt());


	}
	public void skipChats()
	{ 
			thisTxt[a].gameObject.SetActive(false);
	 
	 	if(a<=7){
			thisTxt[a+1].gameObject.SetActive(true);
			a++;
		 }
		if(a==5){
		StartCoroutine(tut3());
		StartCoroutine(tut4());
		tutDin.enabled= true;
	
		}
		if(a>=8)
		{
			SubTowerScript.subTowerScript.LoadMain();
			Destroy(this.transform.parent.gameObject);
		}
	}


	IEnumerator starttt()
	{

		yield return new WaitForSeconds(3);

			thisTxt[0].gameObject.SetActive(true);
	  
	}

	IEnumerator tut3()
	{

		yield return new WaitForSeconds(1);

		GameObject	tmp =	Instantiate(TutClick);
		tmp.transform.position = new Vector3 (0,0,0);
	}


	IEnumerator tut4()
	{

		yield return new WaitForSeconds(4);

			thisTxt[a].gameObject.SetActive(false);
	 
			thisTxt[a+1].gameObject.SetActive(true);
			a++;
	}

	[SerializeField]
	bool thatMain=false;

	[SerializeField]
	Vector3 swipe_start;

	[SerializeField]
	Vector3 swipe_end;

	// // Use this for initialization 
 

	// void OnMouseUp()
	// {

	// 	for (int a=0; a< transform.parent.childCount ; a++)
	// 	{
	// 		transform.parent.transform.GetChild(a).GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
	// 		transform.parent.transform.GetChild(a).transform.Find("tutorialDino").gameObject.SetActive(false);
	// 	}

	// 	if(this.name == "1")
	// 	{
			
	// 		GameObject tutorialD = transform.Find("tutorialDino").gameObject;
	// 		tutorialD.SetActive(true);
	// 		tutorialD.gameObject.GetComponent<Animator>().SetTrigger("Attk");
	// 		this. gameObject. GetComponent<SpriteRenderer>().color = new Color32(45,255,255,255);
	// 	}

	// 	if(this.name == "2")
	// 	{
	// 		GameObject tutorialD = transform.Find("tutorialDino").gameObject;
	// 		tutorialD.SetActive(true);
	// 		tutorialD.gameObject.GetComponent<Animator>().SetTrigger("Egg");
	// 		this. gameObject. GetComponent<SpriteRenderer>().color = new Color32(45,255,255,255);
	// 	}

	// 	if(this.name == "3")
	// 	{
	// 		GameObject tutorialD = transform.Find("tutorialDino").gameObject;
	// 		tutorialD.SetActive(true);
	// 		tutorialD.gameObject.GetComponent<Animator>().SetTrigger("Book");
	// 		this. gameObject. GetComponent<SpriteRenderer>().color = new Color32(45,255,255,255);
	// 	}

	// 	if(this.name == "4")
	// 	{
	// 		GameObject tutorialD = transform.Find("tutorialDino").gameObject;
	// 		tutorialD.SetActive(true);
	// 		tutorialD.gameObject.GetComponent<Animator>().SetTrigger("Battle");
	// 		this. gameObject. GetComponent<SpriteRenderer>().color = new Color32(45,255,255,255);
	// 	}

	// 	if(this.name == "5")
	// 	{
	// 		GameObject tutorialD = transform.Find("tutorialDino").gameObject;
	// 		tutorialD.SetActive(true);
	// 		tutorialD.gameObject.GetComponent<Animator>().SetTrigger("Evol");
	// 		this. gameObject. GetComponent<SpriteRenderer>().color = new Color32(45,255,255,255);
	// 	}


	// }
}
