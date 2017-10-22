using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
[SerializeField]
private GameObject FireOfthisKi;
	


float scale =0 ;
	// Update is called once per frame
	void Update () {
//	float a= GetComponent<Dino_Individual>().totalPower;

		if(this.gameObject.GetComponent<ParticleSystem>().gameObject.activeSelf==false)
			Destroy(gameObject);


		if(Input.GetMouseButton(0))
		{
			scale += Time.deltaTime;
		}

		if(Input.GetMouseButtonUp(0))
		{
			Destroy(gameObject);
			GameObject tmpFire = Instantiate(FireOfthisKi);
			tmpFire.transform.position = this.transform.position;
			// 수정할 부분
			tmpFire.GetComponent<Rigidbody2D>().velocity = new Vector3(20,0,0);
			tmpFire.transform.localScale *= 1+scale;
			tmpFire.transform.GetChild(0).transform.localScale *= 1+scale;

		}
		
	}

	void DestroyItself()
	{
		Destroy(gameObject);

	}
}
