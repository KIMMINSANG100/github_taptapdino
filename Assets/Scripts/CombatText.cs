using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatText : MonoBehaviour {

	// Use this for initialization

	private float speed;

	private Vector3 direction = Vector3.zero;

	[SerializeField]
	private float fadeTime=2;

	public AnimationClip critAnim;
	private bool crit;

	private bool stay = true;

	Transform pos;
		void Start () 
	{
		 
		float newX =Random.Range(-12,10);
		float newY =Random.Range(0,15);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(newX,speed+newY )* 3000*Time.deltaTime);

	pos = transform;
//	 	transform.LookAt(2*transform.position - CombatTextManager.Instance.camTransform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if(stay)
		{
			float translation = Time.deltaTime;

			transform.Translate ( direction * translation );
		}

	//	if(pos.position.y < 2)
	//	else
	//	GetComponent<Rigidbody2D>().AddForce(new Vector2(newX,40)* -300*Time.deltaTime);
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(newX,-400)* 10*Time.deltaTime);
	}

	bool rage;
	int critRandom ;
	public void Initialize(float speed, Vector3 direction, float fadeTime, bool crit)
	{
		this. speed = speed; 		//받아들인 값들을 이 텍스트의 speed로, fadeTime, direction, crit으로 설정. 원래 this.xxx는 private 변수라서 밖에서 가져온 값들로 해도 갠춘 으로 설정
		this. fadeTime = fadeTime;
		this. direction = direction;
		this. crit = crit;

			
		
//	rage = GameObject.FindGameObjectWithTag("RageBar").GetComponent<Bar_Rage_Scr>(). rage_start;

	
	crit = true ;//GameObject.FindGameObjectWithTag("AttackPowerText").GetComponent<AttackTextManager>().crit;
			if(crit) 					// crit이 true면 이 텍스트 animator의 Critical Trigger를 실행
			{
				//GameObject.FindGameObjectWithTag("AttackPowerText").GetComponent<AttackTextManager>().critRandom = 2;
				//Debug.Log("true");
				StartCoroutine(FadeOut());
				StartCoroutine(Critical());

			}
			else
			{
				StartCoroutine(FadeOut());
								StartCoroutine(Critical());

			//	GameObject.FindGameObjectWithTag("AttackPowerText").GetComponent<AttackTextManager>().critRandom = 1;
			}

	
	}



		private IEnumerator Critical()
		{
			yield return new WaitForSeconds (2);
			crit = false;
			StartCoroutine (FadeOut());


		}

	/*	stay = critical;

		if(critical)
		{
			GetComponent<Animator>().SetTrigger("Critical");


		} 
*/
	

	private IEnumerator FadeOut()
	{
		float startAlpha = GetComponent <Text> (). color. a;

		float rate = 1.0f / fadeTime;

		float progress = 0.0f ;

		while ( progress <1.0)
		{
			Color tmpColor = GetComponent<Text>(). color;
			GetComponent<Text>().color = new Color (tmpColor.r , tmpColor.g, tmpColor.b, Mathf.Lerp(startAlpha, 0, progress ));

			progress += rate * Time. deltaTime;
	
			yield return null;

		}
		
		Destroy(gameObject);
	}
}
