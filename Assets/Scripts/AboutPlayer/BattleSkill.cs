using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSkill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	[SerializeField]
	GameObject Circle;


	[SerializeField]
	GameObject[] Skill_01;
	// Update is called once per frame
	void Update () {
		
		if(this.name=="Circle(Clone)")
		{
			if(Input.GetMouseButton(0))
			transform.position =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0,0,Camera.main.ScreenToWorldPoint(Input.mousePosition).z);	

		
			if(Input.GetMouseButtonUp(0))
			{
				
			GameObject tmp =  Instantiate(Skill_01[0]);

			tmp.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition)- new Vector3(0,0,Camera.main.ScreenToWorldPoint(Input.mousePosition).z);		
			Destroy(gameObject);
			}
		}


	}



	void OnMouseDown()
	{
		GameObject tmp =  Instantiate(Circle);

		tmp.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition)- new Vector3(0,0,Camera.main.ScreenToWorldPoint(Input.mousePosition).z);		
 	}


	
	
 



}
