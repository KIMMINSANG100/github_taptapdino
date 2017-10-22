using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour {

[SerializeField]
	GameObject Fire;
[SerializeField]
	GameObject StartPang;

[SerializeField]	
	float totalPower;

[SerializeField]
	float fireMaxSpeed;
	
[SerializeField]
	GameObject AppearParticle;


[SerializeField]
Animator thisAnimator;//r= GetComponent<Animator>();

[SerializeField]
Rigidbody2D thisBody;
[SerializeField]
PolygonCollider2D col2D;
	void Start () {
			 thisBody = GetComponent<Rigidbody2D>();
			col2D = GetComponent<PolygonCollider2D>();
		StartCoroutine(stopPosition());
		StartCoroutine(ShootingFire_Auto());
	}
	
	// Update is called once per frame
	
	bool colTag=false;
	void OnCollisionEnter2D(Collision2D col)
	{
		
		if(colTag==false)
		{
			colTag = true;
			GameObject tmp 		   = Instantiate (StartPang);
			tmp.transform.position = this.transform.position;
			if (this.transform.position.y < 0) {
					thisBody.bodyType=RigidbodyType2D.Static;
					col2D.isTrigger=true;

				}
		}

	}


[SerializeField]
Vector2 autoVector ;
public bool autoOnOff;

[SerializeField]
private float fireTerm=1f;


IEnumerator ShootingFire_Auto()
{


		thisAnimator.SetTrigger("Fire");
float sumOf = ControlTowerScript.controlTowerScript.sumOfPowers *0.1f;
 	Vector2 TargetPos ;

		if(GameObject.FindGameObjectWithTag("Target")!=null)
		{
		 TargetPos = GameObject.FindGameObjectWithTag("Target").transform.position;	
		}
		else
		 TargetPos = new Vector2 (5.08f, -2.06f);
Transform Mouth = this.transform.Find("Mouth").transform;

while(true){
 	GameObject fireTmp =  Instantiate(Fire);
	Rigidbody2D fireBody = fireTmp.GetComponent<Rigidbody2D>();

		totalPower = Mathf.RoundToInt(sumOf);
	fireTmp.transform.position =Mouth.position;
	fireTmp.GetComponent<BulletScript>().totPower =totalPower;

	for(int dd =0 ; dd < fireTmp.transform.childCount ; dd++)
		Destroy( fireTmp.transform.GetChild(dd).gameObject);

 			fireBody.gravityScale = 0; 

		Vector3 CompareVector = (TargetPos-(Vector2) Mouth.transform.position);		
		CompareVector = new Vector3 ( Mathf.Abs(CompareVector.x),CompareVector.y) * fireMaxSpeed;
 
		{
		fireBody.AddForce( CompareVector*1.5f);
		}

		yield return new WaitForSeconds(fireTerm);
	
	}
}

IEnumerator stopPosition()
{
	while(true){
	yield return new WaitForSeconds(0.3f);
	if(colTag&& transform.position.y<-4){
			col2D.isTrigger=true;
			thisBody.bodyType=RigidbodyType2D.Static;

		 } 

		}
	}
}