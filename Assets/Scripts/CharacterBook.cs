using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBook : MonoBehaviour {

public static CharacterBook characterBook;
////////////////////

//************ 인벤토리 최상위 스크립트
// 이 스크립트는
// 1) 하위에 있는 버튼이 눌리면 그 정보를 CT로부터 받아온다
// 2) 받아온 정보를 왼쪽 창에 띄운다.
// 3) 메인씬에 캐릭터를 생성한다.


// 여기가 인벤토리임 스태틱함수를위해 설정
 
 void Awake(){
	if(characterBook==null)
	{
		DontDestroyOnLoad(transform.gameObject);
		characterBook=this;
	}
	else if(characterBook != this)
	{
		Destroy(characterBook);
	}
				Debug.Log("this is inventory : " + this.name);
 	 

 }

	[SerializeField]
	public Sprite[] CharacterImage =  new Sprite[80];
	// egg add 추가할때 bool 을 늘려야함 어떻게든
	public bool[] charBool  = new bool[80];

	// Use tWhis for initialization
	void Start () {
				charBool = new bool[80];

 	}
	

	public void bookStart()
	{
		charBool = new bool[80];
		for( int k= 0 ; k<  ControlTowerScript.controlTowerScript.bookChar.Length ; k++)
		{
		charBool[k]= ControlTowerScript.controlTowerScript.bookChar[k];
		}

		Debug.Log("thisname" + this.name);
		ControlTowerScript.controlTowerScript.bookChar = charBool;
	if(this.name=="Book_Panel")
		for(int a =0;  a<transform.childCount ; a++){

	Debug.Log("this " + transform.childCount);
		if(charBool[a]==true)
			Book_Update(a);}

	}
	// Update is called once per frame
// 도감 모으기
	public void Book_Update(int i)
	{
		 charBool[i]=true;

		// if(transform.GetChild(i).gameObject!=null){ 
		// 	{
		// //색배리어 날리기
		// 	transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
		// //오퍼시티 날리기
		// 	transform.GetChild(i).transform.GetChild(1).gameObject.SetActive(false);;
		// 	}
		// }
	}
}
