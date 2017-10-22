using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdGiftMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	[SerializeField]
	TimeCounter_Event thisTimeCounter;
	// Update is called once per frame
	[SerializeField]
	GameObject thisPanel;
	

	void OnMouseDown()
	{ 
				thisTimeCounter.forInitESM();
		AdManager.Instance.ShowVideo();
		thisPanel.SetActive(false);
	}
}
		


