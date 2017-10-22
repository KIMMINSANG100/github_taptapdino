using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public float totPower;
	// Use this for initialization
	void Start () {
		

		
	}
	
	// Update is called once per frame
	void Update () {
		
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

			if( transform.position.x > max.x){

			Destroy(gameObject);

		}



	}

[SerializeField]
GameObject this_particle;
	void OnTriggerEnter2D(Collider2D col)
	{

		
		if(col.CompareTag("Dino")){
			int a = Random.Range(0,5);


			if(col.GetComponent<Dino_Individual>()!=null){
			col.GetComponent<Dino_Individual>().hpGage -= totPower;
			col.GetComponent<Dino_Individual>().HpGage();
			}
			

			else{
			col.GetComponent<CristalTower>().hpGage -= totPower;
			col.GetComponent<CristalTower>().HpGage();
			}
			InvokeDestroyingBullet();	

		}


		if(col.CompareTag("Bullet")){
		
			Destroy(gameObject);
		}

  
	}

	void InvokeDestroyingBullet()
	{

		GameObject tmpParticle = Instantiate(this_particle);
		tmpParticle.transform.position= this.transform.position;
		tmpParticle.transform.localScale*=this.transform.localScale.x*1/2;
		Destroy(gameObject);
		
	}

}
