/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using google.service.game;

public class GoogleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	GoogleGame.Instance().login (true, false);
	GoogleGame.Instance().gameEventHandler += onGameEvent;
	
	}
	
	void onGameEvent(int result_code,string eventName,string data){
	Debug.Log (eventName + "-----------" + data);
	if(result_code==-1&&eventName==GameEvent.onConnectSuccess){
		//login success,you can do other now
	}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
*/