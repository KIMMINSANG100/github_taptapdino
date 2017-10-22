using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoBookManager : MonoBehaviour {
public static DinoBookManager dinoBook;

 void Awake(){
	if(dinoBook==null)
	{
		DontDestroyOnLoad(transform.gameObject);
		dinoBook=this;
	}
	else if(dinoBook != this)
	{
		Destroy(dinoBook);
	}
 
 }
	// Use this for initialization
	void Start () {
		CallBookInfo_FromCT();	
	}
	 




[SerializeField]
Sprite[] bookImgClosed;

[SerializeField]
Sprite[] bookImgOpen;

// 도감 정보 ct에서 불러오기
	public void CallBookInfo_FromCT()
	{

		bool[] callBook=	ControlTowerScript.controlTowerScript.bookChar;

// 이미지 입력
int b;
if( callBook.Length >= transform.childCount)
	b= callBook.Length;
else
	b= transform.childCount;

		for( int t = 0 ; t < b ; t++)
		{
			if( callBook[t] == true)
			{
				if(	transform.GetChild(t)!=null)
				if(bookImgOpen!=null)
					transform.GetChild(t).GetComponent<Image>().sprite=bookImgOpen[t];

			}

			else if( callBook[t] == false)
			{
				
				if(	transform.GetChild(t)!=null){			 

								if(bookImgClosed!=null)
					transform.GetChild(t).GetComponent<Image>().sprite=bookImgClosed[t];
				}
			} 
		}
	}
}
