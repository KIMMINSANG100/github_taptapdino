using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_LevelUp : MonoBehaviour { 

	private float speed;

	private Vector3 direction = Vector3.zero;

	private float fadeTime;
 
	private bool crit;

	private bool stay = true;

	Transform pos;
		void Start () 
	{

		StartCoroutine ("Boom");
		fadeTime=2;
						StartCoroutine(FadeOut());
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,5)* 3000*Time.deltaTime);

						

//	 	transform.LookAt(2*transform.position - CombatTextManager.Instance.camTransform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if(stay)
		{
			float translation = Time.deltaTime;

			transform.Translate ( direction * translation );
		}

	//	if(pos.position.y < 2)
	//	else
	//	GetComponent<Rigidbody2D>().AddForce(new Vector2(newX,40)* -300*Time.deltaTime);
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(newX,-400)* 10*Time.deltaTime);
	}
 




 

	/*	stay = critical;

		if(critical)
		{
			GetComponent<Animator>().SetTrigger("Critical");


		} 
*/
	private IEnumerator Boom()
	{
		yield return new WaitForSeconds(0.008f);
		if(transform.localScale.x>=2)
			transform.localScale *=0.8f;
		else StopCoroutine("Boom");

		StartCoroutine("Boom");	
	}
	

	private IEnumerator FadeOut()
	{
		float startAlpha = GetComponent <Text> (). color. a;

		float rate = 1.0f / fadeTime;

		float progress = 0.0f ;

		while ( progress <1.0)
		{
			Color tmpColor = GetComponent<Text>(). color;
			GetComponent<Text>().color = new Color (tmpColor.r , tmpColor.g, tmpColor.b, Mathf.Lerp(startAlpha, 0, progress ));

			progress += rate * Time. deltaTime;
	
			yield return null;

		}
		
		Destroy(gameObject);
	}
}
