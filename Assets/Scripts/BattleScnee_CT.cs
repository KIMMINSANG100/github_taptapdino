using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScnee_CT : MonoBehaviour {

	public static BattleScnee_CT battleCT;

	[SerializeField]
	int mapNumber;
	[SerializeField]
	int battleLv;
	GameObject ControlTower;
	// Use this for initialization
	void Start () {
		ControlTower = GameObject.FindGameObjectWithTag("ControlTower").gameObject; 


		AudioManager.audioManager.mapChange=true;
		ControlTower.GetComponent<ControlTowerScript>().SceneNumber =2;

		AdManager.Instance.ShowBanner();

		 //ControlTower.GetComponent<CharacterInstantiating>().InsOfBattleMode()	;//<<<<<<
		
////////////////////////////////
		int a= ControlTowerScript.controlTowerScript.campNumber;
		int[] b=ControlTowerScript.controlTowerScript.campPos;
		int[] c=ControlTowerScript.controlTowerScript.battleInv;
		int lengthOfDinos = ControlTowerScript.controlTowerScript.campPos.Length;
		for(int f=0; f<lengthOfDinos ; f++)
		ControlTower.GetComponent<CharacterInstantiating>().InsOfBattle_New(a,b[f],c[f]);
///////////////////////// 
		mapNumber = ControlTower.GetComponent<ControlTowerScript>().mapImg;

		if(mapNumber==0)
		{
			GetComponent<SpriteRenderer>().sprite= BG_1[0];
		}
		else if(mapNumber==1)
		{
			GetComponent<SpriteRenderer>().sprite= BG_2[0];
		}
		else if(mapNumber==2)
		{
			GetComponent<SpriteRenderer>().sprite= BG_3[0];
		}
		else if(mapNumber==3)
		{
			GetComponent<SpriteRenderer>().sprite= BG_4[0];
		}
		else if(mapNumber==4)
		{
			GetComponent<SpriteRenderer>().sprite= BG_5[0];
		}

		else if(mapNumber==5)
		{
			GetComponent<SpriteRenderer>().sprite= BG_6[0];
		}
		else if(mapNumber==6)
		{
			GetComponent<SpriteRenderer>().sprite= BG_6[0];
		}
		else if(mapNumber==7)
		{
			GetComponent<SpriteRenderer>().sprite= BG_6[0];
		}
		else if(mapNumber==8)
		{
			GetComponent<SpriteRenderer>().sprite= BG_6[0];
		}

		CanvasTrans = GameObject.FindGameObjectWithTag("MainCanvas").transform;



///맵확정
		{
			
			battleLv= ControlTower.GetComponent<ControlTowerScript>().battleStageLevel;
			transform.GetChild(mapNumber).gameObject.transform.GetChild(battleLv-1).gameObject.SetActive(true);
		}


		Invoke("diinoLayerArrangement", 0.1f);
	}
	

	[SerializeField]
	Sprite[] BG_1;
	[SerializeField]
	Sprite[] BG_2;
	[SerializeField]
	Sprite[] BG_3;
	[SerializeField]
	Sprite[] BG_4;
	[SerializeField]
	Sprite[] BG_5;
	[SerializeField]
	Sprite[] BG_6;
/*
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("s"))
		{
			Victory();
 		}

	}*/


	
	public void Victory()
	{
		Destroy(GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("PauseBtn").gameObject);
		
		Disp_VictoryText();
		Invoke("Reward",4);
		
	}

GameObject text;

//	GameObject.FindGameObjectWithTag("Scene		Manager") .GetComponent<BattleScnee_CT>().Defeat();
	public void Defeat()
	{
		Disp_DefeatedText();

		 ControlTower.GetComponent<ControlTowerScript>().Crst_Battle=0;
		 ControlTower.GetComponent<ControlTowerScript>().Coin_Battle=0;
		 ControlTower.GetComponent<ControlTowerScript>().Exp_Battle =0;
		ControlTower.GetComponent<ControlTowerScript>().Save();
		Invoke("ToMain",5);
	}


	Transform CanvasTrans; 

	[SerializeField]
	GameObject DefeatedText;

	[SerializeField]
	GameObject VictoryText;

	// Update is called once per frame 

  


	void diinoLayerArrangement()
	{
		GameObject[] dinos = GameObject.FindGameObjectsWithTag("Dino");
		
	//	float dinoYpos = dinos[0].transform.position.y ;
	 	
		
		for(int a=0; a <dinos.Length ; a++  )
		{


			for( int b =0 ;b < dinos.Length ; b++){
				if(dinos[a].transform.position.y >dinos[b].transform.position.y )
				{	dinos[a].GetComponent<SpriteRenderer>().sortingOrder -=1;
					
					dinos[a].transform.Find("Char_StatCanvas"). GetComponent<Canvas>().sortingOrder-=1;
					

					for(int e=0; e <dinos[a].transform.childCount ; e++ )
					if(dinos[a].transform.GetChild(e). GetComponent<SpriteRenderer>()!=null)
					dinos[a].transform.GetChild(e). GetComponent<SpriteRenderer>().sortingOrder-=1;
				}

				else if(dinos[a].transform.position.y <dinos[b].transform.position.y )	
					{
						dinos[a].GetComponent<SpriteRenderer>().sortingOrder +=1;
						dinos[a].transform.Find("Char_StatCanvas"). GetComponent<Canvas>().sortingOrder+=1;

					for(int e=0; e <dinos[a].transform.childCount ; e++ )
					if(dinos[a].transform.GetChild(e). GetComponent<SpriteRenderer>()!=null)
					dinos[a].transform.GetChild(e). GetComponent<SpriteRenderer>().sortingOrder+=1;
					}

				else if(dinos[a].transform.position.y ==dinos[b].transform.position.y )
			{
							dinos[a].GetComponent<SpriteRenderer>().sortingOrder +=0;


					for(int e=0; e <dinos[a].transform.childCount ; e++ )
					if(dinos[a].transform.GetChild(e). GetComponent<SpriteRenderer>()!=null)
					dinos[a].transform.GetChild(e). GetComponent<SpriteRenderer>().sortingOrder+=0;
			}


			}


		}


	}



int k =0;


	IEnumerator BeSmall(GameObject tmp)
	{
		yield return new WaitForSeconds(0.001f);
		
		tmp.transform.localScale -= new Vector3 (0.1f,0.1f,0.1f) *2;


		if(tmp.transform.localScale.x >1)
		StartCoroutine(BeSmall(tmp));
		else
		{
//		StartCoroutine(Blinking(tmp));
		}
	}


	IEnumerator Destroyed(GameObject tmp)
	{
		yield return new WaitForSeconds(4);
		Destroy(tmp.gameObject);
	}



	IEnumerator Blinking(GameObject tmp)
	{
		
		yield return new WaitForSeconds(0.05f);
				tmp.GetComponent<Text>().color = new Color (1,1,1, this.GetComponent<SpriteRenderer>().color.a);

		k++;
		if(tmp.GetComponent<Outline>().effectColor== new Color (0,55,255,128))
			tmp.GetComponent<Outline>().effectColor=new Color (0,0,0,255);

		else if(tmp.GetComponent<Outline>().effectColor ==new Color (0,0,0,255))

			tmp.GetComponent<Outline>().effectColor= new Color
			 (0,55,255,128);

		StartCoroutine(Blinking(tmp));
		

		if(k==10)
		StopCoroutine(Blinking(tmp));

	}
 

	public void Disp_VictoryText()
	{
		GameObject tmp = Instantiate(VictoryText);

		tmp.transform.SetParent(CanvasTrans);
		tmp.transform.localPosition = new Vector3(0,0,0);
		StartCoroutine(BeSmall(tmp));
		StartCoroutine(Destroyed(tmp));
	}

	void Reward()
	{
		int crst = ControlTower.GetComponent<ControlTowerScript>().Crst_Battle;
		int coin = ControlTower.GetComponent<ControlTowerScript>().Coin_Battle;
		int exp	 = ControlTower.GetComponent<ControlTowerScript>().Exp_Battle;		

		GameObject alarm_Reward =  GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("BattleAlarm").transform.Find("RewardPanel").gameObject;
		alarm_Reward.SetActive(true);
		alarm_Reward.transform.Find("Crst_Text").GetComponent<Text>().text = "+"+ crst.ToString() ;
		alarm_Reward.transform.Find("Coin_Text").GetComponent<Text>().text = "+"+coin.ToString() ;
		alarm_Reward.transform.Find("EXP_Text").GetComponent<Text>().text  = "+"+ exp.ToString() ;

		if(ControlTower.GetComponent<ControlTowerScript>().battleStageLevel >=ControlTower.GetComponent<ControlTowerScript>().map[mapNumber])
		ControlTower.GetComponent<ControlTowerScript>().map[mapNumber] ++;
				
		if(ControlTower.GetComponent<ControlTowerScript>().map[mapNumber] >10 )
		{
			ControlTower.GetComponent<ControlTowerScript>().map[mapNumber]=10;
			ControlTower.GetComponent<ControlTowerScript>().map[mapNumber+1] = 1;
		}
		GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().battleStageLevel ++;
		Debug.Log("battleStageLv"+ GameObject.FindGameObjectWithTag("ControlTower").GetComponent<ControlTowerScript>().battleStageLevel);
		Invoke("ToMain",5);
	}


	public void Disp_DefeatedText()
	{
		GameObject tmp = Instantiate(DefeatedText);
		
		tmp.transform.SetParent(CanvasTrans);
		tmp.transform.localPosition = new Vector3(0,0,0);
		StartCoroutine(BeSmall(tmp));
	}

	public void DestroyStart()
	{
		Destroy(gameObject);
	}


	public void ToMain()
	{
		
		ControlTower.GetComponent<ControlTowerScript>().BattleReward();
		ControlTower.GetComponent<ControlTowerScript>().Save();

		if(ControlTowerScript.controlTowerScript.battleStageLevel <=10)
				SubTowerScript.subTowerScript.LoadBattleStage();

		else
				SubTowerScript.subTowerScript.LoadMain();
	}

}

