using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dino_Individual : MonoBehaviour {

public AudioClip[] dinoSound;
public AudioClip fireSound;

void FireSoundSet()
{
//화면 벗어나면 소리안들리도록
 			Vector2 screenPoint = Camera.main.WorldToViewportPoint(new Vector2(1,1));
 		
			if(sceneNumber!=1 ||(( screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1) &&CamshakeManager.camshakeManager.inShop ==false)){
 			
			
			AudioSource.PlayClipAtPoint(dinoSound[howManyEvolved] ,transform.position, .7f);
			AudioSource.PlayClipAtPoint(fireSound ,transform.position,1f);
 
		}	

}


public int inven_Number; 

	[SerializeField] 
	public int dinosSpecies;


 [SerializeField]
 public int specialChar;


[SerializeField]
private int howManyEvolved;

	[SerializeField]
	int EvolLv_1st =5;

	[SerializeField]
	int EvolLv_2nd =7;



	[SerializeField] 
	public float totalPower;

    [SerializeField] 
	private float powerLevel;

[SerializeField]
private int rageFactor;
[SerializeField]
public float hpGage = 650;
[SerializeField]
public float maxHp = 650 ;
public float maxRage = 650 ;

public bool thisisisisis;
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
	[SerializeField] 
	public string dinosName;
  /////////////////////
	[SerializeField] 
	public int	 dinosLevel; 
	[SerializeField] 
	public float dinosMaxExp;
	[SerializeField] 
	private float dinosTotalExp;

	[SerializeField] 
	public float dinosExp;
/////////////////////
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
	public float autoLv;


	GameObject ControlTower ;

	Transform thisTransform;

//불꽃 공격력 때문
	int dinosLevel_before ;
	float powerLevel_before ;
 


	[SerializeField]
	private bool dead;
 

	int sceneNumber ;


	float clickAutoFactor ;

	float HasteAuto = 26;

	float AdAuto =27;

	Animator thisAnimator;
void Start()
{ 	
	/////////// ads 통한 오토공격
	if(EggSpawnManager.Instances.ad10mAuto==true)
		autoTime = 3- AdAuto*0.1f;
	/////////


	thisAnimator = this.GetComponent<Animator>();
	autoOnOff=true;
	
	autoTime = 3- autoLv*0.1f;
	clickAutoFactor=1;
	
	evolutionNumb= specialChar; 

	ControlTower 	= GameObject.FindGameObjectWithTag("ControlTower").gameObject;

	sceneNumber = ControlTowerScript.controlTowerScript.SceneNumber; // 씬넘버 확인


	ControlTowerScript.controlTowerScript.bookChar[dinosSpecies]=true; // 도감 채우기


	if(ControlTowerScript.controlTowerScript.SceneNumber!=2) // 디펜스에서 인벤넘버 받아오기
	ControlTowerScript.controlTowerScript.dinosSpecies[inven_Number] 	= dinosSpecies;
	
	
///////////////	DinoBookManager.dinoBook.CallBookInfo_FromCT();

	 rageOn=false;

//	ControlTower.GetComponent<ControlTowerScript>().evolutionNumb[inven_Number]	= evolutionNumb;


// 게이지 업데이트
		RageGage();
		HpGage();
	

// 로드 된 공룡 첫 상태 업데이트	
	Update_DinoStatus();

	ExpUpdate_ToBar();

	
	autoLv= ControlTowerScript.controlTowerScript.publicAutoLv;
//현재 transform 정의
	thisTransform = this.transform;
 

// 자동공격 실행
			int rand = Random.Range(1 , 3); 

			Invoke("ShootingFire_Auto",  autoTime +rand*0.2f	);



// 화면에 대해서 기능 추가 / 제거
	//if(sceneNumber==1)
	{

		GetComponent<MoveCharacter>().enabled =false;
		GetComponent<Dino_Skills>().enabled =false;

	}


	ControlTower.GetComponent<ControlTowerScript>().bookChar[dinosSpecies]=true;


}
/////////////////////////////////////////////////////////////////////////////////////////////////////////




void Update()
{
	autoOnOff= ControlTowerScript.controlTowerScript.autoOn;
	inputCheck();

// rage factor 공격력
	
	if(this.thisAnimator.GetCurrentAnimatorStateInfo(1).IsName("RageOn"))
	totalPower = ((dinosLevel*1 + (powerLevel-1)*1) *(howManyEvolved+1))*rageFactor;

	else
	{
	totalPower = ((dinosLevel*1 + (powerLevel-1)*1) *(howManyEvolved+1));
	}

	

// 죽었을때

if(hpGage<=0)
{	
	dead=true;
	thisAnimator.SetTrigger("Dead");

	this.tag= "DinoDead";

	GetComponent<PolygonCollider2D>().enabled=(false);
	GetComponent<SpriteRenderer>().sortingLayerName="Item";
	
	transform.Find("Char_StatCanvas").gameObject.SetActive(false);
	transform.Find("Mouth").gameObject.SetActive(false);

}


if(!dead){
	if(rageOn)
	{
		RageGage();
		thisAnimator.SetTrigger("RageOn");
		rageOn=false;
	}

// 데이타세이브 체크 키 a

	Exp_WhenLevelUp();

	exp_Before = dinosExp;

	}

	if(GameObject.FindGameObjectWithTag("ExpCanvas")!=null)
	ControlTowerScript.controlTowerScript.dinosExp[inven_Number]=dinosExp;
}






[SerializeField]
int a=0;
int touch=0;
float autoTime;
void inputCheck()
{
	HpGage();
	//진화 레벨 정하기
		if(dinosLevel>=EvolLv_1st && a==0) 
 	{

  	ControlTowerScript.controlTowerScript.bookChar[dinosSpecies]=true;
		
	ControlTower 	= GameObject.FindGameObjectWithTag("ControlTower").gameObject;
	 if( howManyEvolved==0)
 		ControlTower.GetComponent<CharacterInstantiating>().Instantiate_EvolutionChar(inven_Number,dinosSpecies);
				
		a++;

		
		Save_DinoStatus();	
  	}
	
	
 	if(dinosLevel>=EvolLv_2nd && a==1 )
 	{
 
 	ControlTowerScript.controlTowerScript.bookChar[dinosSpecies-1]=true;
 	ControlTowerScript.controlTowerScript.bookChar[dinosSpecies]=true;
		
 		  if( howManyEvolved==1)
			ControlTower.GetComponent<CharacterInstantiating>().Instantiate_EvolutionChar(inven_Number,dinosSpecies);

			a++;
// 			InventoryManager.Inventory.invenInit();
// 			DinoBookManager.dinoBook.CallBookInfo_FromCT();
 			Save_DinoStatus();

  	}

 
	if(!dead){
		if(dinosLevel!= dinosLevel_before|| powerLevel!=powerLevel_before)
		{
			HpGage();
			CalculateTotPower();
		}
		if(Input.touchCount==1){
		}

		if(Input.touchCount==0){
		}
			if(Input.GetMouseButtonDown(0)&&Time.timeScale!=0)
						clickAutoFactor*=2;



/// 마우스 눌렀을때
	if((Input.touchCount!=touch ||Input.GetMouseButtonDown(0) )&& Input.touchCount<4 &&Time.timeScale!=0){
			
///////////////////////////////////////

	if(this.thisAnimator.GetCurrentAnimatorStateInfo(1).IsName("Haste"))
		autoTime = 3- HasteAuto*0.1f;
	
	else if(EggSpawnManager.Instances.ad10mAuto==true)
		autoTime = 3- AdAuto*0.1f;

	else
 		autoTime = 3- autoLv*0.1f;
			
			ifMouseOn = true;
			
			if(onMouseOver==false){
			
				ShootingFire(totalPower);

				if(EggSpawnManager.Instances.ad5mAtk2times==true)
				StartCoroutine(adShoot());
			}
			RageGage(); 
			
			HpGage(); 
		
 	 
	
		

		} 

		
		if(Input.GetMouseButtonUp(0)&&Time.timeScale!=0){
			clickAutoFactor*=0.5f;
			int rand = Random.Range(1 , 3);
 

			ifMouseOn = false;
			CancelInvoke("ShootingFire_Auto");

			Invoke("ShootingFire_Auto",  autoTime +rand*0.2f);
			 	
		//	thisAnimator.SetTrigger("Fire");

			onMouseOver=false;
		
			if(GetComponent<MoveCharacter>() !=null)
			GetComponent<MoveCharacter>().enabled=false;

		}

	///////////////////////////////////////////
	}

		if(this.tag == "DinoDead")
		{
			CancelInvoke("ShootingFire_Auto");
		}

		touch = Input.touchCount;
}
 

IEnumerator adShoot()
{
	yield return new WaitForSeconds(0.1f);
	ShootingFire(totalPower);

}
 


///변화된 정보 컨트롤타워로 전송	


[SerializeField]
private GameObject Fire;

private BulletScript Fire2;

[SerializeField]
private float fireSpeed;
[SerializeField]
private float fireMaxSpeed =100;

// 불꽃 공격력
void CalculateTotPower()
{
	if(this.thisAnimator.GetCurrentAnimatorStateInfo(1).IsTag("RageOn"))
	totalPower = ((dinosLevel*1 + (powerLevel-1)*1) *(howManyEvolved+1))*rageFactor;

	else
	{
	totalPower = ((dinosLevel*1 + (powerLevel-1)*1) *(howManyEvolved+1));
	}
	
	
	dinosLevel_before = dinosLevel;
	powerLevel_before = powerLevel;
}


[SerializeField]
float powerGain= 2;

void ShootingFire(float totPower)
{	

		Animator thisAnimator= GetComponent<Animator>();
 
		thisAnimator.SetTrigger("Fire");
		FireSoundSet();

	Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

	
	totPower = totalPower;
	BulletScript fireTmp =  Instantiate(Fire.GetComponent<BulletScript>());
	Rigidbody2D fireBody = fireTmp.GetComponent<Rigidbody2D>();
	if(autoLv>17)
	{	
		fireTmp.transform.Find("Particle System").gameObject.SetActive(false);
	}

	
	fireTmp.transform.position = this.transform.Find("Mouth").transform.position;
	
	fireTmp.GetComponent<BulletScript>().totPower =totPower;

	if(this.thisAnimator.GetCurrentAnimatorStateInfo(1).IsName("RageOn"))
		fireTmp.transform.localScale*=2f;

	if(this.thisAnimator.GetCurrentAnimatorStateInfo(1).IsName("Haste"))
		fireTmp.transform.localScale*=2f;

 
	//fireTmp.transform.SetParent(this.transform);

	// 불꽃 방향 + 힘
/*
	if( (MousePos-(Vector2) transform.position) .y <-0.05f && (MousePos-(Vector2) transform.position).x >7 )	
	{
			fireBody.gravityScale *=-0.5f;
	}


	else
	{
		
	}

*/

	if(sceneNumber!=1)
	{
	Vector3 CompareVector = (MousePos-(Vector2) transform.Find("Mouth").transform.position);

	if( CompareVector.magnitude <fireMaxSpeed )
	fireBody.AddForce((MousePos-(Vector2) transform.Find("Mouth").transform.position)*powerGain);
	

	if(CompareVector.magnitude >=fireMaxSpeed )
	fireBody.AddForce(CompareVector.normalized*fireMaxSpeed);
	

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

	else
	{
//---메인씬 공격 방향
	Vector3 CompareVector = (MousePos-(Vector2) transform.Find("Mouth").transform.position);
	CompareVector = new Vector3 ( Mathf.Abs(CompareVector.x),CompareVector.y);

	if(CompareVector.x <1)
	CompareVector = CompareVector = new Vector3 (1,CompareVector.y);

	if( CompareVector.magnitude <fireMaxSpeed )
	{
	fireBody.AddForce( CompareVector*powerGain*1.5f);
	}

	if(CompareVector.magnitude >=fireMaxSpeed )
	fireBody.AddForce(CompareVector.normalized*fireMaxSpeed*1.5f);
	

	/*float Yrand = Random.Range(-1,1);
	Vector3 CompareVector = new Vector3 (fireMaxSpeed*10,Yrand*fireMaxSpeed);
	fireBody.AddForce(CompareVector);
	*/

	}

 
	CancelInvoke("ShootingFire_Auto");
	Invoke("ShootingFire_Auto", (autoTime)/clickAutoFactor );	
}



[SerializeField]
private GameObject Ki;
	void OnMouseDown()
	{
	//기모으기
	
/*
		if( transform.FindChild("Mouth").gameObject.activeSelf!=(false) )
		{	

	
		GameObject tmpKi = Instantiate(Ki);
		tmpKi.transform.position = transform.FindChild("Mouth").transform.position ;
		tmpKi.transform.SetParent(transform);
		}
*/
		//GetComponent<MoveCharacter>().enabled=(true);


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
public bool autoOnOff;
void ShootingFire_Auto()
{

if(autoOnOff==true){
	if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("Haste"))
		autoTime = 3- HasteAuto*0.1f;

	else if(EggSpawnManager.Instances.ad10mAuto==true)
		autoTime = 3- AdAuto*0.1f;

	else
 		autoTime = 3- autoLv*0.1f;
 	 

	//if(!ifMouseOn)
	{
	

		Animator thisAnimator= GetComponent<Animator>();
		thisAnimator.SetTrigger("Fire");
		FireSoundSet();

 	GameObject fireTmp =  Instantiate(Fire);
	Rigidbody2D fireBody = fireTmp.GetComponent<Rigidbody2D>();
	if(autoLv>17)
	{
		fireTmp.transform.Find("Particle System").gameObject.SetActive(false);
	}

	fireTmp.transform.position = this.transform.Find("Mouth").transform.position;
	fireTmp.GetComponent<BulletScript>().totPower =totalPower;
	//fireTmp.transform.SetParent(this.transform);

	fireBody.gravityScale =0;
	if(this.transform.localScale.x>0)
	fireBody.velocity = autoVector;

	else if(this.transform.localScale.x<0)
	fireBody.velocity = -autoVector;

	if(Input.touchCount==1){
		Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector3 CompareVector = (MousePos-(Vector2) transform.Find("Mouth").transform.position);
		CompareVector = new Vector3 ( Mathf.Abs(CompareVector.x),CompareVector.y);

		if(CompareVector.x <1)
		CompareVector = CompareVector = new Vector3 (1,CompareVector.y);

		if( CompareVector.magnitude <fireMaxSpeed )
		{
		fireBody.AddForce( CompareVector*powerGain*1.5f);
		}

		if(CompareVector.magnitude >=fireMaxSpeed )
		fireBody.AddForce(CompareVector.normalized*fireMaxSpeed*1.5f);
	}



	if(this.thisAnimator.GetCurrentAnimatorStateInfo(1).IsName("Haste"))
		fireTmp.transform.localScale*=2f;
	Invoke("ShootingFire_Auto", (autoTime )/clickAutoFactor );	

	
	}
}
}


public float rageGage = 0; 
public bool rageOn =false;
void RageGage()
{


	{
	rageGage++;

		GameObject RageText_Trans = transform.Find("Char_StatCanvas").transform.Find("RageBar").gameObject;

		if(rageGage>=maxRage)
		{
			rageGage=0	;
			rageOn=true;
		}
	//	RageText_Trans.GetComponent<Text>().text = dinosExp.ToString();
		RageText_Trans.GetComponent<Bar_Rage_Scr>().MaxRageValue = maxRage;

		RageText_Trans.GetComponent<Bar_Rage_Scr>().RageValue = rageGage;
	}


}



// 분노 파티클
[SerializeField]
GameObject rageParticle;

[SerializeField]
float ragePartY = 0.6f;
public void RageParticle()
{
	GameObject tmp = Instantiate(rageParticle);
	tmp.transform.position = this.transform.position + new Vector3 (0, ragePartY);
	tmp.transform.localScale*=(howManyEvolved+1);
	tmp.transform.SetParent(this.transform);

//	tmp.transform.SetParent(this.transform);
}

[SerializeField]
GameObject hasteParticle;

[SerializeField]

public void HasteParticle()
{

	GameObject tmp = Instantiate(hasteParticle);
	tmp.transform.position = this.transform.position + new Vector3 (0, ragePartY);
	tmp.transform.localScale*=(howManyEvolved+1);
	tmp.transform.SetParent(this.transform);
 }
	

//HP 체력 업그레이드 
public void HpGage()
{


 
	GameObject HpText_Trans = transform.Find("Char_StatCanvas").transform.Find("HpBar").gameObject;

//	RageText_Trans.GetComponent<Text>().text = dinosExp.ToString();
	HpText_Trans.GetComponent<Bar_HP>().MaxHpValue = maxHp *(1+ Mathf.Round(dinosLevel*0.05f*100)*0.01f);

	HpText_Trans.GetComponent<Bar_HP>().Value = hpGage * (1+Mathf.Round(dinosLevel*0.05f*100)*0.01f);

}



public void CancelAuto()
{
		CancelInvoke("ShootingFire_Auto");
	ControlTower.GetComponent<ControlTowerScript>().autoLv[inven_Number]		= autoLv;

}



void Exp_WhenLevelUp()
{

//////////////////			InventoryManager.Inventory.invenInit();
 
//경험치가 다 찼을때
	// 1. 아이템을 사용했을 경우를 고려. 초과 경험치 획득
	// 2. 레벨이 2업했을 경우도 고려. 초과 경험치 획득 3번 초과하면 안됨.
	// 3. 레벨이 오르면 자동공격도 +;

	if(dinosExp>=dinosMaxExp)
	{

		float tmpExp = dinosExp - dinosMaxExp;

		
		dinosExp=0;
		dinosLevel++;
		
			dinosMaxExp+=100; 
		

		dinosExp = tmpExp;


		if(tmpExp>=dinosMaxExp)
		{
			float tmpExp2 = tmpExp - dinosMaxExp ;

			dinosExp = tmpExp2;
		}
		

	if(GameObject.FindGameObjectWithTag("ExpCanvas")!=null)
		{
		GameObject ExpText_Trans = GameObject.FindGameObjectWithTag("ExpCanvas").transform.Find("ExpBar").gameObject;

	//	RageText_Trans.GetComponent<Text>().text = dinosExp.ToString();
		ExpText_Trans.GetComponent<Bar_Exp_Script>().MaxExpValue = dinosMaxExp;

		ExpText_Trans.GetComponent<Bar_Exp_Script>().Value = dinosExp;

		ExpText_Trans.GetComponent<Bar_Exp_Script>().Level = dinosLevel;
		}
	}

	Save_DinoStatus();
}
////////////////////////////////////////////////////////////////////////////

float exp_Before;
float maxExp_Before;
public void ExpUpdate_ToBar() // exp 업데이트
{

	dinosMaxExp= dinosLevel*100;
	dinosExp++;
	dinosTotalExp++;

if(	exp_Before != dinosExp){
 
 	// Transform RageText_Trans = transform.Find("Char_StatCanvas").transform.Find("RageBar").transform.Find("Mask").transform.Find("ValueText").transform;
	
	
	if(GameObject.FindGameObjectWithTag("ExpCanvas")!=null)
		{
		GameObject ExpText_Trans = GameObject.FindGameObjectWithTag("ExpCanvas").transform.Find("ExpBar").gameObject;

	//	RageText_Trans.GetComponent<Text>().text = dinosExp.ToString();
		ExpText_Trans.GetComponent<Bar_Exp_Script>().MaxExpValue = dinosMaxExp;

		ExpText_Trans.GetComponent<Bar_Exp_Script>().Value = dinosExp;


		exp_Before = dinosExp;
		}
	}



// // exp canvas 포지션 정리
// 		if (GameObject.FindGameObjectWithTag ("ExpCanvas") != null) {
// 			GameObject.FindGameObjectWithTag ("ExpCanvas").transform.Find ("ExpBar").gameObject.transform.Find ("LevelText").transform.position =
// 			transform.Find ("LevelPosition").transform.position;


// 			GameObject.FindGameObjectWithTag ("ExpCanvas").transform.Find ("ExpBar").gameObject.transform.Find ("NameText").GetComponent<Text> ().text = dinosName.ToString ();
// 			GameObject.FindGameObjectWithTag ("ExpCanvas").transform.Find ("ExpBar").gameObject.transform.Find ("NameText").transform.position =
// 			transform.Find ("LevelPosition").transform.position + new Vector3 (0, 0.4f, 0);
		// }


}


IEnumerator displayName()
{
	yield return new WaitForSeconds(0.05f);

		if (GameObject.FindGameObjectWithTag ("ExpCanvas") != null) {
			GameObject.FindGameObjectWithTag ("ExpCanvas").transform.Find ("ExpBar").gameObject.transform.Find ("LevelText").transform.position =
			transform.Find ("LevelPosition").transform.position;


			GameObject.FindGameObjectWithTag ("ExpCanvas").transform.Find ("ExpBar").gameObject.transform.Find ("NameText").GetComponent<Text> ().text = dinosName.ToString ();
			GameObject.FindGameObjectWithTag ("ExpCanvas").transform.Find ("ExpBar").gameObject.transform.Find ("NameText").transform.position =
			transform.Find ("LevelPosition").transform.position + new Vector3 (0, 0.4f, 0);
		}


}

public void Update_DinoStatus()
{

 	// ControlTowerScript CTscr =GameObject.FindGameObjectWithTag("ControlTower").gameObject.GetComponent<ControlTowerScript>();

	
	inven_Number 	= ControlTowerScript.controlTowerScript.invenNumber[inven_Number];

	dinosSpecies	= ControlTowerScript.controlTowerScript.dinosSpecies[inven_Number];
	dinosName		= ControlTowerScript.controlTowerScript.dinosName[inven_Number];
 	dinosLevel		= ControlTowerScript.controlTowerScript.dinosLevel[inven_Number]; // v
 	
	dinosMaxExp		= ControlTowerScript.controlTowerScript.dinosMaxExp[inven_Number];
	dinosTotalExp	= ControlTowerScript.controlTowerScript.dinosTotalExp[inven_Number]; // v 
	dinosExp		= ControlTowerScript.controlTowerScript.dinosExp[inven_Number]; 		//  v
	

	totalPower		= ControlTowerScript.controlTowerScript.totalPower[inven_Number];
	powerLevel		= ControlTowerScript.controlTowerScript.powerLevel[inven_Number];
	adrenalineLv	= ControlTowerScript.controlTowerScript.adrenalineLv[inven_Number];
	criticalRateLv	= ControlTowerScript.controlTowerScript.criticalRateLv[inven_Number];
	critPowerLv		= ControlTowerScript.controlTowerScript.critPowerLv[inven_Number];
	evolutionNumb	= ControlTowerScript.controlTowerScript.evolutionNumb[inven_Number];
 
	//autoLv			= CTscr.autoLv[inven_Number];

 

	exp_Before = dinosExp;
	maxExp_Before = dinosMaxExp;




	if(GameObject.FindGameObjectWithTag("ExpCanvas")!=null){
	GameObject ExpText_Trans = GameObject.FindGameObjectWithTag("ExpCanvas").transform.Find("ExpBar").gameObject;

//	RageText_Trans.GetComponent<Text>().text = dinosExp.ToString();
	ExpText_Trans.GetComponent<Bar_Exp_Script>().MaxExpValue = dinosMaxExp;

	ExpText_Trans.GetComponent<Bar_Exp_Script>().Value = dinosExp;

	ExpText_Trans.GetComponent<Bar_Exp_Script>().Level = dinosLevel;
	}
	StartCoroutine(displayName());
}
public void Save_DinoStatus()
{

 
	ControlTowerScript.controlTowerScript.dinosSpecies[inven_Number] 	= dinosSpecies;
	//ControlTowerScript.controlTowerScript.dinosName[inven_Number] 	= dinosName;
 	ControlTowerScript.controlTowerScript.dinosLevel[inven_Number]	= dinosLevel; // v
	ControlTowerScript.controlTowerScript.dinosHp[inven_Number] = (int)Mathf.Round(maxHp *(1+ Mathf.Round(dinosLevel*0.05f*100)*0.01f));
	ControlTowerScript.controlTowerScript.dinosMaxExp[inven_Number]	= dinosMaxExp;
	ControlTowerScript.controlTowerScript.dinosTotalExp[inven_Number]	= dinosTotalExp; // v 
	ControlTowerScript.controlTowerScript.dinosExp[inven_Number]		= dinosExp; 		//  v
	
	ControlTowerScript.controlTowerScript.totalPower[inven_Number] 	= totalPower;
	// ControlTowerScript.controlTowerScript.powerLevel[inven_Number]	= powerLevel;
	// ControlTowerScript.controlTowerScript.adrenalineLv[inven_Number]	= adrenalineLv;
	// ControlTowerScript.controlTowerScript.criticalRateLv[inven_Number]= criticalRateLv;
	// ControlTowerScript.controlTowerScript.critPowerLv[inven_Number]	= critPowerLv;
	ControlTowerScript.controlTowerScript.evolutionNumb[inven_Number]	= evolutionNumb;
 
//	CTscr.autoLv[inven_Number]		= autoLv;

 
 
	exp_Before = dinosExp;
	maxExp_Before = dinosMaxExp;
}



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
