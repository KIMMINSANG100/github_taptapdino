using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn_FadeOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

	[SerializeField]
	Color32 FadeFactor = new Color32 (0,0,0,10);
	// Update is called once per frame
	void Update () {
		
		GetComponent<SpriteRenderer>().color -= new Color32 (0,0,0, FadeFactor.a);

		if(GetComponent<SpriteRenderer>().color == new Color32 (0,0,0,15))
			Destroy(gameObject);


	}
}
