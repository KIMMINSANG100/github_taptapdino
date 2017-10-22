using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSounds : MonoBehaviour {
public static BtnSounds instance;

	public AudioClip EnterSound;
	public AudioClip ExitSound;

	public AudioClip LevelUpSound;
	public AudioClip ShopBtnSound;
	public AudioClip EatSound;
	public AudioClip DrinkSound;

	
 void Awake(){


	if(instance==null)
	{
		DontDestroyOnLoad(transform.gameObject);
		instance=this;
	}
	else if(instance != this)
	{
		Destroy(instance);
	}

 }
	
	[SerializeField]
	int thisSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void BeepSound()
	{
		if(thisSound==0)
			AudioSource.PlayClipAtPoint(EnterSound , transform.position, 1);
		else if(thisSound==1)
			AudioSource.PlayClipAtPoint(ExitSound , transform.position, 1);


	}
	public void Enter()
	{
 			AudioSource.PlayClipAtPoint(EnterSound , transform.position, 1); 
	}
	public void Exit()
	{ 
			AudioSource.PlayClipAtPoint(ExitSound , transform.position, 1);


	}

	public void LevelUp()
	{
			AudioSource.PlayClipAtPoint(LevelUpSound , transform.position, 1);

	}

	public void ShopBtns()
	{
			AudioSource.PlayClipAtPoint(ShopBtnSound , transform.position, 1);

	}
	public void Eat()
	{
			AudioSource.PlayClipAtPoint(EatSound , transform.position, 1);

	}
	public void Drink()
	{
			AudioSource.PlayClipAtPoint(DrinkSound , transform.position, 1);

	}
}
