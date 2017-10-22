using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour {
Image theseChildOpa;
	// Use this for initialization
	void Start () {
		theseChildOpa = transform.Find("Opa").GetComponent<Image>();
	}
	
	// Update is called once per frame
	public void BlinkingBlinking () {

		if(transform.Find("number")!=null)
		{ 
			if( int.Parse(transform.Find("number").GetComponent<Text>().text) >0 && blink==false )
			{

					blink=true;
					 

					StartCoroutine("blinkBlink");
					Invoke("QuitBlink",4);
					

 			}
			else if( int.Parse(transform.Find("number").GetComponent<Text>().text) <=0 && blink==true )
			{
				blink=false;
			 	
				
				theseChildOpa.color = new Color32 ( 255, 255, 255, 0 );
				StopCoroutine("blinkBlink");

 			}
		}
	}




	[SerializeField]
	private bool blink = false;
	bool blinkBright = false;
	void QuitBlink()
	{
						theseChildOpa.color = new Color32 ( 255, 255, 255, 0 );

						StopCoroutine("blinkBlink");

	}

[SerializeField]
private float blinkSeconds =0.05f;
	IEnumerator blinkBlink()
	{
		
 		yield return new WaitForSeconds(blinkSeconds);
 
		if(blinkBright==false)
		{
				theseChildOpa.color = new Color32 ( 255, 255, 255, 70 );
			blinkBright=true;	
		}

		else if (blinkBright==true)
		{
			theseChildOpa.color = new Color32 ( 255, 255, 255, 0 );
			blinkBright=false;
		}
					StartCoroutine("blinkBlink");
 		if( int.Parse(transform.Find("number").GetComponent<Text>().text) <=0 )
		 				{
			StopCoroutine("blinkBlink");
 						 
						 }

	}

}
