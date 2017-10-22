using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inven_Box_Camp : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	public int inven_Number ;

	 
	void Start () {

		invenInit();
			

	}

	// IEnumerator colliderenabled()
	// {

	// 		GetComponent<BoxCollider2D>().enabled = false;
		
	// }

	public void invenInit()
	{
	for(int k = 0 ; k < transform.parent.childCount ; k++)
		{
		if( this. transform ==transform.parent.GetChild(k).transform  )
		this.inven_Number=k;
		}

	}



	public void Call_InventoryManager()
	{
		if(this.transform.GetChild(0).GetComponent<Image>().sprite!=null)
		{
				BtnSounds.instance.Enter();
	
				InventoryManager.Inventory.inven_Number = inven_Number;
				InventoryManager.Inventory.call_invenCoroutine();
			
		}
	}
 [SerializeField]
 GameObject campInstance;
[SerializeField]
Vector3 ImgSize;
	public void GetImgFromBox()
	{
		if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x <4.71 && transform.GetChild(0).GetComponent<Image>().sprite!=null){
		int k = ControlTowerScript.controlTowerScript.sharedCampPosNumber ; 
		ControlTowerScript.controlTowerScript.battleInv[k]= inven_Number;

		}
		else
		{
			Debug.Log("startrBtn");
		}
		//}
		// GameObject tmp = Instantiate(campInstance);
		// tmp.GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).GetComponent<Image>().sprite;
		// tmp.transform.position = new Vector3 (transform.position.x,transform.position.y,10	);
		// tmp.transform.localScale = ImgSize;
		// tmp.GetComponent<CampImgInstance>().getInvenNumber = inven_Number;
	}

	float touched;
	void OnMouseOver()
	{
		touched+=Time.deltaTime;
	}
	void OnMouseDown()
	
	{
		touched=0;
	}

	void OnMouseUp()
	{
	//	if(touched<0.12f){

		if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x <4.58 && transform.GetChild(0).GetComponent<Image>().sprite!=null){
		ControlTowerScript.controlTowerScript.invennumberShared = inven_Number;
		GetImgFromBox();
 		Call_InventoryManager();
Debug.Log("jk : "+Camera.main.ScreenToWorldPoint(Input.mousePosition).x );
				GetComponent<BoxCollider2D>().enabled = false;
				transform.GetChild(0).GetComponent<Image>().color = new Color (1,1,1,0.6f);
		 				ControlTowerScript.controlTowerScript.updateCampPos();
		}
	///	touched=0;
	}
}
 