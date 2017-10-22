using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class campSpotScript : MonoBehaviour {

	[SerializeField]
	int thisCampPosNumber;

	[SerializeField]
	Image thisImage;

	public int recieveInvNumb;
	// Use this for initialization
	void Start () {
		campNumberInit();
		//StartCoroutine(ImageUpdate());
	}


//	IEnumerator ImageUpdate()
	void Update()
	{
	//	while(true){
		//yield return new WaitForSeconds(0.2f);

		if(ControlTowerScript.controlTowerScript.sharedCampPosNumber != thisCampPosNumber){
			this.thisSpriteRender.color = new Color32 ( 255, 255, 255, 34 );
			StopCoroutine(blinkblink());
		}
		else if(ControlTowerScript.controlTowerScript.sharedCampPosNumber==thisCampPosNumber&&autoBlink==true){
				StartCoroutine( blinkblink());
				autoBlink=false;
		}


		int x = ControlTowerScript.controlTowerScript.battleInv[thisCampPosNumber];
 
			if(x<300){


		int y = ControlTowerScript.controlTowerScript.dinosSpecies[x];
		thisImage.sprite = CharacterBook.characterBook.CharacterImage[y];
		thisImage.color = new Color(1,1,1,1);

	//	}
		}

		else
		{
			thisImage.sprite =null;
			thisImage.color = new Color(0,0,0,0); 
			
			if(ControlTowerScript.controlTowerScript.sharedCampPosNumber==thisCampPosNumber&&autoBlink==true){
				StartCoroutine( blinkblink());
				autoBlink=false;
		}

		}

	}

	
	public void campNumberInit()
	{
	for(int k = 0 ; k < transform.parent.childCount ; k++)
		{ 
		if( this. transform ==transform.parent.GetChild(k).transform  )
		this.thisCampPosNumber=k;
		}
 
	}

	// Update is called once per frame 

	[SerializeField]
	SpriteRenderer thisSpriteRender;
	[SerializeField]
	bool campOn;

	void OnTriggerEnter2D(Collider2D other)
	{
		recieveInvNumb	=	other.GetComponent<CampImgInstance>().getInvenNumber; 
		thisSpriteRender.color = new Color32 ( 93, 255, 245, 127 );
		campOn= true;
		ControlTowerScript.controlTowerScript.battleInv[thisCampPosNumber] = recieveInvNumb;



	}
	

	void OnMouseDown()
	{		 
		InventoryManager.Inventory.boxColActiveSelf();
		
		ControlTowerScript.controlTowerScript.battleInv[thisCampPosNumber]=1000;


		// this.thisSpriteRender.color = new Color32 ( 93, 255, 245, 127 );
		// campOn= true;
		ControlTowerScript.controlTowerScript.sharedCampPosNumber = thisCampPosNumber;
		this.gameObject.tag = "spot";
 
		//StartCoroutine( blinkblink()); 

		Debug.Log("thistag:"+ tag);

		// ControlTowerScript.controlTowerScript.battleInv[thisCampPosNumber] = recieveInvNumb;

	}

	bool autoBlink = true;
	bool blink =false;
	IEnumerator blinkblink()
	{
		while(true)
		{
			if(blink==false)
			{
				this.thisSpriteRender.color = new Color32 ( 255, 255, 255, 34 );
				blink = true;
			}
			else if(blink==true){
				this.thisSpriteRender.color = new Color32 (255, 255, 255, 70);
				blink=false;
			}
			yield return new WaitForSeconds(0.1f);

			if(ControlTowerScript.controlTowerScript.sharedCampPosNumber != thisCampPosNumber)
			{
				StopCoroutine(this.blinkblink());
				this.thisSpriteRender.color = new Color32 ( 255, 255, 255, 34 );
				autoBlink=true;		

			break;
			}
		}

	}

	
}
