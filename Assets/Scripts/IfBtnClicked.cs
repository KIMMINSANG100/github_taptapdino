using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfBtnClicked : MonoBehaviour
{
    GameObject ControlTower;

    Animator myanimator;
    bool clicked;
    // Use this for initializatio`


    [SerializeField]
    GameObject thisParticle;

    void Start()
    {                


        myanimator = GetComponent<Animator>();


        if (GameObject.FindGameObjectWithTag("ControlTower") != null)
            ControlTower = GameObject.FindGameObjectWithTag("ControlTower").gameObject;
    }
    // int clicknumber = 0;
    // void Update()
    // {

    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         clicknumber++;

    //         if (this.name == "clickMotion(Clone)" && clicknumber == 2)
    //         {

    //             Destroy(this.gameObject);
    //         }
    //     }



    //     if (this.name == "InputField")
    //     {
    //         if (this.transform.Find("Text").GetComponent<Text>().text.Length == 0)
    //         {
    //             this.transform.parent.transform.Find("Enter_NameInput").GetComponent<Button>().enabled = false;
    //         }
    //         else
    //             this.transform.parent.transform.Find("Enter_NameInput").GetComponent<Button>().enabled = true;
    //     }

    //     if (ControlTower != null)
    //     {
    //         if (this.name == "MeatBtn")
    //         {
    //             transform.Find("number").GetComponent<Text>().text = ControlTowerScript.controlTowerScript.meat.ToString();

    //             if (ControlTowerScript.controlTowerScript.meat <= 0)
    //             {
    //                 GetComponent<Button>().enabled = false;
    //             }

    //             else
    //             {
    //                 GetComponent<Button>().enabled = true;
    //             }
    //         }


    //         if (this.name == "PotionBtn")
    //         {

    //             transform.Find("number").GetComponent<Text>().text = ControlTowerScript.controlTowerScript.potion.ToString();


    //             if (ControlTowerScript.controlTowerScript.potion <= 0)
    //             {
    //                 GetComponent<Button>().enabled = false;
    //             }

    //             else
    //             {
    //                 GetComponent<Button>().enabled = true;
    //             }
    //         }

    //         if (this.name == "HurbBtn")
    //         {

    //             transform.Find("number").GetComponent<Text>().text = ControlTowerScript.controlTowerScript.expHurb.ToString();

    //             if (ControlTowerScript.controlTowerScript.expHurb <= 0)
    //             {
    //                 GetComponent<Button>().enabled = false;
    //             }

    //             else
    //             {
    //                 GetComponent<Button>().enabled = true;
    //             }
    //         }
    //     }
    //     //	GoMain();
    // }
 

    void Save()
    {
        ControlTowerScript.controlTowerScript.Save();
    }

    void OnMouseDown()
    {

        if (this.name == "BackBtn")
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }

        if (this.name == "Help")
        {
            this.gameObject.SetActive(false);
        }

        if (this.name == "SkipTrailer")
        {
            GameObject.FindGameObjectWithTag("OtherManager").GetComponent<SpawnLoadingScript>().Loading();

            SubTowerScript.subTowerScript.LoadTutorial();

        }




        //	myanimator.SetBool("Clicked", true);
         
        clicked = true;
    }




    void OnMouseUp()
    {
        if (this.name == "BackBtn")
        {
            GoMain();
            GetComponent<SpriteRenderer>().color = Color.white;

        }


        if (this.name == "Tut_x")
        {
            this.transform.parent.gameObject.SetActive(false);
        }






        clicked = true; 
        //	myanimator.SetBool("Clicked", false);
    }



    public void GoMain()
    {
        BtnSounds.instance.Exit();
         

        //		 if( GameObject.FindGameObjectWithTag("BelowText")  ==null)
        {

            //광고
            AdManager.Instance.ShowBanner();

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position = new Vector3(0, 0, -20);




            clicked = false;
        }
    }

    public void GoSetting()
    {
        BtnSounds.instance.Enter();
         ;
        //		 if( GameObject.FindGameObjectWithTag("BelowText")  ==null)
        {

            //광고
            AdManager.Instance.HideBanner();

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position = new Vector3(0, -30, -20);




            clicked = false;
        }
    }



    //    새로시작 : yes & no 버튼
    public void startY_N()
    {
        transform.Find("Start_YN").gameObject.SetActive(true);
        transform.parent.transform.Find("Btn_Continue").GetComponent<Button>().enabled = false;

    }


    public void startY_N_NO()
    {
        transform.parent.gameObject.SetActive(false);
        transform.parent.transform.parent.transform.parent.transform.Find("Btn_Continue").GetComponent<Button>().enabled = true;

    }
 GameObject Inventory;
public InitInvenAll InvenInit;
public GameObject Books;
public CharacterBook BookPanel;
    public void GoBook()
    {       
        GetComponent<CreateManagers>().createBook();
        BtnSounds.instance.Enter();


        Books = GameObject.FindGameObjectWithTag("active").transform.Find("book(Clone)").gameObject;

        if(Books!=null)
            Books.SetActive(true);
        if(BookPanel!=null)
            BookPanel.bookStart();
      //  if(Inventory!=null)
    //        Inventory.SetActive(false);
 
 
        GameObject MainCam = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
        GameObject Book = GameObject.FindGameObjectWithTag("BookAll").gameObject;
        MainCam.GetComponent<Animator>().enabled = false;


        //광고
        AdManager.Instance.HideBanner();


        //		 if( GameObject.FindGameObjectWithTag("BelowText")  ==null)
        {


            Book.transform.position = MainCam.transform.position + new Vector3(0, 0, 1);
            clicked = false;
        }
    }

 


    public void GoStatus()
    {
        BtnSounds.instance.Enter();

         
        //		 if( GameObject.FindGameObjectWithTag("BelowText")  ==null)
        {

            clicked = false;
        }
    }


    public void GoSave()
    {  
         Save();
    }

    public void SaveAlarm()
    {
        this.transform.Find("Alarm").gameObject.SetActive(true);
    }
    public void setactiveFalse()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
 
    public void BelowTextSetFalse()
    {
        GameObject.FindGameObjectWithTag("BGText").transform.GetChild(0).gameObject.SetActive(false);

    }






    public void NameEnter()
    {

        
        Transform mainCanvasTrans = GameObject.FindGameObjectWithTag("MainCanvas").transform;

        mainCanvasTrans.Find("NameInputPanel").gameObject.SetActive(false);

        UpdateDinosInfo_Inven();


    }






    public void SaveDinosInfo_Inven()
    {
        BtnSounds.instance.Enter();

        
        if(ControlTowerScript.controlTowerScript.SceneNumber!=2){
        Dino_Individual Player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Dino_Individual>();

        Player.Save_DinoStatus();
        }

    }


    public void UpdateDinosInfo_Inven()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.GetChild(0).GetComponent<Dino_Individual>().Update_DinoStatus();
    }



    //버튼 메인 메뉴

    bool main_Btn = true;
    public void Btn_Menu_Main()
    {
         

        if (main_Btn == false)
        {
            //	transform.localScale = new Vector2 ( -1, transform.localScale.y);
            transform.GetChild(0).gameObject.SetActive(true);
            main_Btn = true;
        }

        else if (main_Btn == true)
        {
            ///	transform.localScale = new Vector2 ( 1, transform.localScale.y);
            transform.GetChild(0).gameObject.SetActive(false);
            main_Btn = false;
        }
    }
 
  
    /// 샵 버튼

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
        if(Inventory!=null)
        Inventory.SetActive(false);

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

    //using btn



    public void PotionNumber()
    {
        int potionNumb = ControlTowerScript.controlTowerScript.potion;

        if (potionNumb > 0)
            ControlTowerScript.controlTowerScript.potion--;
    }

    public void PotionEffect()
    {

        BtnSounds.instance.Drink(); 

        int sceneNumber = ControlTowerScript.controlTowerScript.SceneNumber;
        if (GameObject.FindGameObjectWithTag("Player") != null && sceneNumber != 2)
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");

            Player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("HasteOn");  //rageOn=true; 
        }

        else if (sceneNumber == 2)
        {
            GameObject[] Dinos = GameObject.FindGameObjectsWithTag("Dino");

            for (int a = 0; a < Dinos.Length; a++)
            {
                if (Dinos[a].gameObject.GetComponent<Dino_Individual>() != null)
                {
                    Dinos[a].gameObject.GetComponent<Animator>().SetTrigger("HasteOn");


                }
            }

        }
    }


    public void MeatNumber()
    {
        int MeatNumb = ControlTowerScript.controlTowerScript.meat;

        if (MeatNumb > 0)
            ControlTowerScript.controlTowerScript.meat--;
    }


    // rage on true => individual 에서 1) ragegage를 킴 2)ragegage에서 값을 초기화시킴
    public void MeatEffect()
    {
        BtnSounds.instance.Eat();
        int sceneNumber = ControlTowerScript.controlTowerScript.SceneNumber;
        if (GameObject.FindGameObjectWithTag("Player") != null && sceneNumber != 2)
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");

            Player.transform.GetChild(0).GetComponent<Dino_Individual>().rageGage += 100;  //rageOn=true;
                                                                                           //Player.transform.GetChild(0).GetComponent<Dino_Individual>().rageGage=Player.transform.GetChild(0).GetComponent<Dino_Individual>().maxRage;

            GameObject tmpParticle = Instantiate(thisParticle);
            tmpParticle.transform.position = Player.transform.GetChild(0).transform.Find("Body").transform.position;
        }



        else if (sceneNumber == 2)
        {
            GameObject[] Dinos = GameObject.FindGameObjectsWithTag("Dino");

            for (int a = 0; a < Dinos.Length; a++)
            {
                if (Dinos[a].gameObject.GetComponent<Dino_Individual>() != null)
                {
                    Dinos[a].gameObject.GetComponent<Dino_Individual>().rageGage += 100;//rageOn=true;
                                                                                        //Dinos[a].gameObject.GetComponent<Dino_Individual>().rageGage=Dinos[a].GetComponent<Dino_Individual>().maxRage;


                }
            }

        }
    }

    public void HurbNumber()
    {
        int expHurbNumb = ControlTowerScript.controlTowerScript.expHurb;

        if (expHurbNumb > 0)
            ControlTowerScript.controlTowerScript.expHurb--;
    }

    public void HurbEffect()
    {
        BtnSounds.instance.Eat();
        //int i = transform.parent.GetComponent<InvenSideImg>().invenNumber ;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        Player.transform.GetChild(0).GetComponent<Dino_Individual>().dinosExp += 1000;


        GameObject tmpParticle = Instantiate(thisParticle);
        tmpParticle.transform.position = Player.transform.GetChild(0).transform.Find("Head").transform.position;
        tmpParticle.transform.SetParent(Player.transform.GetChild(0));

    }




    public void Alarm_X()
    {

        GameObject AlarmText = GameObject.FindGameObjectWithTag("AlarmText").gameObject;

        AlarmText.transform.parent.gameObject.SetActive(false);

    }

    public void NameToDino()
    {
        string a = this.transform.parent.Find("InputField").Find("Text").GetComponent<Text>().text;
        ControlTower.GetComponent<CharacterInstantiating>().SendNameToChar(a);
    }

 
    public void homeFromMapSelect()
    {
        BtnSounds.instance.Exit();

        transform.parent.parent.parent.gameObject.SetActive(false);
        AdManager.Instance.ShowBanner();

    }

 

}