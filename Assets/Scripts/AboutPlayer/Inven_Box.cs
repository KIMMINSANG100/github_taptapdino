using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inven_Box : MonoBehaviour {
 

	[SerializeField]
	public int inven_Number ;

	 
	void Start () {

		invenInit();
			

	}


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
	
				 ControlTowerScript.controlTowerScript.invennumberShared= inven_Number;
			
				InventoryManager.Inventory.inven_Number = inven_Number;
					StartCoroutine(dealayInven());
		}
	}

	IEnumerator dealayInven()
	{

			yield return new WaitForSeconds(0.05f);
			InventoryManager.Inventory.call_invenCoroutine();

	}
 
}
