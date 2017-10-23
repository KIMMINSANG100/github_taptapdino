using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Free_Available : MonoBehaviour {

	GameObject ControlTower;
	// Use this for initialization
	void Start () {
		ControlTower = GameObject.FindGameObjectWithTag("ControlTower").gameObject;
		if (this.name == "like" && ControlTower.GetComponent<ControlTowerScript>().like==true) {
			gameObject.transform.Find("CantUse").gameObject.SetActive (true);
			gameObject.GetComponent<Button> ().interactable = false;
		}

		if (this.name == "insta" && ControlTower.GetComponent<ControlTowerScript>().insta==true) {
			gameObject.transform.Find("CantUse").gameObject.SetActive (true);
			gameObject.GetComponent<Button> ().interactable = false;

		}

	}
	
	// Update is called once per frame
	void Update () {  
		
	}

[SerializeField]
string facebookURL;
[SerializeField]
string instaURL;

[SerializeField]
string facebookURL_dino;


[SerializeField]
string oceanWorldUrl;

[SerializeField]
Button thisButton;
[SerializeField]
GameObject cantuse;
	public void OpenFaceBook()
	{


		BtnSounds.instance.ShopBtns();
		ControlTowerScript.controlTowerScript.like = true;
		cantuse.gameObject.SetActive (true);
		thisButton.interactable = false;

		Application.OpenURL(facebookURL);

		BtnReward (100);
	}
	
	
	public void OpenFaceBook_dino()
	{
		
		Application.OpenURL(facebookURL_dino);
	}
	
	public void OpenInsta()
	{

		BtnSounds.instance.ShopBtns();
		ControlTowerScript.controlTowerScript.insta = true;
		cantuse.SetActive (true);
		thisButton.interactable = false;

		Application.OpenURL(instaURL);

		BtnReward (100);
	}
	public void WatchAds()
	{

		AdManager.Instance.ShowVideo();


	}

	
	public void WatchAds_auto()
	{
		EggSpawnManager.Instances.whatAdsTake=1;
		AdManager.Instance.ShowVideo();

 
	}
	public void WatchAds_2times()
	{
		EggSpawnManager.Instances.whatAdsTake=2;
		AdManager.Instance.ShowVideo();


	}
	public void downloadOceanworld()
	{

		Application.OpenURL(oceanWorldUrl);
 
	
	}//별점주러가기!
	IEnumerator showVide()
	{
		GetComponent<Button> ().interactable = false;
		yield return new WaitForSeconds(60f);
		GetComponent<Button> ().interactable = true;
		
	}

	public void Share()
	{

//		AdManager.Instance.ShowVideo();
		BtnReward (20);
	}

	public void BtnReward(int crstReward)
	{
		ControlTowerScript.controlTowerScript.cristals+= crstReward;
	}
	public void mainFacebook()
	{
 		Application.OpenURL(facebookURL);

	}
}
