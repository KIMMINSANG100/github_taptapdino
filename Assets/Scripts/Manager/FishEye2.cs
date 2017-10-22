using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEye2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
			originalScale=new Vector3[transform.childCount];
	for( int i =0; i < transform.childCount ; i++ )
		{
			originalScale[i]= this.transform.GetChild(i).transform.localScale;
		}

		//GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().SceneNumber= 2;

	}
	[SerializeField]
	Vector3 thisVelocity;

	[SerializeField]
	Vector3 firstPos;

	[SerializeField]
	Vector3 lastPos;

	[SerializeField]
	float velocityFactor=10;
	[SerializeField]
	float xMin=-554;
	[SerializeField]
	float xMax=591;

	[SerializeField]
	Vector3[] originalScale;

	
	
Vector3 distance;
	// Update is called once per frame
	void Update () {
		GetCenterTheChild();
// 마우스 다운		
		if(Input.GetMouseButtonDown(0))
		{
			firstPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);	
			firstPos = new Vector3(firstPos.x ,firstPos.y);
			this.transform.GetComponent<Rigidbody2D>().velocity= new Vector3 (0,0,0);

			StopCoroutine("MoveToCenter");
		}

// 마우스 오버
		if(Input.GetMouseButton(0))
		{
				lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);	



         StopCoroutine("MoveToCenter");

		 transform.localPosition += new Vector3 (( lastPos - firstPos ).x *20 ,0,0);

			 firstPos =lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);	
		/* 
		 		distance = firstPos - transform.localPosition;
         		transform.localPosition = new Vector3(firstPos.x, firstPos.y) - distance;
				transform.localPosition = new Vector3(
         		Mathf.Clamp(transform.position.x, xMin, xMax),
				transform.localPosition.y,
         		transform.localPosition.z);
				 */
	//		firstPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);	
		}
// 마우스 업
		if(Input.GetMouseButtonUp(0))
		{
StopCoroutine("MoveToCenter");
			lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);	

		thisVelocity = 	new Vector3 ((lastPos - firstPos ).x , 0,0) ;
		this.transform.GetComponent<Rigidbody2D>().AddForce(thisVelocity*velocityFactor);
		}

// 최대값 최소값
		if(this.transform.localPosition.x <xMin || this.transform.localPosition.x>xMax)
		{
			this.transform.GetComponent<Rigidbody2D>().velocity= new Vector3 (0,0,0);

		}
		this. transform.localPosition = new Vector3 ( Mathf.Clamp(this.transform.localPosition.x, xMin , xMax ),this.transform.position.y,this.transform.position.z);



		ChildScale();
		
	}


// child 크기

[SerializeField]
float factorA= 1;

[SerializeField]
float factorB= 0.01f;

	void ChildScale()
	{

		for( int i =0; i < transform.childCount ; i++ )
		{
			
		transform.GetChild(i).transform.localScale =  originalScale[i]* 1/( Mathf.Abs(this.	transform.GetChild(i).transform.position.x)*factorA+ factorB);
		}
		

	}

float[] compareScale;	

[SerializeField]
float minVel=0.5f;

int selectedNumber;
	void GetCenterTheChild()
	{
		
		if(Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.magnitude) <minVel )
		{

		compareScale = new float[transform.childCount];
		for( int i =0; i < transform.childCount ; i++ )
		{
			compareScale[i] =transform.GetChild(i).localScale.x ; 
		//	Debug.Log("comparescale:" + i);
			
		}	
		for( int i =0; i < transform.childCount ; i++ )
		{
			
			if(  transform.GetChild(i).localScale.x == Mathf.Max(compareScale))
			{
					 selectedNumber= i;
	//				 Debug.Log("selectednum:" + selectedNumber);
			}
		}		

	
		
		StartCoroutine("MoveToCenter");

 
		}

	}

int k =1;
	IEnumerator MoveToCenter()
	{
		//Debug.Log("movetocenter0");
		yield return new WaitForSeconds(0.01f);
		Transform selectedChild = transform.GetChild(selectedNumber).transform;
		if(Mathf.Abs(selectedChild.position.x) <1.8f)
		{
			this.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,0,0);
			this.transform.localPosition += new Vector3(-selectedChild.position.x*0.9f ,0 ,0);
			StartCoroutine("MoveToCenter");

 
		}		
		
		else
			StopCoroutine("MoveToCenter");
	}



}
