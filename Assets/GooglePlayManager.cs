/* 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GooglePlayManager : MonoBehaviour {

	public Text tx_id;
	public Text tx_userName;
	public Text tx_Email;
	//public FaceBookManager fb;

	// Use this for initialization
	void Start () {

		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate();
		LogIn();	
	}
	
	// Update is called once per frame
	public void LogIn() {
		Social.localUser.Authenticate((bool success) =>
		{
			if(success)
			{
				Debug.Log("You've successfully logged in");
				tx_id.text = social.localUser.id;
				tx_userName.text = Social.localUser.userName;
				tx_Email.text = ((PlayGamesPlatform)Social.localUser).Email + "-" + PlayGamesPlatform.Instance.GetUserEmail();
			}
			else
				{
					Debug.Log("Login failed :" +Social.Active);

				}
		GooglePlayManager.OurUtils.PlayGamesHelperObject.RunOnGameThread(
			()=> {
				Debug.Log("local user's email is"+ ((PlayGamesLocalUser)Social.localUser).Email);
					});
		});

		
		}

	public void LogOut()
	{
		((PlayGamesPlatform)Social.Active).SignOut();
		tx_id.text = "No ID";
		tx_userName.text= "No UserName";

	}	
	

}
*/