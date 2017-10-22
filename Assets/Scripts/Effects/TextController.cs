using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

public static TextController instance;

	Transform CanvasTrans;
	Transform MainCanvas;
	// Use this for initilization
	void Start () {
		CanvasTrans = GameObject.FindGameObjectWithTag("TextCanvas").transform;
		MainCanvas = GameObject.FindGameObjectWithTag("MainCanvas").transform;
	}
	
	[SerializeField]
	GameObject WhiteBar;

	[SerializeField]
	GameObject StartText;

	[SerializeField]
	GameObject DefeatedText;

	[SerializeField]
	GameObject VictoryText;

	// Update is called once per frame
	void FixedUpdate () {
		
	}


	public void Disp_WhiteBar()
	{
		GameObject tmp = Instantiate(WhiteBar);
		

	}


	public void Disp_StartText()
	{
		GameObject tmp = Instantiate(StartText);
		
		tmp.transform.SetParent(MainCanvas);
		tmp.transform.localScale = new Vector3(1f,1f,0);

		tmp.GetComponent<RectTransform>().sizeDelta = new Vector2 (300,100);
		tmp.transform.localPosition = new Vector3(0,0,0);
		tmp.GetComponent<Text>().text = "STAGE"+ ControlTowerScript.controlTowerScript.battleStageLevel.ToString();

		StartCoroutine(BeSmall(tmp));
	}




int k =0;


	IEnumerator BeSmall(GameObject tmp)
	{
		yield return new WaitForSeconds(0.001f);
		
		tmp.GetComponent<RectTransform>().sizeDelta-= new Vector2(0,5);// -= new Vector3 (0.1f,0.1f,0.1f) *2;


		if(tmp.GetComponent<RectTransform>().sizeDelta.y >40)
		StartCoroutine(BeSmall(tmp));
		else
		{
		StartCoroutine(Blinking(tmp));
		}
	}




	IEnumerator Blinking(GameObject tmp)
	{
		
		yield return new WaitForSeconds(1f);
				tmp.GetComponent<Text>().color = new Color (1,1,1, this.GetComponent<SpriteRenderer>().color.a);

		k++;
		if(tmp.GetComponent<Outline>().effectColor== new Color (0,55,255,128))
			tmp.GetComponent<Outline>().effectColor=new Color (0,0,0,255);

		else if(tmp.GetComponent<Outline>().effectColor ==new Color (0,0,0,255))

			tmp.GetComponent<Outline>().effectColor= new Color
			 (0,55,255,128);

		StartCoroutine(Blinking(tmp));
		

		if(k==10)
		StopCoroutine(Blinking(tmp));

	}


	public void Disp_VictoryText()
	{
		GameObject tmp = Instantiate(VictoryText);

		tmp.transform.SetParent(CanvasTrans);
		tmp.transform.localPosition = new Vector3(0,0,0);
		StartCoroutine(BeSmall(tmp));
	}
	public void Disp_DefeatedText()
	{
		GameObject tmp = Instantiate(DefeatedText);
		
		tmp.transform.SetParent(CanvasTrans);
		tmp.transform.localPosition = new Vector3(0,0,0);
		StartCoroutine(BeSmall(tmp));
	}

	public void DestroyStart()
	{
		Destroy(gameObject);
	}
}
