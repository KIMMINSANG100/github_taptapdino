using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float totPower;
	int	sceneNumber ;


	Rigidbody2D thisBody2D;
	Vector3 firstPos;
 	// Use this for initialization
	void Start () {
		if(GetComponent<Rigidbody2D>()!=null)
			thisBody2D=GetComponent<Rigidbody2D>();
	


	sceneNumber = ControlTowerScript.controlTowerScript.SceneNumber;
	firstPos = this.transform.position;


	if(sceneNumber==2)
		{	
			for(int k=0; k<transform.childCount ; k++)
			{
				{
					this.transform.GetChild(k).gameObject.SetActive(false);
				}
			}
		thisBody2D.gravityScale=0;
		thisBody2D.drag=0.2f;
		}


	if(sceneNumber==1)
	StartCoroutine(BulletFollowTargetOnScene1());
	StartCoroutine(bulletWentOut());

	}
	
	// Update is called once per frame 
IEnumerator BulletFollowTargetOnScene1()
{
	while(true){
	yield return new WaitForSeconds(0.03f);
 
	float gain=60;

// 가운데지점으로  
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

		Vector3 thisPos = this.transform.position;

		if((firstPos.y-thisPos.y)>0)
			thisBody2D.AddForce(new Vector3(0,gain));
		
		else if((firstPos.y-thisPos.y)<0)
		if(				thisBody2D!=null)
				thisBody2D.AddForce(new Vector3(0,-gain));
				

		if(GameObject.FindGameObjectWithTag("Target")!=null )

		if(GameObject.FindGameObjectWithTag("Target").transform.position.y< max.y){
		if((thisPos.x)>GameObject.FindGameObjectWithTag("Target").transform.position.x)
							thisBody2D.AddForce(new Vector3(-(thisPos.x- GameObject.FindGameObjectWithTag("Target").transform.position.x)*1.8f ,-(thisPos.y - GameObject.FindGameObjectWithTag("Target").transform.position.y)*1/3)*gain);
 
 	}
	 }

}	

IEnumerator bulletWentOut()
{

	while(true){
	
	yield return new WaitForSeconds(0.4f);

			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));




			if(sceneNumber==2&&this.transform.position.x>55)
							
			Destroy(gameObject);

			else if(sceneNumber!=2&& (transform.position.x > max.x+4 || transform.position.x < min.x-12 ||transform.position.y > max.y+4 || transform.position.y < min.y-1)){


			Destroy(gameObject);

		}



	}
}	

[SerializeField]
GameObject this_particle;
	void OnTriggerEnter2D(Collider2D col)
	{

		if(!(col.CompareTag("Item")||col.CompareTag("Egg")||col.name=="Left")){
				
			if(!col.CompareTag("Dino")&&!col.CompareTag("Bullet")){
			int a = Random.Range(0,5);

				if(GetComponent<MoveToAnywhere>()==null)
					{
		
							if(gameObject.activeSelf ==true)
									StartCoroutine(destroyBullet(0.01f*a));
					}
				else
							StartCoroutine(destroyBullet(0.01f*a));
			}
		}


		if(this.name=="Green_Fire_1(Clone)")
		{
			totPower*=3;


		}
	}
//별점과 리뷰는 큰 응원이 됩니다~! 응원해주시면 좋은 게임으로 보답하겠습니다!
	IEnumerator destroyBullet(float time)
	{
 		yield return new WaitForSeconds(time);
 		
		GameObject tmpParticle = Instantiate(this_particle);
		
		tmpParticle.transform.position= this.transform.position;
		tmpParticle.transform.localScale*=this.transform.localScale.x*1/2;
	
				if(sceneNumber==2)
				gameObject.SetActive(false);

			else
		Destroy(gameObject);
	}
 
	

}
