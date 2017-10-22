using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreLoad : MonoBehaviour { 
	public void MoveToGame()
	{
		SubTowerScript.subTowerScript.LoadMain();

	}

	public void LoadMainAlarm()
	{
		SubTowerScript.subTowerScript.LoadMainAlarm2();
	}

}
