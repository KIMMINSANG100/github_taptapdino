using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*/
public class CharacterInstantiating : MonoBehaviour {

public static CharacterInstantiating charactinst;
	public GameObject[] Characters =  new GameObject[30];

	public int invenNumber;

	void Awake(){}
	// Use this for initialization

	bool started = false;
	void Start () {
		//InstantiateCharacter(0,0);

		for(int i = 0 ; i <30 ; i++)
			{
				if(ControlTowerScript.controlTowerScript.thereIsMonster[i]==false&&started==false)
				{
					invenNumber = i;
					started=true;
				}
			}

	}
	

	
	// Update is called once per frame
	void Update () {
		if (invenNumber >= 30)
			invenNumber = 30;


	

	if(Input.GetKeyDown("b"))
		InstantiateCharacter(0,0);
	}


	public void InstantiateAll_forFight()
	{
		

		for(int i =0; i< 30 ; i++)
		{
			if(GetComponent<ControlTowerScript>().thereIsMonster[i]==true)
			{
		 	int a = GetComponent<ControlTowerScript>().dinosSpecies[i];

				GameObject tmp	 =  Instantiate(Characters[a]);
				tmp.GetComponent<Dino_Individual>().inven_Number= i;
				//tmp.transform.SetParent(PlayerTransform);
				//tmp.transform.position							 = PlayerTransform.position;
				//tmp.GetComponent<Dino_Individual>().inven_Number = invenNumb;
			}
		}

	}


/////////확인 InstantiateCharacter : 캐릭터를 맵에 생성
	public void InstantiateCharacter(int invenNumb, int charNumb)
	{
		
		if(GameObject.FindGameObjectWithTag("Player")!=null){
		Transform PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		if(PlayerTransform.childCount!=0)
			for(int b=0; b<PlayerTransform.childCount; b++)
				Destroy(PlayerTransform.GetChild(b).gameObject);
			
		string Name =	DinosResourceName(charNumb);

		GetDinoResource(Name,PlayerTransform.position, PlayerTransform,invenNumb);


		Debug.Log("dinosnosnoso:" + Name);

		// GameObject tmp	 =  Instantiate(Characters[charNumb]);
		// tmp.transform.SetParent(PlayerTransform);
		// tmp.transform.position							 = PlayerTransform.position;
		// tmp.GetComponent<Dino_Individual>().inven_Number = invenNumb;

		}
		//tmp.transform.Find("Char_StatCanvas").gameObject.transform.Find("ExpBar").gameObject.SetActive(true);


/////////도감정보 채우기 book char는 가졌던 디노정보
		ControlTowerScript.controlTowerScript.bookChar[charNumb] = true; 


////////도감에서 ct로 정보요청 : 정보 리셋
		if(DinoBookManager.dinoBook!=null)
		DinoBookManager.dinoBook.CallBookInfo_FromCT(); 
				// Book.GetComponent<CharacterBook>().Book_Update(charNumb); 

		GetComponent<ControlTowerScript>().bookChar[charNumb] = true;

	}

///////확인 Instantiate_EvolutionChar : 진화시키기
	public void Instantiate_EvolutionChar(int invenNumb, int charNumb)
	{
		Transform PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		if(PlayerTransform.childCount!=0)
		Destroy(PlayerTransform.GetChild(0).gameObject);



		// if(Characters[charNumb+1]!=null)
		{
		// GameObject tmp	 =  Instantiate(Characters[charNumb+1]);
		// tmp.transform.SetParent(PlayerTransform);
		// tmp.GetComponent<Dino_Individual>().inven_Number = invenNumb;
		// tmp.transform.position							 = PlayerTransform.position;

		GetComponent<ControlTowerScript>().dinosSpecies[invenNumb]+=1;

	//도감채우기
//			DinoBookManager.dinoBook.CallBookInfo_FromCT();
		//	Book.GetComponent<CharacterBook>().Book_Update(charNumb+1);
		GetComponent<ControlTowerScript>().bookChar[charNumb+1] = true;
		 
		string Name =	DinosResourceName(charNumb+1);

		GetDinoResource(Name,PlayerTransform.position, PlayerTransform,invenNumb);


		Debug.Log("dinosnosnoso:" + Name);

		}
	}








	public void InstantiateCharacter_Egg(int invenNumb, int EggNumb)
	{
	////////////////////////////////	
		// Transform PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		// if(PlayerTransform.childCount!=0)
		// 	for(int b=0; b<PlayerTransform.childCount; b++)
		// 		Destroy(PlayerTransform.GetChild(b).gameObject);




		int char_Number = 0;
// update : egg Add : 알 추가

// 캐릭터 진화개수 늘릴거라서 char_number 를 5단위로 잡음 5: red , 10 : yel , 15 : sk , 20 : gray

		if (EggNumb==0)
		{
			char_Number= 0;
		}
		if (EggNumb==1)//red
		{
			char_Number= 5;
		}
		if (EggNumb==2)//gray
		{
			char_Number= 10;
		}
		if (EggNumb==3)//yellow
		{
			char_Number= 15;
		}
		if (EggNumb==4) //ska
		{
			char_Number= 20;
		}
		 
		if (EggNumb==5) //wood
		{
			char_Number= 25;
		} 
		if (EggNumb==6) //ice
		{
			char_Number= 30;
		}
		if (EggNumb==7) //iron
		{
			char_Number= 35;
		} 
		if (EggNumb==8) //dark
		{
			char_Number= 40;
		} 
		if (EggNumb==9) //light
		{
			char_Number= 45;
		} 
		if (EggNumb==10) // a
		{
			char_Number= 50;
		} 
		if (EggNumb==11) //b
		{
			char_Number= 55;
		} 
		if (EggNumb==12) //tego
		{
			char_Number= 60;
		} 
		if (EggNumb==13) //zino
		{
			char_Number= 65;
		} 

		if (EggNumb==14) //tera
		{
			char_Number= 70;
		} 

		if (EggNumb==15) //sinryu
		{
			char_Number= 75;
		} 
 

	//	GameObject tmp	 =  Instantiate(Characters[char_Number]);
		// tmp.transform.SetParent(PlayerTransform);
		// tmp.transform.position							 = PlayerTransform.position;
	//	tmp.GetComponent<Dino_Individual>().inven_Number = invenNumb;


//이름생성창 ON

/////////////////////////.이름넣어야해
		// Transform mainCanvasTrans = GameObject.FindGameObjectWithTag("MainCanvas").transform;

		// mainCanvasTrans.Find("NameInputPanel").gameObject.SetActive(true);


//캐릭터 정보 업데이트
		string thisName = GetComponent<ControlTowerScript>().dinosName[invenNumber];

				this.GetComponent<ControlTowerScript>().Update_Name(invenNumb, char_Number, thisName);
				this.GetComponent<ControlTowerScript>().Update_DinoStats(invenNumb,1,1,1,1);
				this.GetComponent<ControlTowerScript>().Update_Exp(invenNumb,1 , 0, 100, 0);
				this.GetComponent<ControlTowerScript>().Update_AutoAttk(invenNumb,1);
//인벤 개별 박스에 그림올리기
			// Transform invenBoxesTrans = GameObject.FindGameObjectWithTag("InventoryBoxes").transform;
            // invenBoxesTrans.GetChild(invenNumb).GetComponent<Inven_Box>().Update_BoxImage(char_Number);

			// invenBoxesTrans.GetChild(invenNumb).GetComponent<Inven_Box>().Update_DinoStatus();


 			invenNumber = invenNumb;
			invenNumber2 = invenNumb;
			// GameObject Book = GameObject.FindGameObjectWithTag("Book").gameObject;
			// Book.GetComponent<CharacterBook>().Book_Update(char_Number);

//이름, 스탯, 업뎃

invenNumber++;
		Debug.Log("hatched");

	}

	 private int invenNumber2 ;
	

	public void SendNameToChar(string Name)
	{
		invenNumber2 = ControlTowerScript.controlTowerScript.invennumberShared;
 		GetComponent<ControlTowerScript>().dinosName[invenNumber2] = Name;
		int Spec = GetComponent<ControlTowerScript>().dinosSpecies[invenNumber2] ;
		this.GetComponent<ControlTowerScript>().Update_Name(invenNumber2, Spec, Name);
 

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.GetChild(0).GetComponent<Dino_Individual>().Update_DinoStatus();
	//	Transform invenBoxesTrans = GameObject.FindGameObjectWithTag("InventoryBoxes").transform;
	//		invenBoxesTrans.GetComponent<InventoryManager>().Update_DinoStatus();//////업데이트중

	//		GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Dino_Individual>().dinosName = "Name";
	}


//전투씬

    /*class BattleMode (인공지능)
        자동공격 : Auto
        움직임 : Moving
        크기 / 위치 :  transformPostion 크
        hp
      */ 
	public void InsOfBattleMode()
	{
		
		for(int i = 0 ; i < 30 ; i++)
			if(GetComponent<ControlTowerScript>().thereIsMonster[i]==true)
			{
				int a = GetComponent<ControlTowerScript>().dinosSpecies[i];
				
			

				Transform PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		

				GameObject tmp	 =  Instantiate(Characters[a]);
				//tmp.transform.SetParent(PlayerTransform);
				
				int rand_x = Random.Range(-5,5);
				int rand_y = Random.Range(-5,5);
				tmp.transform.position	 = PlayerTransform.GetChild(i).transform.position ;//+ new Vector3(rand_x,rand_y) *0.5f;

								tmp.GetComponent<Dino_Individual>().inven_Number= i;


			}
	}


	public void InsOfBattle_New( int CampNumber, int CampPosNumber, int gotNumberInven)
	{
		 

		 		if(gotNumberInven<500){
				int charNumb = GetComponent<ControlTowerScript>().dinosSpecies[gotNumberInven];
				
			
/// camp 설정
				Transform PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform.GetChild(CampNumber);
		

				// GameObject tmp	 =  Instantiate(Characters[charNumb]);

				string Name =	DinosResourceName(charNumb);
				Transform Nest = GameObject.FindGameObjectWithTag("Nest").transform;
				GetDinoResource(Name,PlayerTransform.GetChild(CampPosNumber).transform.position ,Nest , gotNumberInven);



				// tmp.GetComponent<Dino_Individual>().inven_Number = gotNumberInven;
				//tmp.transform.SetParent(PlayerTransform);
				
				// tmp.transform.position	 = PlayerTransform.GetChild(CampPosNumber).transform.position ;//+ new Vector3(rand_x,rand_y) *0.5f;

						//		tmp.GetComponent<Dino_Individual>().inven_Number= i;
				 }

	}


	public void GiveCharacterName()
	{
		
		 Transform mainCanvasTrans = GameObject.FindGameObjectWithTag("MainCanvas").transform;

		 mainCanvasTrans.Find("NameInputPanel").gameObject.SetActive(true);

	}




	
	string DinosResourceName(int dinosSpec)
	{

		switch (dinosSpec){
			
			case 0:
				Debug.Log( dinosSpec);

				return "00.Green_0";

			case 1:
				return "01.Green_1";

			case 2:
				return "02.Green_2";
			case 3:
				return "03.Green_3";
			case 4:
				return "04.Green_4";
			case 5:
				return "05.red_0";
			case 6:
				return "06.red_1";
			case 7:
				return "07.red_2";
			case 8:
				return "08.red_3";
			case 9:
				return "09.red_4";



			case 10:
				return "10.gray_0";
			case 11:
				return "11.gray_1";
			case 12:
				return "12.gray_2";
			case 13:
				return "13.gray_3";
			case 14:
				return "14.gray_4";
			case 15:
				return "15.elec_0";
			case 16:
				return "16.elec_1";
			case 17:
				return "17.elec_2";
			case 18:
				return "18.elec_3";
			case 19:
				return "19.elec_4";




			case 20:
				return "20.ska_0";
			case 21:
				return "21.ska_1";
			case 22:
				return "22.ska_2";
			case 23:
				return "23.ska_3";
			case 24:
				return "24.ska_4";
			case 25:
				return "25.woods_0";
			case 26:
				return "26.woods_1";
			case 27:
				return "27.woods_2";
			case 28:
				return "28.woods_3";
			case 29:
				return "29.woods_4";



			case 30:
				return "30.Ice_0";
			case 31:
				return "31.Ice_1";
			case 32:
				return "32.Ice_2";
			case 33:
				return "33.Ice_3";
			case 34:
				return "34.Ice_4";
			case 35:
				return "35.Iron_0";
			case 36:
				return "36.Iron_1";
			case 37:
				return "37.Iron_2";
			case 38:
				return "38.Iron_3";
			case 39:
				return "39.Iron_4";





			case 40:
				return "40.Dark_0";
			case 41:
				return "41.Dark_1";
			case 42:
				return "42.Dark_2";
			case 43:
				return "43.Dark_3";
			case 44:
				return "44.Dark_4";
			case 45:
				return "45.Light_0";
			case 46:
				return "46.Light_1";
			case 47:
				return "47.Light_2";
			case 48:
				return "48.Light_3";
			case 49:
				return "49.Light_4";


			case 50:
				return "50.Ank_0";
			case 51:
				return "51.Ank_1";
			case 52:
				return "52.Ank_2";
			case 53:
				return "53.Ank_3";
			case 54:
				return "54.Ank_4";
			case 55:
				return "55.Kera_0";
			case 56:
				return "56.Kera_1";
			case 57:
				return "57.Kera_2";
			case 58:
				return "58.Kera_3";
			case 59:
				return "59.Kera_4";


			case 60:
				return "60.tego_0";
			case 61:
				return "61.tego_1";
			case 62:
				return "62.tego_2";
			case 63:
				return "63.tego_3";
			case 64:
				return "64.tego_4";
			case 65:
				return "65.zino_0";
			case 66:
				return "66.zino_1";
			case 67:
				return "67.zino_2";
			case 68:
				return "68.zino_3";
			case 69:
				return "69.zino_4";


			case 70:
				return "70.ptera_0";
			case 71:
				return "71.ptera_1";
			case 72:
				return "72.ptera_2";
			case 73:
				return "73.ptera_3";
			case 74:
				return "74.ptera_4";
			case 75:
				return "75.sinryu_0";
			case 76:
				return "76.sinryu_1";
			case 77:
				return "77.sinryu_2";
			case 78:
				return "78.sinryu_3";
			case 79:
				return "79.sinryu_4";


			case 80:
				return "";
			case 81:
				return "";
			case 82:
				return "";
			case 83:
				return "";
			case 84:
				return "";
			case 85:
				return "";
			case 86:
				return "";
			case 87:
				return "";
			case 88:
				return "";
			case 89:
				return "";


			case 90:
				return "";
			case 91:
				return "";
			case 92:
				return "";
			case 93:
				return "";
			case 94:
				return "";
			case 95:
				return "";
			case 96:
				return "";
			case 97:
				return "";
			case 98:
				return "";
			case 99:
				return "";
 
		


			case 110:
				return "";
			case 111:
				return "";
			case 112:
				return "";
			case 113:
				return "";
			case 114:
				return "";
			case 115:
				return "";
			case 116:
				return "";
			case 117:
				return "";
			case 118:
				return "";
			case 119:
				return "";



				



			case 120:
				return "";
			case 121:
				return "";
			case 122:
				return "";
			case 123:
				return "";
			case 124:
				return "";
			case 125:
				return "";
			case 126:
				return "";
			case 127:
				return "";
			case 128:
				return "";
			case 129:
				return "";



			case 130:
				return "";
			case 131:
				return "";
			case 132:
				return "";
			case 133:
				return "";
			case 134:
				return "";
			case 135:
				return "";
			case 136:
				return "";
			case 137:
				return "";
			case 138:
				return "";
			case 139:
				return "";





			case 140:
				return "";
			case 141:
				return "";
			case 142:
				return "";
			case 143:
				return "";
			case 144:
				return "";
			case 145:
				return "";
			case 146:
				return "";
			case 147:
				return "";
			case 148:
				return "";
			case 149:
				return "";


			case 150:
				return "";
			case 151:
				return "";
			case 152:
				return "";
			case 153:
				return "";
			case 154:
				return "";
			case 155:
				return "";
			case 156:
				return "";
			case 157:
				return "";
			case 158:
				return "";
			case 159:
				return "";



				
		default:
			break;
		}


		return "";
	}

	void GetDinoResource(string dinoResourceName , Vector3 thisPosition, Transform parent, int invenNumb)

	{
		    // GameObject dino =  Resources.Load<GameObject>(dinoResourceName);


			GameObject dino =	Resources.Load<GameObject>("DinoPrefab/" + dinoResourceName);
            GameObject getDino = Instantiate(dino) as GameObject;
			getDino.transform.SetParent(parent);
			getDino.transform.position = thisPosition;
			getDino.GetComponent<Dino_Individual>().inven_Number = invenNumb;
			

			Debug.Log(" dinos Resource name / this position / inven numb : " +"\n" + dinoResourceName +"/" + thisPosition + "/" + invenNumb);
	}

}

