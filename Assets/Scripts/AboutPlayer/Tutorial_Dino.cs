using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Dino : MonoBehaviour {

	// Use this for initialization
public AudioClip dinoSound;
public AudioClip fireSound;

[SerializeField]
private Transform Mouth;


[SerializeField]
private GameObject bullet;


void FireSoundSet()
{
//화면 벗어나면 소리안들리도록
 			Vector2 screenPoint = Camera.main.WorldToViewportPoint(new Vector2(1,1));
 		
 			
			
			AudioSource.PlayClipAtPoint(dinoSound ,transform.position, .7f);
			AudioSource.PlayClipAtPoint(fireSound ,transform.position,1f);
 
		}	

 	Animator thisAnimator;
void Start()
{ 	
	thisAnimator = this.GetComponent<Animator>();
 
 
// 화면에 대해서 기능 추가 / 제거
	//if(sceneNumber==1) 
 
}

void Update()
{
	if(Input.GetMouseButtonDown(0))
	{

		thisAnimator.SetTrigger("Fire");
		Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		GameObject tmp = Instantiate(bullet);
		tmp.transform.position = Mouth.position;
			Vector3 CompareVector = (MousePos-(Vector2) Mouth.transform.position);
	CompareVector = new Vector3 ( Mathf.Abs(CompareVector.x),CompareVector.y);
	Rigidbody2D fireBody = tmp.GetComponent<Rigidbody2D>();
	if(CompareVector.x <1)
	CompareVector = CompareVector = new Vector3 (1,CompareVector.y);

	if( CompareVector.magnitude <100 )
	{
	fireBody.AddForce( CompareVector*100*1.5f);
	}

	if(CompareVector.magnitude >=100 )
	fireBody.AddForce(CompareVector.normalized*100*1.5f);
	

 
	}

}
 
}
