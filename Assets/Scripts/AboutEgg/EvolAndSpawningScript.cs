using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolAndSpawningScript : MonoBehaviour {


	[SerializeField]
	GameObject EggParticle;
	Transform EandStrans;
	// Use this for initialization
	void Start () {
		EandStrans = GameObject.FindGameObjectWithTag("EandS").transform;
	}
	
	public int eggNumber;
	[SerializeField]
	EggSpawnSprites thisSprite;
	public void GetImgForSpawn()
	{

		Debug.Log("hereIsMonsterImg");
		GetComponent<SpriteRenderer>().sprite = thisSprite.spawningDinos[eggNumber];
		this.transform.localScale = new Vector3 (3,3,3);
		Debug.Log(this.transform.localScale);
				Debug.Log(this.name);

		Invoke("ScaleToOrigin",3);


	}


	public void GetImgForEvol_Before()
	{
		GetComponent<SpriteRenderer>().sprite = EandStrans.Find("Img_BeforeEvol").GetComponent<SpriteRenderer>().sprite;
	}

	public void GetImgForEvol_After()
	{

		GetComponent<SpriteRenderer>().sprite = EandStrans.Find("Img_AfterEvol").GetComponent<SpriteRenderer>().sprite;

	}


	public void SpawnParticle()
	{
		GameObject tmp = Instantiate(EggParticle);
		tmp.transform.position = this.transform.position;
		

	}

	public void SpawnParticle_Tut()
	{
		GameObject tmp = Instantiate(EggParticle);
		tmp.transform.position = new Vector3(0,0);
		

	}

	public void CameraToMain()
	{		ControlTowerScript.controlTowerScript.hatched=true;


		int b=0;
				for(int k=0 ; k < ControlTowerScript.controlTowerScript.dinosSpecies.Length ; k++)
				{
					if(ControlTowerScript.controlTowerScript.thereIsMonster[k]==true)
					b++;	
				}
					ControlTowerScript.controlTowerScript.invennumberShared=b-1;
		SubTowerScript.subTowerScript.LoadMain();

	}
	


	void ScaleToOrigin()
	{
	this.transform.localScale*=2;
	}

}
