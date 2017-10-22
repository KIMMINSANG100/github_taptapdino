using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	GameObject EndParticle;

	[SerializeField]
	bool itWillBeDestroyed =false ;

	void Start () {

	if(itWillBeDestroyed)
	Invoke("invokeDestroy",timeToDestroy);	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.GetComponent<ParticleSystem>()!=null)
		
 		if(!(this.gameObject.GetComponent<ParticleSystem>().IsAlive()))
		{

			Destroy(gameObject);
		} 

		
		
		
	}

	[SerializeField]
	float timeToDestroy=20;

	void OnTriggerEnter2D(Collider2D col){


	//	if(this.name=="Particle_GetEgg(Clone)"||this.name=="Particle_GetEgg")
		{ 
			if(col.CompareTag("Button"))
			{
				GameObject parTmp = Instantiate(EndParticle);
				parTmp.transform.position = col.gameObject.transform.position;
				Destroy(GetComponent<Rigidbody2D>());	
			
				Destroy(gameObject);
			}
		}	

	}



	void invokeDestroy()
	{
		Destroy(this.gameObject);
	}

}
