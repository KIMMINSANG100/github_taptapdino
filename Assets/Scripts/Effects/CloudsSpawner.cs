using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawner : MonoBehaviour {

[SerializeField]
GameObject Cloud; 
	// Use this for initialization
	void Start () {

		if( this.gameObject.name == "Clouds")
		{
			StartCoroutine("spawnCloud");
		}		
	}
	
	// Update is called once per frame
	void Update () {
		


		if(this.gameObject.name =="cloud(Clone)")
		{
			
					this.transform.position += new Vector3 ( velocity ,0,0) * Time.deltaTime;
					if(this.transform.position.x>12.5f)
					{
						Destroy(gameObject);
					}
		}
	}


	IEnumerator spawnCloud()
	{
		

		GameObject tmpCloud = Instantiate(Cloud);
		int randInt = Random.Range(1,18);
		tmpCloud.transform.position = this.transform.GetChild(0).transform.position + new Vector3(0,randInt/6);	
		
		yield return new WaitForSeconds(20f);
		StartCoroutine("spawnCloud");

	}


[SerializeField]
float velocity =0.1f;

	IEnumerator cloudMove()
	{
		yield return new WaitForSeconds(0.05f);

		this.transform.position += new Vector3 ( velocity ,0,0);
		StartCoroutine("cloudMove");
	}
}

