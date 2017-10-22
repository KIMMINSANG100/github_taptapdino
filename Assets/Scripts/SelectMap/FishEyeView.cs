using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishEyeView : MonoBehaviour {

	Transform CamTrans;
	// Use this for initialization
	Vector3 OriginalSize = new Vector3(0.8f, 0.8f, 0.8f);
	void Start () {
		
		CamTrans = GameObject.FindGameObjectWithTag("MainCamera").transform;
		GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().SceneNumber= 2;
		OriginalSize =  new Vector3(0.8f, 0.8f, 0.8f);

	}
	[SerializeField]
	float howBig =2;
	bool scaleSwitch;

	bool velSwitch=false;
	// Update is called once per frame 

	Transform selectedChild;
	[SerializeField]
	float scrollVel = 3;
	void Update () { 
		//for()

		
	Transform scrollTrans = this.transform.GetChild(0).transform;
	
	GameObject scrollObject = this.transform.GetChild(0).gameObject;

	if(scrollTrans.GetComponent<Rigidbody2D>()!=null)
	if( Mathf.Abs(scrollTrans.GetComponent<Rigidbody2D>().velocity.x) < scrollVel && velSwitch==false)
	{
		//

		for(int a=0; a<scrollTrans.childCount ; a++)
		{
			Transform childVec = scrollTrans.GetChild(a).transform;
		
				// 범위 && 바뀌었는지
			if( childVec.position.x >= CamTrans.position.x -howBig&& childVec.position.x <= CamTrans.position.x + howBig)
			{
				
	//		Debug.Log( "child"+a)	;

				if(childVec.parent.name == "ScrollBar_Stage")
				childVec.localScale= 2f*OriginalSize;



				else if(childVec.parent.name == "ScrollBar_Map")
				childVec.localScale= 1.5f*OriginalSize;
				
				//if(scrollObject.GetComponent<Rigidbody2D>)
				//moveToCenter(childVec);

		//			GetComponent<ScrollRect>().enabled=false;
		
		//			scaleSwitch=false;
			}

			else if( (childVec.position.x < CamTrans.position.x  -howBig|| childVec.position.x  > CamTrans.position.x +howBig) && scaleSwitch==false)
			{

				
			//	GetComponent<Animator>().SetTrigger("Small");
				childVec.localScale =OriginalSize;
				//Debug.Log( "else : child"+a + "size" + childVec.localScale);
		//		scaleSwitch=true;
			}

		}

		if(Input.GetMouseButtonDown(0))
		GetComponent<ScrollRect>().enabled=true;
	}



	if(Mathf.Abs(scrollTrans.GetComponent<Rigidbody2D>().velocity.x) > scrollVel|| Mathf.Abs(scrollTrans.GetComponent<Rigidbody2D>().velocity.x) < scrollVel)
	{
		velSwitch=false;
							GetComponent<ScrollRect>().enabled=true;

	}
 
	}







	void moveToCenter(Transform a)
	{
		Transform scrollTrans = this.transform.Find("ScrollBar").transform;

	//	this.transform.parent.transform.position += new Vector3( CamTrans.position.x- this.transform.position.x , 0)*0.5f;
		scrollTrans.position =  new Vector3 ( Mathf.Clamp(CamTrans.position.x- a.position.x,-0.1f,0.1f), 		scrollTrans.position.y , scrollTrans.position.z );
		velSwitch=true;
	}



}
