using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDealScr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("switchNumber");
	
		if(this.name =="Hot_Deal_Eggs")
			{
				
			}
		}
	int k=0;
	// Update is called once per frame
	void Update () {

		if(Time.time >=10 * k){
			k++;
			StopCoroutine("switchNumber");

			StartCoroutine("switchNumber");
		}
	}


	[SerializeField]
	int switching;
	IEnumerator switchNumber()
	{
		while(true){
		for(int a=0; a< transform.childCount ; a++)
		{
			transform.GetChild(a).gameObject.SetActive(false);
		}		
		transform.GetChild(switching).gameObject.SetActive(true);
		yield return new WaitForSeconds(6);
		switching ++;
		if(switching >=transform.childCount)
		switching =0;

		}
	}
}
