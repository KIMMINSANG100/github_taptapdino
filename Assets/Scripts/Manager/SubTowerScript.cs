using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubTowerScript : MonoBehaviour {

public static SubTowerScript subTowerScript;
	// Use this for initialization
	void Awake(){
		

		if(subTowerScript==null)
		{
		//s	DontDestroyOnLoad(transform.gameObject);
			subTowerScript=this;
		}
		else if(subTowerScript != this)
		{
			Destroy(subTowerScript);
		}
	}
	void Start () {
		
	}
	

	 
	// Update is called once per frame 

////////////////확인 LoadSelectStge : 디펜스 버튼을 누르면 뜨는 첫번째창 로드
	public void LoadSelectStage()
	{
		AdManager.Instance.HideBanner();

		if(GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("SelectStage")!=null)
		GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("SelectStage").gameObject.SetActive(true);

		else
		SceneManager.LoadScene("SelectStage");
	
 	}


/////////////

	

	public void LoadBattleStage()
	{
		AdManager.Instance.ShowBanner();
		SpawnLoadingScript.instance.Loading();
		SceneManager.LoadScene("BattleScene");
 	}



	public void LoadSelectCamp()
	{
 		SceneManager.LoadScene("SelectCamp");
 	
	}

	public void LoadMain()
	{
		ControlTowerScript.controlTowerScript.SceneNumber=1;
		SceneManager.LoadScene("GameMainScene");
		Debug.Log("GameMainScene");
	}

	public void LoadMainAlarm()
	{
		GameObject.FindGameObjectWithTag("MainCamera").transform.position =new Vector3 (0, -15, -10);		
				//ControlTowerScript.controlTowerScript.Load();

		

	}


	public void LoadMainAlarm2()
	{
		if(ControlTowerScript.controlTowerScript.sumOfPowers>2)
		GameObject.FindGameObjectWithTag("MainCamera").transform.position =new Vector3 (0, -15, -10);		
				ControlTowerScript.controlTowerScript.Load();

		

	}


	public void LoadMainName()
	{
				ControlTowerScript.controlTowerScript.Load();
		 BtnSounds.instance.Enter();
		Invoke("InvoMainName",1);
		
	}
////////////////////////
	public void InvoMainName()
	{
		GameObject.FindGameObjectWithTag("MainCamera").transform.position =new Vector3 (25, 0, -10);		
	}

//////////////////////////

	public void LoadMain_OnMain()
	{	
				BtnSounds.instance.Exit();

				GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("SelectStage").gameObject.SetActive(false);

				ControlTowerScript.controlTowerScript.Load();
	}
////////////////////////
	public void Load_Trailler()
	{
		
		StartCoroutine( LoadTraillerScene() );
	}
	
	private IEnumerator LoadTraillerScene()
	{
		var async = SceneManager.LoadSceneAsync( 1 );
		Debug.Log( async.progress );
		yield return async;
	}


	public void LoadTutorial()
	{
		SceneManager.LoadScene("Tutorial");
	}
/////////////////////////
	public void LoadMainOnSelectStage()
	{

		GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("SelectStage").gameObject.SetActive(false);
		Debug.Log("GameMainScene");
	}

}
