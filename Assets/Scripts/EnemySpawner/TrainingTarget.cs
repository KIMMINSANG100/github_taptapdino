	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingTarget : MonoBehaviour {
	[SerializeField]
	float rewardExp=10;

	[SerializeField]
	float startingPosY ;

	protected AudioSource audioSource;

	public AudioClip[] collideSound;
	
	void collideAudio()
	{
		int a = Random.Range(0,2);
		if(a==0)
			AudioSource.PlayClipAtPoint(collideSound[0] ,transform.position, 1);
		if(a==1)
			{	
			}
	}




	Vector3 thisStartPos;

	[SerializeField]
	string animatorTriggerName;
	void Start () { 
		thisStartPos = this.transform.position;

		Hp_Bar. MaxHp *=(factorHp+1);
		Hp_Bar.CurrentHp*=(factorHp+1);

 	}
	
//	public GameObject Meat;
	// Update is called once per frame
	void FixedUpdate () {

 
		
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

			if( transform.position.x < min.x){
	// 			Destroy(gameObject);

		} 

	} 

[SerializeField]
Vector2 jumpSpeed = new Vector2 ( 0, 20);


[SerializeField]
Vector2 forwardSpeed = new Vector2 ( 20, 0);
 

[SerializeField]
float gravitySca; 

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
		
 
		StartCoroutine("Rocking");

			Hp_Bar. CurrentHp -= other.GetComponent<BulletScript>().totPower;

			GetComponent<Animator>().SetTrigger("Rocken");

//hp =0 이면 죽음
			if(Hp_Bar. CurrentHp<=0)
			{
 
				Hp_Bar. CurrentHp=0;
//				GetComponent<Animator>().SetTrigger("Die");
			
				GameObject.FindGameObjectWithTag ("Dino").GetComponent<Dino_Individual> ().dinosExp += rewardExp;
				CombatTextManager.Instance.CreateExpText(transform.Find("Spawner").transform.position + new Vector3(0 ,2f), "+"+rewardExp.ToString(), new Color32(150,216,255,255), true);

				Destroy(gameObject);
				GameObject dyinParti = (GameObject) Instantiate(dyingParticle,transform.position,Quaternion.identity);
				Die();

				GameObject.FindGameObjectWithTag ("ControlTower").GetComponent<ControlTowerScript> ().smashed++;
			}



//hp =0 이면 죽음
			if(Hp_Bar. CurrentHp<=0)
			{
				Hp_Bar. CurrentHp=0;
				
 				CamRock();
				Destroy(gameObject);

			}
//			Instantiate(ps );

			//	other.gameObject. SetActive(false);
//파티클 추가
//				Instantiate(ps, tranx	sform.position, Quaternion.identity); 
 

			if(GameObject.FindGameObjectWithTag("Player")!=null)
			GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Dino_Individual>().ExpUpdate_ToBar();

				if(!onCD)
			{
			int random = Random.Range(0,10);
			rndDmg =			other.GetComponent<BulletScript>().totPower;

			//critical 크리티컬
 
 			if(random ==5 )
			{ 

				if(CamshakeManager.camshakeManager.inShop ==false)
				{
					AudioSource.PlayClipAtPoint(collideSound[0] ,transform.position, 1f);
					AudioSource.PlayClipAtPoint(collideSound[1] ,transform.position, .6f);
				}
				CamRock();


				rndDmg*=2;
				
				int extraFire = Random.Range(0,3);
				rndDmg+=extraFire;

				CombatTextManager.Instance.CreateText(transform.Find("Spawner").transform.position + new Vector3(Random.Range(-1,1) ,2f), "+"+rndDmg.ToString(), Color.yellow, true);
			
				GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().coins+= rndDmg;


				
 			}



				else
				{
					if(CamshakeManager.camshakeManager.inShop ==false)
						AudioSource.PlayClipAtPoint(collideSound[0] ,transform.position, 1);


				int extraFire = Random.Range(0,3);
				rndDmg+=extraFire;
 				
				CombatTextManager.Instance.CreateText(transform.Find("Spawner").transform.position + new Vector3(Random.Range(-1,1) ,2f), "+"+rndDmg.ToString(), Color.yellow, false);
			
				GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().coins+= rndDmg;

				
				}

// 					audioSource.Play ();
			
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

	public int factorHp;
  void Awake() {
 			        Hp_Bar.Initialize();



		{/*
			audioSource = GetComponent<AudioSource> ();
			audioSource.clip = audioClip;
			audioSource.Play ();*/
		}
	}

//확인 CamRock
 void CamRock()
{

				if(CamshakeManager.camshakeManager.camShake==true&&CamshakeManager.camshakeManager.inShop ==false)
				{
					Transform MainCam =GameObject.FindGameObjectWithTag("MainCamera").transform;

					if(MainCam.position.x <3  && MainCam.position.y>-3)
					MainCam.GetComponent<Animator>().SetTrigger("Critical");
				}
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



public GameObject Helper1;
public GameObject Helper2;
public GameObject Helper3;
public GameObject Item_m;
public GameObject Item_h;
public GameObject Item_p;

public GameObject Cristal;
public GameObject Coins;


private void SpawnItem()
{
		int a = (int)GameObject.FindGameObjectWithTag ("ControlTower").GetComponent<ControlTowerScript> ().sumOfPowers;
		int random = Random.Range(0,500+Mathf.RoundToInt(a/10));

			if(random>=0 && random<9)		
			{
			GameObject tmp =  Instantiate(Item_m);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
			tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}


			else if(random>=10 && random <19)		
			{
			GameObject tmp =  Instantiate(Item_p);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
			tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}
			else if(random>=20 && random<22)		
			{
			GameObject tmp =  Instantiate(Item_h);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
			tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}
			else if(random>=30 && random<35)		
			{
			GameObject tmp =  Instantiate(Helper1);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
			tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}

			else if(random>=40 && random <= 45)		
			{
			GameObject tmp =  Instantiate(Helper2);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
			tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}

			else if(random>=50 && random <55)		
			{
			GameObject tmp =  Instantiate(Helper3);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
			tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}

			else if(random>=60 && random <62)		
			{
			GameObject tmp =  Instantiate(Cristal);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
			tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}
			
			else if(random>=70 && random <76)		
			{
			GameObject tmp =  Instantiate(Coins);
			tmp.transform.position = this.transform.position + new Vector3 (0, 3);
			tmp.GetComponent<Rigidbody2D>().AddForce( new Vector2 ( -2, 2)*100);
			}

}

public void Rocken1()
	{
		transform.position =new Vector3( thisStartPos.x , this.transform.position.y);
 	}


public void Rocken2()
	{
		transform.position -= new Vector3(-0.2f,0);
 	}



private IEnumerator Rocking()
	{
		this.transform.position = new Vector3( thisStartPos.x , this.transform.position.y);

		Rocken2();
		yield return new WaitForSeconds(0.02f);
		Rocken1();
		yield return new WaitForSeconds(0.02f);
		Rocken2();
		yield return new WaitForSeconds(0.02f);
		Rocken1();
		yield return new WaitForSeconds(0.02f); 
		Rocken2();
		yield return new WaitForSeconds(0.02f);
		Rocken1();
		yield return new WaitForSeconds(0.02f); 
		StopCoroutine("Rocking");
	}

}


