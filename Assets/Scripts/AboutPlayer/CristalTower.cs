using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CristalTower : MonoBehaviour {


public int inven_Number;

 [SerializeField]
 int specialChar;

 /*
 0. Woods
 1. fire
 2. Water
 3. Electro
 4. Wind
 5. Earth
 6. Dark
 7. Light
 8. Iron
 9. Ice
 */
/////////////////////
	[SerializeField] 
	public float totalPower;

    [SerializeField] 
	private float powerLevel;
    [SerializeField] 
	private float adrenalineLv;
    [SerializeField] 
	private float criticalRateLv;
    [SerializeField] 
	private float critPowerLv;
	[SerializeField] 
	private float evolutionNumb;
////////////////////
	[SerializeField]
	private float autoLv;


	GameObject ControlTower ;

	Transform thisTransform;

//불꽃 공격력 때문
	int dinosLevel_before ;
	float powerLevel_before ;
 


	[SerializeField]
	private bool dead;


	[SerializeField]
	int EvolLv_1st =5;

	[SerializeField]
	int EvolLv_2nd =7;

void Start()
{
	ControlTower 	= GameObject.FindGameObjectWithTag("ControlTower").gameObject;
 
//	ControlTower.GetComponent<ControlTowerScript>().evolutionNumb[inven_Number]	= evolutionNumb;


// 게이지 업데이트
		HpGage();
	

// 로드 된 공룡 첫 상태 업데이트	
//	Update_DinoStatus();

	//ExpUpdate_ToBar();



//현재 transform 정의
	thisTransform = this.transform;
 

// 자동공격 실행
// 	Invoke("ShootingFire_Auto", 3-autoLv );


// exp canvas 포지션 정리
//	GameObject.FindGameObjectWithTag("ExpCanvas").transform.FindChild("ExpBar").gameObject.transform.FindChild("LevelText").transform.position =
//	transform.FindChild("LevelPosition").transform.position;

	}




void Update()
{

	inputCheck();
	
	
	if(hpGage<=0)
	{	
		dead=true;
		if(this.gameObject.name!="Tower")
		GetComponent<Animator>().SetTrigger("Dead");

		this.tag= "DinoDead";

		GetComponent<PolygonCollider2D>().enabled=(false);
		GetComponent<SpriteRenderer>().sortingLayerName="Item";
		
		transform.Find("Char_StatCanvas").gameObject.SetActive(false);
		transform.Find("Mouth").gameObject.SetActive(false);

	}

  

}






[SerializeField]
private int howManyEvolved;
[SerializeField]
int a=0;


void inputCheck()
{
	//진화 레벨 정하기
	



 

	if(!dead){
		
		{
			HpGage();
			CalculateTotPower();
		}



		if(Input.GetMouseButtonDown(0)){ 
			HpGage();
		}



	} 

}
 

 


///변화된 정보 컨트롤타워로 전송


[SerializeField]
private GameObject Fire;

[SerializeField]
private float fireSpeed;
[SerializeField]
private float fireMaxSpeed =100;

// 불꽃 공격력
void CalculateTotPower()
{
	//totalPower = dinosLevel*10 + powerLevel*10;
	
	//dinosLevel_before = dinosLevel;
	//powerLevel_before = powerLevel;
}


[SerializeField]
float powerGain= 2;

void ShootingFire(float totPower)
{	

		Animator thisAnimator= GetComponent<Animator>();
 
	//	thisAnimator.SetTrigger("Fire");


	Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

	
	totPower = totalPower;
	GameObject fireTmp =  Instantiate(Fire);
	
	fireTmp.transform.position = this.transform.Find("Mouth").transform.position;
	fireTmp.GetComponent<BulletScript>().totPower =totPower;
	//fireTmp.transform.SetParent(this.transform);

	// 불꽃 방향 + 힘
/*
	if( (MousePos-(Vector2) transform.position) .y <-0.05f && (MousePos-(Vector2) transform.position).x >7 )	
	{
			fireTmp.GetComponent<Rigidbody2D>().gravityScale *=-0.5f;
	}


	else
	{
		
	}

*/

	Vector3 CompareVector = (MousePos-(Vector2) transform.position);

	if( CompareVector.magnitude <fireMaxSpeed )
	fireTmp.GetComponent<Rigidbody2D>().AddForce((MousePos-(Vector2) transform.position)*powerGain);
	

	if(CompareVector.magnitude >=fireMaxSpeed )
	fireTmp.GetComponent<Rigidbody2D>().AddForce(CompareVector.normalized*fireMaxSpeed);


	if(MousePos.x- transform.position.x<0)
	{
		float a = transform.localScale.x;
		if(a >0)
		this.transform.localScale = new Vector3 (- a ,transform.localScale.y , transform.localScale.z )		;
		else if(a<0)
		this.transform.localScale = new Vector3 ( a ,transform.localScale.y , transform.localScale.z )	;
		
	}

	else if(MousePos.x- transform.position.x>0)
	{

		float a = transform.localScale.x;
		if(a >0)
		this.transform.localScale = new Vector3 (a ,transform.localScale.y , transform.localScale.z )		;
		else if(a<0)
		this.transform.localScale = new Vector3 ( - a ,transform.localScale.y , transform.localScale.z )	;
		
	}

}




[SerializeField]
private GameObject Ki;
	void OnMouseDown()
	{
	//기모으기
	

		if( transform.Find("Mouth").gameObject.activeSelf!=(false) && Ki!=null)
		{
		GameObject tmpKi = Instantiate(Ki);
		tmpKi.transform.position = transform.Find("Mouth").transform.position ;
		tmpKi.transform.SetParent(transform);
		}

		if(GetComponent<MoveCharacter>()!=null)
		GetComponent<MoveCharacter>().enabled=(true);


	}



bool onMouseOver=false;

void OnMouseOver()
{
	onMouseOver=true;
}
 


	
bool ifMouseOn = false;
bool ifAutoContinue = true;

[SerializeField]
Vector2 autoVector = new Vector2 (10, 7);
void ShootingFire_Auto()
{
	if(!ifMouseOn){
	

		Animator thisAnimator= GetComponent<Animator>();
		thisAnimator.SetTrigger("Fire");


 	GameObject fireTmp =  Instantiate(Fire);
	fireTmp.transform.position = this.transform.Find("Mouth").transform.position;
	fireTmp.GetComponent<BulletScript>().totPower =totalPower;
	//fireTmp.transform.SetParent(this.transform);

	fireTmp.GetComponent<Rigidbody2D>().gravityScale =0;
	if(this.transform.localScale.x>0)
	fireTmp.GetComponent<Rigidbody2D>().velocity = autoVector;

	else if(this.transform.localScale.x<0)
	fireTmp.GetComponent<Rigidbody2D>().velocity = -autoVector;

	int rand = Random.Range(1 , 3);
	Invoke("ShootingFire_Auto", 3- autoLv + rand * 0.5f );	

	}
}


//HP 체력 업그레이드
[SerializeField]
public float hpGage = 650;
[SerializeField]
public float maxHp = 650 ;


bool defeat =false;
public void HpGage()
{


 
	GameObject HpText_Trans = transform.Find("Char_StatCanvas").transform.Find("HpBar").gameObject;


// GAME OVER 게임오버
	if(hpGage<=0 )
	{
		hpGage=0;

		//Debug.Log("GameOver");
		if(defeat==false)
		
		{
			
			
			GameObject.FindGameObjectWithTag("SceneManager") .GetComponent<BattleScnee_CT>().Defeat();
			defeat =true;

			
		}
			//Instantiate(GameOverTxt);
		//
		//LoadGameOverScene(); //<< if Btmclicked
		//GetReward(); // Cristal && Gold in Game
		//GetComponent<Text>().txt= ControlTowerScript.controltowerScript.Coin_Battle
		//GetComponent<Text>().txt= ControlTowerScript.controltowerScript.Crst_Battle
		//GetComponent<Text>().txt= ControlTowerScript.controltowerScript.Exp_Battle
		//if Show Ads * Random.Range(2*5);
		//ControlTowerScript.controltowerScript.Coin += ControlTowerScript.controltowerScript.getCoinInBattle;
		//ControlTowerScript.controltowerScript.Crst += ControlTowerScript.controltowerScript.getCrstInBattle;
		// ControlTowerScript.controltowerScript.Crst_Battle=0;
		// ControlTowerScript.controltowerScript.Coin_Battle=0;
		// ControlTowerScript.controltowerScript.Exp_Battle =0;
	}

//	RageText_Trans.GetComponent<Text>().text = dinosExp.ToString();
	HpText_Trans.GetComponent<Bar_HP>().MaxHpValue = maxHp;

	HpText_Trans.GetComponent<Bar_HP>().Value = hpGage;

}






 


float exp_Before;
float maxExp_Before;

/*
이름
스프라이트이미지
레벨
진화정도
경험치
진화정도


공격력

init = 처음 공격력 = 10 
level +1 당 +10

ev =진화당 기본공격력 * 1.5배


레벨당
a = 아드레날린 공격력 % 5
b = 화력 업그레이드 기본공격력 +10
c = 크리티컬확률 업그레이드 +5%
d = 크리티컬 공격력 업그레이드 +5%



Attack = (init+ 10*(level-1)+)(1.5*exp(ev))*((100+a*5)/100)

 
 //////*

 
	[SerializeField]
	private DinoStat dinosStatus;


    [SerializeField]
	private Sprite spriteOfthis ;




	public int dinosSpecies;

	public string dinosName;
	public int dinosLevel; 
	public float dinosMaxExp;

	public float dinosExp;



	public bool colWithTarget;

*/
}
