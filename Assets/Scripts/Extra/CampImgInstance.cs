using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampImgInstance : MonoBehaviour {

	[SerializeField]
	public int getInvenNumber;

	bool touched;
	// Use this for initialization
	void Start () {
			touched=true;
	
		StartCoroutine(moveToSomewhereWhenClick()); 	
	}
	
	IEnumerator moveToSomewhereWhenClick()
	{

		while(touched)
		{
			
//			this.transform.position 
			yield return new WaitForSeconds(0.05f);
			if(Input.GetMouseButton(0))
			transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition)+new Vector3 (0,0,10);// 10더한건 화면에 보이도록
			else if(!Input.GetMouseButton(0)){
				touched=false;	
				Destroy(gameObject);

				StopCoroutine(moveToSomewhereWhenClick()); 	
			}


		}


	}

	void OnMouseUp()
		{
		Debug.Log("MOuseup");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
