using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
		
	}

	public void LoadMain()
	{

		if (GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("SelectStage")!=null)
		GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("SelectStage").gameObject.SetActive(false);

		else
		{
		SceneManager.LoadScene(2);
 		}
	}


	public void SelectMap()
	{
 		GameObject MainCanvas ;
		if( GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("SelectStage")!=null)
		MainCanvas =  GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("SelectStage").transform.Find("Canvas").gameObject;

		else
		MainCanvas =  GameObject.FindGameObjectWithTag("MainCanvas").gameObject;
		
		MainCanvas.transform.Find("ScrollView_StageLv").gameObject.SetActive(false);
		MainCanvas.transform.Find("ScrollView_Map").gameObject.SetActive(true);
	}


	public void SelectStage()
	{
		GameObject MainCanvas ;
		if( GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("SelectStage")!=null)
		MainCanvas =  GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("SelectStage").transform.Find("Canvas").gameObject;

		else
		MainCanvas =  GameObject.FindGameObjectWithTag("MainCanvas").gameObject;
		
		MainCanvas.transform.Find("ScrollView_StageLv").gameObject.SetActive(true);
		MainCanvas.transform.Find("ScrollView_Map").gameObject.SetActive(false);
	}


}
