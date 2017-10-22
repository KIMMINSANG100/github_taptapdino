using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTargetSpawnManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	[SerializeField]
	private GameObject[] enemy;
	// Update is called once per frame
	private int i =0;
	void Update () {
		
		if(GameObject.FindGameObjectWithTag("Target")==null&& i==0)
		{

			StartCoroutine(NextTarget());
			i++;
		}
	}

	void SpawnEnemy()
	{
		int targetRand = Random.Range (0, enemy.Length);
		int rand = Random.Range (0, 120);
		if (rand < 5)
			targetRand = 0;
		else if (rand < 70)
			targetRand = 1;
		else if (rand < 90)
			targetRand = 2;
		else if (rand < 95)
			targetRand = 3;
		else if (rand < 100)
			targetRand = 3;
		else if (rand < 120)
			targetRand = 4;

		
		GameObject tmp= (GameObject)Instantiate(enemy[targetRand]);
	//		tmp.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
			tmp.transform.position = new Vector3( 	4.9f, 10f, 0);	
			i--;
	}


	IEnumerator NextTarget()
	{
		yield return new WaitForSeconds(0.2f);
          SpawnEnemy();
		  
    }


}
