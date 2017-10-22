using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnToggle : MonoBehaviour {

	[SerializeField]
	GameObject[] activeFalse
	;
	[SerializeField]
	GameObject activeTrue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
bool toggleON = true;
	public void changeWindow()
	{

		GetComponent<Animator>().SetTrigger("clicked");
		// if(toggleON==true){
		// activeTrue.SetActive(true);
		// toggleON=false;
		// }
		// else if(toggleON==false){
		// activeTrue.SetActive(false);
		// toggleON=true;
		// }
	Debug.Log(this.name);
	}	
}
