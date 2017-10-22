using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	int k; 

	void Start () {
				invenNumb = ControlTowerScript.controlTowerScript.invennumberShared;
				
				if(levelText!=null){
					switch(k) {
					case 0 : 		levelText.text = ControlTowerScript.controlTowerScript.powerLevel[invenNumb].ToString();

					break;		
					case 1 : 		levelText.text = ControlTowerScript.controlTowerScript.adrenalineLv[invenNumb].ToString();

					break;		
					case 2 : 		levelText.text = ControlTowerScript.controlTowerScript.criticalRateLv[invenNumb].ToString();

					break;		
					case 3 : 		levelText.text = ControlTowerScript.controlTowerScript.critPowerLv[invenNumb].ToString();

					break;		
	
					}
				}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public int invenNumb;
	[SerializeField] Text levelText;


	[SerializeField] Text PriceText;

	[SerializeField] Button thisButton;
	public void plus_powerLevel()
	{
		// 


		ControlTowerScript.controlTowerScript.powerLevel[invenNumb]++;
		levelText.text = ControlTowerScript.controlTowerScript.powerLevel[invenNumb].ToString();
		// 코인 비교 구매가능 여부 확인 -> 버튼 setActive 여부
		buttonFalse();
	}
	public void plus_adrenalineLv()
	{
 		ControlTowerScript.controlTowerScript.adrenalineLv[invenNumb]++;
		levelText.text = ControlTowerScript.controlTowerScript.adrenalineLv[invenNumb].ToString();

		buttonFalse();
	}
	public void plus_criticalRateLv()
	{
 		ControlTowerScript.controlTowerScript.criticalRateLv[invenNumb]++;
		levelText.text = ControlTowerScript.controlTowerScript.criticalRateLv[invenNumb].ToString();

		buttonFalse();
	}
	public void plus_critPowerLv()
	{
 		ControlTowerScript.controlTowerScript.critPowerLv[invenNumb]++;
		levelText.text = ControlTowerScript.controlTowerScript.critPowerLv[invenNumb].ToString();
		buttonFalse();
	}


	void buttonFalse()
	{

		if(ControlTowerScript.controlTowerScript.coins < int.Parse(PriceText.text))
		{
			thisButton.enabled=false;
		}
	}
[SerializeField]
GameObject StatWindow;
	public void setStatWindow()
	{
		Debug.Log("a");
		if(StatWindow.activeSelf==true)
		{

		Debug.Log("b");
			StatWindow.gameObject.SetActive(false);
		}
		else if(StatWindow.activeSelf==false)
		{

		Debug.Log("c");
			StatWindow.gameObject.SetActive(true);
		}

	}
}
