using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour {

	// Use this for initialization

	
	[SerializeField]
	float startYspeed;

	[SerializeField]
	float startingPosY = 5 ;

	[SerializeField]
	string animatorTriggerName;
	void Start () {
	startingPosY =  transform.position.y;
			this.GetComponent<Rigidbody2D>().velocity =new Vector2 (-startYspeed, 0);

			if(this.GetComponent<Animator>().gameObject.activeSelf==true)
					GetComponent<Animator>().SetTrigger(animatorTriggerName);
	}
	public GameObject Hurb;
	public GameObject Meat;
	public GameObject Potion;
	public GameObject Cristal;
//	public GameObject Meat;
	// Update is called once per frame
	void FixedUpdate () {

			enemyMove();

			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

			if( transform.position.x < min.x){
			Destroy(gameObject);

		}

		if(Input.GetKeyDown("e"))
		{
			SpawnItem();
		}

	}

[SerializeField]
Vector2 jumpSpeed = new Vector2 ( 0, 20);

[SerializeField]
Vector2 forwardSpeed = new Vector2 (20, 0);

	void enemyMove()
	{

		if(transform.position.y <startingPosY)
		{
			this.GetComponent<Rigidbody2D>().gravityScale=0;

		}	


		if(this.GetComponent<Rigidbody2D>().gravityScale==0)
			enemyJump();


		enemyForward();
		
	}

[SerializeField]
float gravitySca;
	void enemyJump()
	{
		this.GetComponent<Rigidbody2D>().velocity += jumpSpeed;

		this.GetComponent<Rigidbody2D>().gravityScale=gravitySca;
	
	}
	
	void enemyForward()
	{

		if(this.GetComponent<Rigidbody2D>().velocity.x < 0.05f   )
		this.GetComponent<Rigidbody2D>().velocity += forwardSpeed;

		//this.GetComponent<Rigidbody2D>().gravityScale=gravitySca;
	
	}
	



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
	void OnTriggerEnter2D(Collider2D other)
	{



		if(other.tag == "Dino")
		{
//Hp 감소	
 			other.gameObject.GetComponent<Dino_Individual>().hpGage -= damageOfThis;

				Destroy(gameObject);
				GameObject dyinParti = (GameObject) Instantiate(dyingParticle,transform.position,Quaternion.identity);
				
				// other.gameObject.GetComponent<Dino_Individual>().hpGage -=Hp_Bar.CurrentHp;
				 other.gameObject.GetComponent<Dino_Individual>().HpGage();


		}

		if(other.tag == "Bullet")
		{
//Hp 감소	
			Hp_Bar. CurrentHp -= other.GetComponent<BulletScript>().totPower;
if(GetComponent<Animator>().isActiveAndEnabled)
			GetComponent<Animator>().SetTrigger("Rocken");

//hp =0 이면 죽음
			if(Hp_Bar. CurrentHp<=0)
			{
				Hp_Bar. CurrentHp=0;
//				GetComponent<Animator>().SetTrigger("Die");
			
				int getTM_rate = Random.Range(0, 500);

				if(getTM_rate ==100)
					SpawnItem();


				Destroy(gameObject);
				GameObject dyinParti = (GameObject) Instantiate(dyingParticle,transform.position,Quaternion.identity);

			}
 

				other.gameObject. SetActive(false);
//파티클 추가
//				Instantiate(ps, tranx	sform.position, Quaternion.identity);
		}


			{
		if(other.tag== "Bullet")
		{
			if(!onCD)
			{
			int random = Random.Range(0,1);
		//	StartCoroutine(CoolDownDamage());
			if(random ==0 )
			{

				//particle
//					GameObject bullet = (GameObject) Instantiate(ps, transform.position+ new Vector3 (Random.Range(-2,2),0,0) , Quaternion.identity); 


				// 데미지 + 스코어	
				
				//GameObject.FindGameObjectWithTag("AttackPowerText").GetComponent<Text>().text;
				//CombatTextManager.Instance.CreateText(transform.position + new Vector3(Random.Range(-1,1) ,2f), "+"+rndDmg.ToString(), Color.yellow, true);
			
				//GameObject.FindGameObjectWithTag("ScoreText").GetComponent<ScoreTextManager>().score_Real += rndDmg ;
				
//				Debug.Log("rnd dmg : " +rndDmg);
			}



			else
				{
					int rndDmg= Random.Range(11,20);
					//CombatTextManager.Instance.CreateText(transform.position + new Vector3 (Random.Range(-0.5f,0.5f) ,2f) , "-" +rndDmg.ToString(), Color.red, true);
					GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>().text = rndDmg.ToString();
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
    private EnemyStat Hp_Bar;


  void Awake() {
			        Hp_Bar.Initialize();
				
	}



void ExpToZero()
{
if(Hp_Bar.CurrentHp==Hp_Bar.MaxHp)
		{
			Hp_Bar.CurrentHp =0;
			Hp_Bar. MaxHp +=10;
	
 		}


}

public void Die()
{

					Destroy(gameObject);

			
					SpawnItem();
					


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
			tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}


			if(random==1)		
			{
			GameObject tmp =  Instantiate(Meat);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
			tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}
			
			if(random==2)		
			{
			GameObject tmp =  Instantiate(Hurb);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
			tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}
			if(random==3)		
			{
			GameObject tmp =  Instantiate(Cristal);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
			tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}

}


}

