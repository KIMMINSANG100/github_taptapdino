using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	public class CombatTextManager : MonoBehaviour {

	public static float health;

	public GameObject textPrefab; // 이 클래스에서 관리하는 text textPrefab
	public GameObject expTextPrefab; // 이 클래스에서 관리하는 text textPrefab
	//public GameObject levelUp_textPrefab; // 이 클래스에서 관리하는 text textPrefab
	public RectTransform canvasTransform; // text prefab 을 띄우는 캔버스

	public float fadeTime; 
	public float speed;
	public Vector3 direction;

	public Transform camTransform;

	private static CombatTextManager instance; // 다른 클래스에서 이 class 소환을 위한 변수

	public static CombatTextManager Instance // 다른 클래스에서 이 class 소환을 위한 변수
	{
		get
		{
			if(instance == null)
			{
				instance = GameObject. FindObjectOfType <CombatTextManager>();
			}
			return instance;
		}
	
	}

	public void CreateText(Vector3 position , string text, Color color, bool crit)
	{
		// string text, Color color
		GameObject sct = (GameObject) Instantiate (textPrefab, position, Quaternion.identity); // 받아들인 position에 텍스트 소환
		sct.transform.SetParent(canvasTransform ); // 이 텍스트에 parent canv ㅐas를 설정
		sct.GetComponent<RectTransform>().localScale = new Vector3 (1.5f,1.5f);  // 크기를 1,1,1로 설정
		sct.GetComponent<CombatText>().Initialize(speed,direction, fadeTime, crit); // 생성되는 텍스트의 combat text class에서 initialize 함수를 소환 combat text class에 speed, direction, fade time, bool crit 설정
		sct.GetComponent<Text>().text = text; //sct의 text에 받아들인 text 값을 지정
		sct.GetComponent<Text>().color = color; // sct의 text에 받아들인 color 값을 지정
		if(crit==true){
			sct.GetComponent<Animator>().SetTrigger ("Critical");
			sct.transform.localScale *=2;
		}
	}
	public void CreateExpText(Vector3 position , string text, Color color, bool crit)
	{
		// string text, Color color
		GameObject sct = (GameObject) Instantiate (expTextPrefab, position, Quaternion.identity); // 받아들인 position에 텍스트 소환
		sct.transform.SetParent(canvasTransform ); // 이 텍스트에 parent canv ㅐas를 설정
		sct.GetComponent<RectTransform>().localScale = new Vector3 (1.5f,1.5f);  // 크기를 1,1,1로 설정
		sct.GetComponent<CombatText>().Initialize(speed,direction, fadeTime, crit); // 생성되는 텍스트의 combat text class에서 initialize 함수를 소환 combat text class에 speed, direction, fade time, bool crit 설정
		sct.GetComponent<Text>().text = text; //sct의 text에 받아들인 text 값을 지정
		sct.GetComponent<Text>().color = color; // sct의 text에 받아들인 color 값을 지정
		if(crit==true){
			sct.GetComponent<Animator>().SetTrigger ("Critical");
			sct.transform.localScale *=2;
		}
	}
	// Use this for initialization
	



	/*public void CreateLevelUpText(Vector3 position )
 
	{
// string text, Color color
		GameObject sct = (GameObject) Instantiate (levelUp_textPrefab, position, Quaternion.identity); // 받아들인 position에 텍스트 소환
		sct.transform.SetParent(canvasTransform ); // 이 텍스트에 parent canvas를 설정
		sct.GetComponent<RectTransform>().localScale = new Vector3 (1,1);  // 크기를 1,1,1로 설정
	}*/
	// Update is called once per frame
	void Update () {
		
	}

}
