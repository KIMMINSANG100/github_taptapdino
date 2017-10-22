using System;
using UnityEngine;
using UnityEngine.UI;

public class Bar_EggTimeScript : MonoBehaviour
{
    [SerializeField]
    private bool lerpColors;

    [SerializeField]
    private Color fullColor;

    [SerializeField]
    private Color lowColor;



    [SerializeField]
    private float lerpSpeed; 

    [SerializeField]
    private Text timeText;   //////////


    [SerializeField]
    private Image content;

    private float fillAmount;  ///////////


    public float MaxTimeValue { get; set; }


    public float timeValue;
    public float TimeValue
    {
        get
        {

            return timeValue;
        }

        set
        {
			minutes = (int)value / 60;
			seconds = (int)value % 60 ;

       //  string[] tmp = timeText.text.Split(':');

      //      timeText.text =  string.Format("{0:00}:{1:00}",minutes,seconds);

            fillAmount = Map(value, 0, MaxTimeValue, 0, 1);

         }
    }


int minutes;
int seconds;


///  표시하는거!


    void Start()
    {
        if (lerpColors) //Sets the standard color
        {
            content.color = fullColor;
        }
    }

    void Update ()
    {
        //Makes sure that handle bar is called.
        HandleBar();


    }

    /// <summary>
    /// Updates the bar
        /// </summary>
   
   
   public int numberOfMine;
   
   public int ifItWasFirst = 0;
   
   private void HandleBar()
   {   
        TimeValue=  transform.Find("TimeLeftText").gameObject.GetComponent<TimeCounter>().ellapsedTime;
        
        if (fillAmount != content.fillAmount) //If we have a new fill amount then we know that we need to update the bar


        {
            //Lerps the fill amount so that we get a smooth movement
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
            content.fillAmount= fillAmount;
            
            if (lerpColors) //If we need to lerp our colors
            {   
                //Lerp the color from full to low
                content.color = Color.Lerp(lowColor, fullColor, fillAmount);
            }


        if( content.fillAmount ==1 && ifItWasFirst ==0 )
        {

            BoxCollider2D boxcol= this.gameObject.GetComponent<BoxCollider2D>();
            boxcol.enabled = true;

            TimeValue =0;

            ifItWasFirst =1;

        }



        }


//        if( GetComponent<Image>().sprite ==  GameObject.FindGameObjectWithTag("Spot_EggBar").transform.GetChild(0). GetComponent<Image>().sprite  )

// 흔들기 
        if( content.fillAmount ==1)
        {  content.fillAmount =1;
        
        if(k==0){
         GameObject tmpClick = Instantiate(Click);
         tmpClick.transform.position = this.transform.position + new Vector3(0.5f,2,0);
         tmpClick.transform.SetParent(this.transform);
        k++;
        }
        }
        else
        {
            Destroy(transform.Find("clickMotion(Clone)"));
        k=0;
        }
    }
int k =0;

[SerializeField]
GameObject Click;
public int invenNumbShare;
	 void OnMouseDown()
	 {
         

        if( content.fillAmount ==1&& ifItWasFirst==1)
        {
            Destroy(transform.Find("clickMotion(Clone)"));
 
            
            BoxCollider2D boxcol= this.gameObject.GetComponent<BoxCollider2D>();
            boxcol.enabled = false; 
            invenNumbShare= GameObject.FindGameObjectWithTag("ControlTower").GetComponent<CharacterInstantiating>().invenNumber;

             
// 캐릭터 생성 컨트롤타워로 에그instance => 캐릭터 instance
            GameObject SideImg = GameObject.FindGameObjectWithTag("Egg_SideImg").gameObject;

            Sprite thisEggImg =SideImg.GetComponent<SpriteRenderer>().sprite;

//......*알_부화
			ControlTowerScript.controlTowerScript.EggCompareToInstantiate(thisEggImg ,invenNumbShare);


        
         //   Transform invenBoxesTrans = GameObject.FindGameObjectWithTag("InventoryBoxes").transform;
       //     invenBoxesTrans.GetChild(invenNumbShare).GetComponent<Inven_Box>().Update_BoxImage();



//circle 객체 Img 없애기
            GameObject NestCircle = GameObject.FindGameObjectWithTag("Nest").transform.Find("Nest_Circle").gameObject;
            //GameObject SideImg = GameObject.FindGameObjectWithTag("Egg_SideImg").gameObject;
            int selectedNumb=  SideImg.GetComponent<Egg_SideImgScript>().eggSelectedNumb;

            NestCircle.transform.GetChild( selectedNumb ).GetComponent<SpriteRenderer>().sprite  = null;
            NestCircle.transform.GetChild( selectedNumb ).GetComponent<SpriteRenderer>().color   = new Vector4(0,0,0,0);
        
// 시간 마스크 비활성화
            this.gameObject.SetActive(false);


			ControlTowerScript.controlTowerScript.eggSpot[selectedNumb]=false;


            

// 알 이미지를 전송 + 애니메이션 실행
            Transform EnS_trans = GameObject.FindGameObjectWithTag("EandS").transform;
            SpriteRenderer Ens_SR  = EnS_trans.Find("AniObject").GetComponent<SpriteRenderer>();
            Animator Ens_AniTor = EnS_trans.Find("AniObject").GetComponent<Animator>();

            Ens_SR.sprite = this.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite;
            Ens_AniTor.SetTrigger("StartSpawning");
            
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3 (-25,0,-10);


            
//SideImg 없애기
            this.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite  = null;
            this.transform.parent.gameObject.GetComponent<SpriteRenderer>().color   = new Vector4(0,0,0,0);

            
            Invoke("invokeDinoImg1sec",1);

    //        ifItWasFirst =0;
            ///인스턴트 소환 



     ///        this.transform.parent.gameObject.SetActive(true);


         //   SpawningManager.Instance.EggImgCompare(GetComponent<Image>().sprite); // 이미지가 같은지 확인
         
// Destroy(gameObject); //bar delete


 
// 부화 씬 bg 불러오고 씬의 이미지에 오브젝트스프라이트 전달 => 터지는 파티클로 부화 => 대화창 : ㅇㅇㅇ가 태어났다.
//   


        }
 	}


    void invokeDinoImg1sec()
    {
        
	        Transform EandStrans = GameObject.FindGameObjectWithTag("EandS").transform;
   	        // Transform PlayerTrans = GameObject.FindGameObjectWithTag("Player").transform;

            // EandStrans.Find("Img_EGG").GetComponent<SpriteRenderer>().sprite =PlayerTrans.GetChild(0).GetComponent<SpriteRenderer>().sprite;


    }



    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }



    void InstantCharComparingImg(Sprite a)
    {
                  //  if(this.GetComponent<SpriteRenderer>().sprite = )

    }


}
 