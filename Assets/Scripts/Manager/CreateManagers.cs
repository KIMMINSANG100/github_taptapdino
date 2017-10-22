using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManagers : MonoBehaviour {

	[SerializeField] GameObject inventory;
	public GameObject shop;
	public GameObject book;
	// Use this for initialization


	public void createInven()
	{
	
		if(GameObject.FindGameObjectWithTag("active").transform.Find("inventory(Clone)")==null&&GameObject.FindGameObjectWithTag("active").transform.Find("inventory")==null)
		{

			GameObject tmp = Instantiate(inventory);
			tmp.transform.parent = GameObject.FindGameObjectWithTag("active").transform;
			tmp.transform.position = new Vector3 (0,0);
		
		}		


	}

	public void createShop()
	{
	
		if(GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("Shop(Clone)")==null)
		{

			GameObject tmp = Instantiate(shop);
			tmp.transform.parent = GameObject.FindGameObjectWithTag("MainCanvas").transform;
			tmp.transform.position = new Vector3 (0,0);
						tmp.transform.localScale = new Vector3 (1,1);

		}		
	}
	public void createBook()
	{
	
		if(GameObject.FindGameObjectWithTag("active").transform.Find("book(Clone)")==null)
		{

//			GameObject tmp = Instantiate(book);
//			tmp.transform.parent = GameObject.FindGameObjectWithTag("active").transform;
		}		
	}
	
	public void createAll()
	{
		Transform active = GameObject.FindGameObjectWithTag("active").transform;
	
	
		if(active.Find("inventory(Clone)")==null)
		{

			GameObject tmp = Instantiate(inventory);
			tmp.transform.parent = GameObject.FindGameObjectWithTag("active").transform;
			tmp.transform.position = new Vector3 (0,0);
			Debug.Log("invve");
		}		

		if(active.Find("book(Clone)")==null)
		{
Debug.Log("book");
			GameObject tmp = Instantiate(book);
			tmp.transform.parent = GameObject.FindGameObjectWithTag("active").transform;
		}		
	

		if(GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("Shop(Clone)")==null)
		{

			GameObject tmp = Instantiate(shop);
									tmp.transform.parent = GameObject.FindGameObjectWithTag("MainCanvas").transform;

			tmp.transform.localScale = new Vector3 (1,1);
			tmp.transform.localPosition = new Vector3 (0,0);

		}		
	}
}
