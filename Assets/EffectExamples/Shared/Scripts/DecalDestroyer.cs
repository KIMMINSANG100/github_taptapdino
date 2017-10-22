using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecalDestroyer : MonoBehaviour {

	public float lifeTime = 5.0f;

	[SerializeField]
	GameObject destroyParti;
	[SerializeField]
	GameObject Content;
	[SerializeField]
	GameObject DestParent;

	float fillAmount;
	float leftLifeTime;
	float consumedLifeTime;
	Color32 contentColor;
	private IEnumerator Start()
	{
		if(Content!=null)
		{
				contentColor=Content.GetComponent<Image>().color;
				StartCoroutine("blinkBlink");
		}

		if(transform.Find("StatCanvas")!=null)
		{
						
			fillAmount = Map(leftLifeTime, 0, lifeTime, 0, 1);
			Content.GetComponent<Image>().fillAmount =fillAmount;
		}
		yield return new WaitForSeconds(lifeTime);
		
		if(destroyParti!=null){
			GameObject tmp = Instantiate(destroyParti);
			tmp.transform.position = this.transform.position;
		}
		if (this.CompareTag ("Target")) {	
			GetComponent<PolygonCollider2D> ().isTrigger = true;
			yield return new WaitForSeconds (0.8f);
			Destroy (gameObject);
			if (DestParent != null)
				Destroy (DestParent.gameObject);
		} 
		else 
		{
			Destroy (gameObject);
			if (DestParent != null)
				Destroy (DestParent.gameObject);
		}
	}

	void Update()
	{ 
		consumedLifeTime +=Time.deltaTime;
		leftLifeTime= lifeTime - consumedLifeTime;
		if(transform.Find("StatCanvas")!=null)
		{
						
			fillAmount = Map(leftLifeTime, 0, lifeTime, 0, 1);
			Content.GetComponent<Image>().fillAmount =fillAmount;
		}
	}

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }




	[SerializeField]
	private bool blink = false;
	bool blinkBright = false;
	void QuitBlink()
	{
						Content.GetComponent<Image>().color = new Color32 ( 255, 255, 255, 0 );

						StopCoroutine("blinkBlink");

	}

[SerializeField]
private float blinkSeconds =0.04f;
	IEnumerator blinkBlink()
	{
		
 		yield return new WaitForSeconds(blinkSeconds);
 
		if(blinkBright==false)
		{
				Content.GetComponent<Image>().color -= new Color32 ( 0, 0, 0, 20 );
				yield return new WaitForSeconds(0.01f);
					Content.GetComponent<Image>().color -= new Color32 ( 0, 0, 0, 20 );
				yield return new WaitForSeconds(0.01f);
					Content.GetComponent<Image>().color -= new Color32 ( 0, 0, 0, 20 );
				yield return new WaitForSeconds(0.01f);
					Content.GetComponent<Image>().color -= new Color32 ( 0, 0, 0, 20 );
				yield return new WaitForSeconds(0.01f);
					Content.GetComponent<Image>().color -= new Color32 ( 0, 0, 0, 20 );
			blinkBright=true;	
		}

		else if (blinkBright==true)
		{
			
			Content.GetComponent<Image>().color += new Color32 ( 0, 0, 0, 20 );
				yield return new WaitForSeconds(0.01f);
					Content.GetComponent<Image>().color += new Color32 ( 0, 0, 0, 20 );
				yield return new WaitForSeconds(0.01f);
					Content.GetComponent<Image>().color += new Color32 ( 0, 0, 0, 20 );
				yield return new WaitForSeconds(0.01f);
					Content.GetComponent<Image>().color += new Color32 ( 0, 0, 0, 20 );
				yield return new WaitForSeconds(0.01f);
					Content.GetComponent<Image>().color += new Color32 ( 0, 0, 0, 20 );

			blinkBright=false;
		}
					StartCoroutine("blinkBlink"); 

	}
}
