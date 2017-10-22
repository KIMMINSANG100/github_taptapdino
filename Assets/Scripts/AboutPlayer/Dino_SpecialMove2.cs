using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino_SpecialMove2 : MonoBehaviour {
[SerializeField]
int moveKind;
	// Use this for initialization
	void Start () {

				Invoke("invoStart",starttiming);

								StartCoroutine("WatchAround");


				
			//GetComponent<Rigidbody2D>().velocity = new Vector3 ( velocity * direction, 0);

	}
	
[SerializeField]
float velocity;
[SerializeField]
float direction;

[SerializeField]
float starttiming;
	// Update is called once per frame
	void Update () {
		if(starttiming>=20)
		{

		}
		if(Input.GetMouseButtonDown(0))
		{
			StartCoroutine("Jump");
		}
 	}

void invoStart()
{

		if(moveKind==1)

				StartCoroutine("Jump");



		if(moveKind==2)
				StartCoroutine("shakeX");

//GetComponent<Rigidbody2D>().velocity = new Vector3 ( velocity * direction, 0);
starttiming=20;
}


[SerializeField]
float jumpTiming;

[SerializeField]
Vector3 jumpVector;

int i =0;

	IEnumerator Jump(){
		if(i <4){
		i++;
		yield return new WaitForSeconds(jumpTiming);

		if(GetComponent<Rigidbody2D>()!=null)
		GetComponent<Rigidbody2D>().AddForce(jumpVector);

		yield return new WaitForSeconds(0.3f);
		if(GetComponent<Rigidbody2D>()!=null)
		GetComponent<Rigidbody2D>().AddForce(jumpVector);

		yield return new WaitForSeconds(0.3f);
		if(GetComponent<Rigidbody2D>()!=null)
		GetComponent<Rigidbody2D>().AddForce(jumpVector);

		yield return new WaitForSeconds(1f);

			StartCoroutine("Jump");
		}
		else
			StopCoroutine("Jump");
 	}

	




[SerializeField]
float moveTiming;

[SerializeField]
Vector3 moveVector;

	IEnumerator shakeX(){
		
 		yield return new WaitForSeconds(0.05f);

		transform.position += moveVector;

		yield return new WaitForSeconds(0.05f);
		transform.position -= moveVector;
		StartCoroutine("shakeX");

		

		
	}




	IEnumerator WatchAround(){
		float randD = Random.Range(0,0.4f);
 		yield return new WaitForSeconds(8.9f);

		transform.localScale =  new Vector3(transform.localScale.x*(-1) , transform.localScale .y);

		yield return new WaitForSeconds(0.8f);
		transform.localScale =  new Vector3(transform.localScale.x*(-1) , transform.localScale .y);



		yield return new WaitForSeconds(0.6f+randD);
		transform.localScale =  new Vector3(transform.localScale.x*(-1) , transform.localScale .y);


		yield return new WaitForSeconds(1.5f);

		transform.localScale =  new Vector3( - Mathf.Abs(transform.localScale.x) , transform.localScale .y);

		StopCoroutine("WatchAround");

		

		
	}

	

}
