using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		if(ControlTowerScript.controlTowerScript.preSceneNumber==5||ControlTowerScript.controlTowerScript.preSceneNumber==4)
		InvokeShop_Fairy();

        ControlTowerScript.controlTowerScript.SceneNumber=7;
	}
	
	// Update is called once per frame



    public void InvokeShop_Item()
    {
        BtnSounds.instance.ShopBtns();

        GameObject Shop = GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("Shop(Clone)").gameObject;
        Shop.transform.Find("Item_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Shop.transform.Find("Egg_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 130);
        Shop.transform.Find("Fairy_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 130);
        Shop.transform.Find("Crist_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 130);

        Shop.transform.Find("Item_Btn").GetChild(0).gameObject.SetActive(true);
        Shop.transform.Find("Egg_Btn").GetChild(0).gameObject.SetActive(false);
        Shop.transform.Find("Fairy_Btn").GetChild(0).gameObject.SetActive(false);
        Shop.transform.Find("Crist_Btn").GetChild(0).gameObject.SetActive(false);
    }
    public void InvokeShop_Egg()
    {
        BtnSounds.instance.ShopBtns();

        GameObject Shop = GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("Shop(Clone)").gameObject;
        Shop.transform.Find("Item_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 130);
        Shop.transform.Find("Egg_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Shop.transform.Find("Fairy_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 130);
        Shop.transform.Find("Crist_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 130);

        Shop.transform.Find("Item_Btn").GetChild(0).gameObject.SetActive(false);
        Shop.transform.Find("Egg_Btn").GetChild(0).gameObject.SetActive(true);
        Shop.transform.Find("Fairy_Btn").GetChild(0).gameObject.SetActive(false);
        Shop.transform.Find("Crist_Btn").GetChild(0).gameObject.SetActive(false);
    }
    public void InvokeShop_Fairy()
    { 
        BtnSounds.instance.ShopBtns();

        GameObject Shop = GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("Shop(Clone)").gameObject;
        Shop.transform.Find("Item_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 130);
        Shop.transform.Find("Egg_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 130);
        Shop.transform.Find("Fairy_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Shop.transform.Find("Crist_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 130);

        Shop.transform.Find("Item_Btn").GetChild(0).gameObject.SetActive(false);
        Shop.transform.Find("Egg_Btn").GetChild(0).gameObject.SetActive(false);
        Shop.transform.Find("Fairy_Btn").GetChild(0).gameObject.SetActive(true);
        Shop.transform.Find("Crist_Btn").GetChild(0).gameObject.SetActive(false);
    }


    public void InvokeShop_Crist()
    {
        BtnSounds.instance.ShopBtns();

        GameObject Shop = GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("Shop(Clone)").gameObject;
        Shop.transform.Find("Item_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 130);
        Shop.transform.Find("Egg_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 130);
        Shop.transform.Find("Fairy_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 130);
        Shop.transform.Find("Crist_Btn").GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        Shop.transform.Find("Item_Btn").GetChild(0).gameObject.SetActive(false);
        Shop.transform.Find("Egg_Btn").GetChild(0).gameObject.SetActive(false);
        Shop.transform.Find("Fairy_Btn").GetChild(0).gameObject.SetActive(false);
        Shop.transform.Find("Crist_Btn").GetChild(0).gameObject.SetActive(true);
    }

}
