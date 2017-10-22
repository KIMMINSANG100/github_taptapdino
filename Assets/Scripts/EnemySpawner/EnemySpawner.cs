using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {



[SerializeField]
int turnNumber;

[SerializeField]
Vector3[] EnemySpawn;


	// Use this for initialization
	void Start () {
	//	if(GameObject.FindGameObjectWithTag("Target")==null&& i==0)
		{
			turnNumber=waitingTime.Length;
//			nowSpawnerLevel = GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().BattleLevelNumber;

//			i++;
		} 
	

		for(int i =0 ; i<turnNumber ; i++)
	{			StartCoroutine(timeWait(waitingTime[i],enemySpec_accTurn[i]));


	}


			StartCoroutine(timeWaitForBoss(waitingTime[turnNumber-1],whatBoss));


	}
	[SerializeField]
	private int whatBoss=0;



	[SerializeField]
	private int[] waitingTime;


	[SerializeField]
	private int[] enemySpec_accTurn;
	/*
				level		hp		
	enemy 1 
	enemy 2
	enemy 3		
	*/


	// Update is called once per frame

	[SerializeField]
	int startBtn=0;


	[SerializeField]
	private Vector4 enemySpec;
	void Update () {
		if( startBtn==1)
		{
			SpawnEnemy_XS(startBtn);

			
		}
 

	}


	[SerializeField]
	private int nowSpawnerLevel;

	[SerializeField]

	int howManyEnem=2;



/// 작은 적들 1번에 5마리 소환 
/// a 는 적의 종류
/// 


	void SpawnEnemy_XS(int a)
	{
 
		//int randEnem = Random.Range(0,howManyEnem);
 			
			 for(int i =0 ; i < transform.childCount ; i ++)
			 {
				 
					
// 몬스터 등장확률
				 int instRate = Random. Range(0,2);
				 if(instRate!=0){
					GameObject tmp= (GameObject)Instantiate(enemy[a]); // 종류
					
					
					tmp.transform.localScale *= (0.5f+i*0.1f);   		//크기 (y값에 따라 원근감)

					
					float randI = Random.Range(-0.5f,0.5f);
				 
					tmp.transform.position = transform.GetChild(i).transform.position - new Vector3(randI,0,i) ; // 위치
				 }


					


			 }
		//위치
			//tmp.transform.position = this.transform.position + new Vector3( 0.5f * randX, -0.6f + 0.5f*randY, 0);	
 	}

	[SerializeField]
	bool lastDino;

	[SerializeField]
	int enemyNumber =5;
//  적 수 , 적 종류 , 적 나오는 시간
	void Next_Enemy(int whatEnem, int howMany, int waitingSeconds)
	{
		//yield return new WaitForSeconds(waitingSeconds);

		//StartCoroutine();
  
			for(int e=0 ; e< howMany; e++)
				{
			//		SpawnEnemy(whatEnem);
				} 
	 
		//StartCoroutine(Next_Target01);
    }
	 	 

	IEnumerator timeWait(int turnTime, int enemyNumber)
	{
		yield return new WaitForSeconds(turnTime);
		SpawnEnemy_XS(enemyNumber);

	}

	IEnumerator timeWaitForBoss(int turnTime, int enemyNumber)
	{
		yield return new WaitForSeconds(turnTime);
		SpawnBoss(enemyNumber);

	}



	[SerializeField]
	private GameObject[] enemy;


	[SerializeField]
	private GameObject[] boss;

	void SpawnBoss(int a)
	{

		//int randEnem = Random.Range(0,howManyEnem);
 			 
				 
// 몬스터 등장확률
 					GameObject tmp= (GameObject)Instantiate(boss[a]); // 종류
					
					
				//	tmp.transform.localScale *= (0.5f+3*0.1f);   		//크기 (y값에 따라 원근감)

					
					float randI = Random.Range(-0.5f,0.5f);
					tmp.transform.position = transform.GetChild(2).transform.position - new Vector3(randI,0,3) ; // 위치

			Debug.Log("Boss");

			 
 	}

}
