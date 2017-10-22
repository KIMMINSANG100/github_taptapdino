using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*

 레벨과 진화를 도맡고있는 스크립트
 때문에 save&load 와 연관이 크다

*/

/*
public class ExpRageScript : MonoBehaviour {

	[SerializeField]
    private Stat expBar;


//로드가 되었는지 확인해야한다
	public bool thisLoaded;
	public int loadedLevel;

// 진화레벨 case도 바꿔야함

	[SerializeField]
	private int Evol1st = 4;
	[SerializeField]
	private int Evol2nd= 6;
	[SerializeField]
	private int Evol3rd =7;
	[SerializeField]
	private int Evol4th = 9;
	


	// Use this for initialization
  void Awake() {
		        expBar.Initialize();
				
	}
	void Start () {
		meatEat=false;
		thisLoaded=false;
		preLevel=expBar.currentLevel;

colWithTarget=false;
	}
		int tmp =0;

	float rage_Level=20;

	private int k = 0;
	// Update is called once per frame


	public bool colWithTarget;

	public bool meatEat;
	void Update () {

//고기를 먹었을때
		if(meatEat)
			{
				 expBar.CurrentRage +=200;
				 meatEat=false;
			 		Invoke("RageToZero",5);
			expBar.RageDone=true;

			}

			if(!expBar.RageDone)
		{
			expBar.CurrentRage-= rage_Level*Time.deltaTime;

			tmp=0;
		}



		if(expBar.RageDone&&tmp==0)
		{
			tmp=1;
			Invoke("RageToZero",5);
		} 



//		 if(!(GameObject.FindGameObjectWithTag("BelowText")  !=null || GameObject.FindGameObjectWithTag("DspIndex")!=null))
		 {
			if(Input.GetMouseButtonDown(0))
		{
		expBar.CurrentRage +=1;
		expBar.CurrentExp +=0;	
		}

		 if(colWithTarget){			

		colWithTarget = false;
			
		expBar.CurrentExp ++;	


		ExpToZero();
		




		//if( tmpLv != expBar.CurrentLevel){
			switch ( expBar.currentLevel)
			{//case는 레벨
				case 4:
				if(k==0){
					k++;
					dotstmp=0;
					EvolutionDots();
					Invoke("EvolutionTrigger",2);
				}
				break;

				case 6:	
				if(k==1){
					k++;
					dotstmp=0;
					EvolutionDots();
					Invoke("EvolutionTrigger",2);
				}
				break;

				case 7 :
				if(k==2)
				{
					k++;
					dotstmp=0;
					EvolutionDots();
					Invoke("EvolutionTrigger",2);
				}
				break;
				
				case 9:
				if(k==3){
					k++;
					dotstmp=0;
					EvolutionDots();
					Invoke("EvolutionTrigger",2);
				}
				break;

				case 11:
				if(k==4){
					k++;
					dotstmp=0;
					EvolutionDots();
					Invoke("EvolutionTrigger",2);
				}
				break;

				
				default:
				break;	

	//진화 1단계~n단계
				}
	/*
			}
//로드가 되었다면 (thisloaded는 CharacterSelect 클래스에서)
	if(thisLoaded)
		{
			loadingLevels();
			expBar.currentLevel= loadedLevel;
			LoadedEvolutionTree();
			
		
		}

		// 이전 레벨과 
				tmpLv=   expBar.CurrentLevel;
			
		 }
		
	}

public int tmpLv;
void ExpToZero()
{
if(expBar.CurrentExp==expBar.MaxExp)
		{
			expBar.CurrentExp =0;
			expBar. MaxExp +=10;
	
			expBar.CurrentLevel ++;
		}


}

void RageToZero()
{
		expBar.CurrentRage =0;
}
private float fallDelay = 5 ;
	IEnumerator Rage_Continue()
	{
			expBar.RageDone=false;
		yield return new WaitForSeconds(fallDelay);

			RageToZero();

    }


private int dotstmp=0;
void EvolutionDots()
{
	if(dotstmp==0){
				GameObject.FindGameObjectWithTag("BGText").transform.GetChild(0).gameObject.SetActive(true);
				GameObject.FindGameObjectWithTag("BelowText").transform.GetChild(1).gameObject.SetActive(false);

				GameObject.FindGameObjectWithTag("BelowText").transform.GetChild(0).gameObject.GetComponent<Text>().text = ".....".ToString();
				dotstmp=1;
	}

}
void EvolutionTrigger()
{

					transform.GetChild(k-1).GetComponent<Animator>().SetTrigger("Evolution");
		
}	


private int preLevel;

void LoadedEvolutionTree()
{

	if(	!(preLevel==expBar.currentLevel)){
		if(expBar.currentLevel<Evol1st  )
		{
			GetComponent<EvolutionSelect>().charIndex =0;
							GetComponent<EvolutionSelect>().CharacterSelection();
							k=0;

		}

		if(expBar.currentLevel>=Evol1st && expBar.currentLevel<Evol2nd )
		{
			GetComponent<EvolutionSelect>().charIndex =1;
							GetComponent<EvolutionSelect>().CharacterSelection();
								k=1;

		}


		if(expBar.currentLevel>=Evol2nd && expBar.currentLevel<Evol3rd )
		{
			GetComponent<EvolutionSelect>().charIndex =2;
							GetComponent<EvolutionSelect>().CharacterSelection();
								k=2;

		}

		if(expBar.currentLevel>=Evol3rd && expBar.currentLevel<Evol4th)
		{
			GetComponent<EvolutionSelect>().charIndex =3;
							GetComponent<EvolutionSelect>().CharacterSelection();
								k=3;

		}

		if(expBar.currentLevel>=Evol4th  )
		{
			GetComponent<EvolutionSelect>().charIndex =4;
				k=4;
		}
	
	preLevel=expBar.currentLevel;
	}
	
}


public int[] dinosLevel;

void loadingLevels()

{
	
		for(int i =1 ; i< transform.parent.transform.parent.childCount ; i++ )
		{

	 	   if(this.transform.parent.transform== GameObject.FindGameObjectWithTag("Dinos").transform.GetChild(i).transform){

		if(GameObject.FindGameObjectWithTag("Dinos").transform.GetChild(i)!=null)
				{loadedLevel = dinosLevel[i];
				
 							thisLoaded=false;
				}
				}

		}
}


}
*/