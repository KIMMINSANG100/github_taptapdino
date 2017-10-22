using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino_SpecialMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		dinoInitPos = this.transform.position;
		dinoTargetPos = dinoInitPos + new Vector3 (0,2);
		
	}
	

Vector3 dinoInitPos;
Vector3 dinoTargetPos;
[SerializeField]
int turn=0;
[SerializeField]
int ifif =0;
	// Update is called once per frame
	void Update () {
		


// 위로 움직이기
		if(turn ==0)
		{
			transform.position += new Vector3 (0, 0.3f, 0) * Time.deltaTime;

if(this.transform.Find("Shadow")!=null)

			this.transform.Find("Shadow").transform.position -= new Vector3 (0, 0.3f, 0) * Time.deltaTime;
if(this.transform.Find("Char_StatCanvas")!=null)
			this.transform.Find("Char_StatCanvas").transform.position -= new Vector3 (0, 0.3f, 0) * Time.deltaTime;

			if(ifif==0)
			{
			ifif=1;
			Invoke("TurnToDown",1.2f);
			}

		}
		

// 밑으로 움직이기
		if(turn ==1)
		{
			transform.position -= new Vector3 (0, 0.3f, 0) * Time.deltaTime;

if(this.transform.Find("Shadow")!=null)

			this.transform.Find("Shadow").transform.position += new Vector3 (0, 0.3f, 0) * Time.deltaTime;

if(this.transform.Find("Char_StatCanvas")!=null)
			this.transform.Find("Char_StatCanvas").transform.position += new Vector3 (0, 0.3f, 0) * Time.deltaTime;

			if(ifif==0)
			{
			ifif=1;
			Invoke("TurnToUp",1.2f);
			}
		}
	}

	
	void TurnToDown()
	{
		
        turn=1 ;
		ifif=0;	
    }

	void TurnToUp()
	{
	   turn=0 ;
		ifif=0;

    }
}
