using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Archer : MonoBehaviour {

	protected AudioSource audioSource;

	public AudioClip[] collideSound;

	
	void collideAudio()
	{
		int a = Random.Range(0,2);
		if(a==0)
			AudioSource.PlayClipAtPoint(collideSound[0] ,transform.position, 1);
		if(a==1)
			{		
					AudioSource.PlayClipAtPoint(collideSound[0] ,transform.position, 1f);
					AudioSource.PlayClipAtPoint(collideSound[1] ,transform.position, .6f);
			}
	}

	[SerializeField]
	string thisName;

	[SerializeField]
	float thisSpec;


    [SerializeField]
    private EnemyStat Hp_Bar;

	[SerializeField]
	int thisCoin;

	[SerializeField]
	int thisCrst;

	[SerializeField]
	int thisExp;

	[SerializeField]
	Vector2 forwardSpeed = new Vector2 ( -0.01f, 0);



	[SerializeField]
	float backWardX = 0.1f;

	[SerializeField]
	float startYspeed;

	[SerializeField]
	float startingPosY = 5 ;


	Rigidbody2D thisBody;
	void Start () {
	thisBody = GetComponent<Rigidbody2D>();
	startingPosY =  transform.position.y;
			this.GetComponent<Rigidbody2D>().velocity =new Vector2 (-startYspeed, 		
			this.thisBody.velocity.y);


	if(this.GetComponent<Animator>()!=null)
			if(this.GetComponent<Animator>().gameObject.activeSelf==true){
//					GetComponent<Animator>().SetTrigger(animatorTriggerName);
		
		
	StartCoroutine("CoroutFixedUpdate");
			}	
if(this.GetComponent<MoveUpDown>()!=null)
			this.GetComponent<MoveUpDown>().enabled=true;
			

int b = ControlTowerScript.controlTowerScript.mapImg;
int a=  (ControlTowerScript.controlTowerScript.battleStageLevel);
// // 스테이지에 따라 공격력  hp증가
// 			damageOfThis *= (int) Mathf.Round( a*(b+1)*(1+0.5f));
			
			
// 			Hp_Bar. MaxHp *= (b+1)* (1+ Mathf.Round((Mathf.Pow(a,2))*(1+0.5f)));
// 			Hp_Bar. CurrentHp *=(b+1)* (1+ Mathf.Round( (Mathf.Pow(a,2))*(1+0.5f)));

			damageOfThis *= b*5 + a*3;
			
			
			Hp_Bar. MaxHp *=  (b*30 + a*3)*3;
			Hp_Bar. CurrentHp *= (b*30 + a*3)*3;

 			Hp_Bar.Initialize();


			bulletPower *=  Mathf.Round( a*(1+0.5f));

	}
	public GameObject Hurb;
	public GameObject Meat;
	public GameObject Potion;
	public GameObject Cristal;
//	public GameObject Meat;
	// Update is called once per frame


	IEnumerator CoroutFixedUpdate () {


		if(this.thisBody!=null){
			enemyMove();

		
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
	
			
		

//		MoveToDino();
FindDino();
		


		if(Input.GetKeyDown("e"))
		{
			SpawnItem();
		}


		if(GameObject.FindGameObjectsWithTag("Dino") ==null)
		this.thisBody.velocity = new Vector3 (0,0,0);
		}

		else
		{
			
		}

	if(distance<= distanceFromDino_2)
	{
		//this.thisBody.velocity = new Vector3 (0,0,0);
		
	}


yield return new WaitForSeconds(0.1f);
				StartCoroutine("CoroutFixedUpdate");

	}

[SerializeField]
Vector2 jumpSpeed = new Vector2 ( 0, 20);




	void enemyMove()
	{ 
		//FindNextPos();
		
		enemyForward();


	}






[SerializeField]
float gravitySca; 
void enemyForward()
	{

		//if(this.thisBody.velocity.x >0f   )
		this.thisBody.velocity = new Vector3 (forwardSpeed.x, this.thisBody.velocity.y ) ;

		//this.thisBody.gravityScale=gravitySca;

	}
	

	void enemyBackWard()
	{

		this.transform.position -= new Vector3(backWardX ,0,0);

	}

	void ShakeCam()
	{

	}

[SerializeField]
bool turn;

/*
[SerializeField]
private int distToDino =20;

[SerializeField]
private Vector3 dirToDino;
	void MoveToDino()
	{

		if(GameObject.FindGameObjectsWithTag("Dino") !=null)
					dinos = GameObject.FindGameObjectsWithTag("Dino");
		if(dinos.Length>0)
		{
			distance=  (this.transform.position - dinos[0].transform.position  ).magnitude;	
		
		for(int a=0; a <dinos.Length ; a++  )
		{
		
			if(distToDino >= (this.transform.position - dinos[a].transform.position ).magnitude )
				
				{
					distance=  (this.transform.position - dinos[a].transform.position  ).magnitude;	
 
					dirToDino = dinos[a].transform.position  - this.transform.position;
				 			this.thisBody.velocity = dirToDino.normalized * Mathf.Abs(forwardSpeed.x);


 				}
				
				if(dinos[a].GetComponent<Animator>()!=null)
				if(dinos[a].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Dead"))
				{

				if(a<dinos.Length-1)
				distance = (this.transform.position - dinos[a+1].transform.position  ).magnitude;	
				else
				distance=distanceFromDino+1;
 				}


			}

		}


	}
*/
/*
[SerializeField]
Vector3 nextPos;
[SerializeField]
Vector3 plusVectorForPos;

[SerializeField]
bool getThePos=false;
[SerializeField]
float MoveVel;
	void FindNextPos()
	{
		if(getThePos==false)
			{
				nextPos =  this.transform.position + plusVectorForPos;
				getThePos=true;
			}
		MoveToNextPos();
	}


	void MoveToNextPos()
	{
		if((this.transform.position-nextPos).magnitude>0.1f)
		{
			this.transform.position+= (nextPos-transform.position)*MoveVel;
		}
		else if((this.transform.position-nextPos).magnitude<0.1f)
		{
			getThePos=false;
			plusVectorForPos =   new Vector3 (plusVectorForPos.x,-plusVectorForPos.y);
			FindNextPos();
		}
	}
*/



bool onCD;
// 뭔가를 만났을때!



		private IEnumerator CoolDownDamage()
	{
		onCD = true;
		yield return new WaitForSeconds(2);
		onCD = false;

	}
int score;

public GameObject ps;

public float rndDmg;

[SerializeField]
int damageOfThis=10;

[SerializeField]
int oneTime=0;
	void OnTriggerEnter2D(Collider2D other)
	{



		if(other.tag == "Dino" && thisName!="boss")
		{
//Hp 감소	
 		if(other.gameObject.GetComponent<Dino_Individual>()!=null)
			other.gameObject.GetComponent<Dino_Individual>().hpGage -= damageOfThis;
		else if(other.gameObject.GetComponent<CristalTower>()!=null)
			other.gameObject.GetComponent<CristalTower>().hpGage -= damageOfThis;


				Destroy(gameObject);
				GameObject dyinParti = (GameObject) Instantiate(dyingParticle,transform.position,Quaternion.identity);
				
				// other.gameObject.GetComponent<Dino_Individual>().hpGage -=Hp_Bar.CurrentHp;
	if(other.gameObject.GetComponent<Dino_Individual>()!=null)

				 other.gameObject.GetComponent<Dino_Individual>().HpGage();


		}

		if(other.tag == "Bullet")
		{
//Hp 감소	
		enemyBackWard();
			Hp_Bar. CurrentHp -= other.GetComponent<BulletScript>().totPower;
if(GetComponent<Animator>().isActiveAndEnabled)
			GetComponent<Animator>().SetTrigger("Rocken");

	

//hp =0 이면 죽음
			if(Hp_Bar. CurrentHp<=0&& oneTime==0)
			{

				oneTime=1;
				Hp_Bar. CurrentHp=0;
//				GetComponent<Animator>().SetTrigger("Die");
			
				int getTM_rate = Random.Range(0, 500);

			//	if(getTM_rate ==100)
				//	SpawnItem();


				Destroy(gameObject);
				GameObject dyinParti = (GameObject) Instantiate(dyingParticle,transform.position,Quaternion.identity);


// 코인겟

				int b = ControlTowerScript.controlTowerScript.mapImg;
				int d=  (ControlTowerScript.controlTowerScript.battleStageLevel);
								


				ControlTowerScript.controlTowerScript.Coin_Battle += thisCoin* d *(b+1);
			    ControlTowerScript.controlTowerScript.Exp_Battle += thisExp;

// 보스면 빅토리 + 크리스탈
				if(thisName=="boss")
				{
					
					thisCrst += (d-1) *(b+1);
						
						GameObject.FindGameObjectWithTag("SceneManager") .GetComponent<BattleScnee_CT>().Victory();
				
						ControlTowerScript.controlTowerScript.Crst_Battle += thisCrst;
				
						GameObject[] enemies = GameObject.FindGameObjectsWithTag("Target");
						for(int a=0; a< GameObject.FindGameObjectsWithTag("Target").Length ; a++)
						{
							Destroy(enemies[a].GetComponent<Rigidbody2D>());

						}
				}

			}
 

				other.gameObject. SetActive(false);
//파티클 추가
//				Instantiate(ps, tranx	sform.position, Quaternion.identity);
		}


			{
				
		if(other.tag== "Bullet")
		{	
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraZoom>().shakecam=true;
			
			if(!onCD)
			{
			int random = Random.Range(0,1);
			rndDmg =			other.GetComponent<BulletScript>().totPower;

		//	StartCoroutine(CoolDownDamage());
			if(random ==0 )
			{ 
			}


			}
		}



		}

	}



	public Vector3 MouseInsertPos;
	
	 void OnMouseDown()
	 {


			MouseInsertPos =Camera.main.ScreenToWorldPoint(Input.mousePosition);

				{
				//GameObject.FindGameObjectWithTag("DinosGun1").GetComponent<DinosGun>().FireDinosBullet(MouseInsertPos);
			}
			

	 }


[SerializeField]
float distanceFromDino;

[SerializeField]
float distanceFromDino_2;




[SerializeField]
float distance=100;

[SerializeField]
int bulletIf;

GameObject[] dinos;


	 void FindDino()
	 {

		

		if(GameObject.FindGameObjectsWithTag("Dino") !=null)
					dinos = GameObject.FindGameObjectsWithTag("Dino");
		
		
		else
					dinos = GameObject.FindGameObjectsWithTag("DinoDead");

		
		if(dinos.Length>0)
		{
			distance=  (this.transform.position - dinos[0].transform.position  ).magnitude;	
		
		for(int a=0; a <dinos.Length ; a++  )
		{
		
			if(distance >= (this.transform.position - dinos[a].transform.position ).magnitude )
				
				{
					distance=  (this.transform.position - dinos[a].transform.position  ).magnitude;	

					if(this.transform.Find("Mouth")!=null )
						bulletDir = dinos[a].transform.position  - this.transform.Find("Mouth").transform.position;
					else
					{ 
						bulletDir = dinos[a].transform.position  - this.transform.position;

					}
 				}
				
				if(dinos[a].GetComponent<Animator>()!=null)
					if(dinos[a].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Dead"))
					{

						if(a<dinos.Length-1)
						distance = (this.transform.position - dinos[a+1].transform.position  ).magnitude;	
						
						else
						distance=distanceFromDino+1;
					}

			}

	
		}


		else
		{


//				distance=distanceFromDino+1;

		


		}

 		
		 if( distance <=distanceFromDino)
		 {
			 if(bullet!=null)
			 this.GetComponent<Rigidbody2D>().velocity = new Vector3 ( 0, 0);
		 
			 if(bulletIf==0)
			 {
				 if(bullet!=null)
				 Invoke("ShootBullet",0.2f);
				 else if(bullet==null)
				 Invoke("ShootBullet",0.01f);

				bulletIf=1;
			 }

		 }

		 else
		 {
			 CancelInvoke();
			 bulletIf=0;
		 }

		

	 }




[SerializeField]
GameObject bullet;
[SerializeField]
GameObject shortBullet;
[SerializeField]
float shootingTerm;

[SerializeField]
float bulletPower;

[SerializeField]
Vector3 bulletDir;
[SerializeField]
float bulletSpeed=10;
	 void ShootBullet()
	 {

			 	if(this.GetComponent<MoveUpDown>()!=null)
					{
						Destroy(this.GetComponent<MoveUpDown>());
					}
		 if(bullet!=null){
		 GameObject tmp = Instantiate(bullet);
		
			if( this.transform.Find("Mouth")!=null)
			tmp.transform.position= this.transform.Find("Mouth").transform.position + new Vector3(0,0.5f,0);
		
			else if( this.transform.Find("Mouth")!=null)
			tmp.transform.position= this.transform.position + new Vector3(-0.3f,0,0);
		
		 
		tmp.GetComponent<Rigidbody2D>().AddForce(bulletDir*bulletSpeed);

		 tmp.GetComponent<EnemyBullet>().totPower = bulletPower;

		 Invoke("ShootBullet",shootingTerm);
		 }

		 else{
		 this.thisBody.velocity = bulletDir.normalized * Mathf.Abs(forwardSpeed.x);
		Invoke("ShootBullet",shootingTerm);

	 	}

	 }
	 void ShootBullet_2()
	 {
		 if(bullet!=null){
		 GameObject tmp = Instantiate(shortBullet);
		 tmp.transform.position= this.transform.position + new Vector3(0,0.5f,0);
		 tmp.GetComponent<Rigidbody2D>().AddForce(bulletDir*bulletSpeed);

		 tmp.GetComponent<EnemyBullet>().totPower = bulletPower;

		 Invoke("ShootBullet_2",shootingTerm);
		 }

		 else{
		 this.GetComponent<Rigidbody2D>().velocity = bulletDir.normalized * Mathf.Abs(forwardSpeed.x);
		Invoke("ShootBullet",shootingTerm);

	 	}

	 }


  void Awake() {
	  
	  
	  
int b = ControlTowerScript.controlTowerScript.mapImg;
int a=  (ControlTowerScript.controlTowerScript.battleStageLevel);
// 스테이지에 따라 공격력  hp증가
		//	damageOfThis *= (int) Mathf.Round( b*(1+0.5f));
			
			// Hp_Bar. MaxHp *=1+ Mathf.Round((Mathf.Pow(b,2))*(1+0.5f));
			// Hp_Bar. CurrentHp *=1+ Mathf.Round( (Mathf.Pow(b,2))*(1+0.5f));

			        Hp_Bar.Initialize();
				
	}


 

public void Die()
{

					Destroy(gameObject);

			
				int getTM_rate = Random.Range(0, 500);

			//	if(getTM_rate ==100)
				//	SpawnItem();
					


}


[SerializeField]
private GameObject dyingParticle ;

public void DyingParticle()
{

						GameObject dyinParti = (GameObject) Instantiate(dyingParticle,transform.position,Quaternion.identity);

}



public GameObject HelperEgg;



//캐릭터 죽였을때 아이템 확률

private void SpawnItem()
{

	int random = Random.Range(0,5);

			if(random==0)		
			{
			GameObject tmp =  Instantiate(Potion);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
	//		tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}


			if(random==1)		
			{
			GameObject tmp =  Instantiate(Meat);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
	//		tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}
			
			if(random==2)		
			{
			GameObject tmp =  Instantiate(Hurb);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
	//		tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}
			if(random==3)		
			{
			GameObject tmp =  Instantiate(Cristal);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
	//		tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}

}


}
