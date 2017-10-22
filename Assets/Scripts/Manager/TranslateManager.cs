using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslateManager : MonoBehaviour {
	int languageNumber; 

	[SerializeField]
	string[] translator;

	public Font KoreanFont;
	Text theseTxt ;

	//0.english 1. korean 2. japanese. 3. chinese. 4.hindi 5. arabi

	// Use this for initialization
	void Awake() {
		if(this.name !="OnOff"){
		if(ControlTowerScript.controlTowerScript!=null)
 		languageNumber=ControlTowerScript.controlTowerScript.language;
 
		

		if(GetComponent<Text>()!=null){
		theseTxt = GetComponent<Text>();
		theseTxt.text = translator [languageNumber].ToString();
	
		if (languageNumber == 1) {
			theseTxt.font = KoreanFont;
		}
		}
		StartCoroutine(updatedTranslator());
	
	} 
	}
	IEnumerator updatedTranslator()
	{


		while(true){
			if(ControlTowerScript.controlTowerScript!=null)
			if (ControlTowerScript.controlTowerScript.SceneNumber == 0) {
 
			languageNumber=ControlTowerScript.controlTowerScript.language;
			if (theseTxt != null) {
				theseTxt.text = translator [languageNumber].ToString ();
				theseTxt.font = KoreanFont;
			}

		}
		yield return new WaitForSeconds(0.02f);
				if(ControlTowerScript.controlTowerScript.SceneNumber!=0)
			break;
		}

	}
		

	[SerializeField]
	int	transNumber;
	public void sendTranslateNumber()
	{
		BtnSounds.instance.Enter();
		 
		ControlTowerScript.controlTowerScript.language = transNumber;
	}


public GameObject langCanvas;
	public void quitLanguageSetting()
	{
		langCanvas.SetActive(false);		
	}
}
