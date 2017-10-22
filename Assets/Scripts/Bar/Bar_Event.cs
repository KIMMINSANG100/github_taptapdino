using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_Event	 : MonoBehaviour
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


       if(value<=0)
       value=0;

			int hours =(int)value /3600;
			minutes = ((int)value - hours *3600) / 60;
			seconds = (int)value % 60 ;

       //  string[] tmp = timeText.text.Split(':');
            timeText.text =  hours + ":" + minutes +":" + seconds .ToString() ;


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
        StartCoroutine(Bar_Update());
    
    } 




    IEnumerator Bar_Update()
    {
        //Makes sure that handle bar is called.
   
        while(true){
        HandleBar();
        yield return new WaitForSeconds(0.3f);
        }
    }


    [SerializeField]
    TimeCounter_Event TimeLeftTxt;

    public int numberOfMine;
   
   [SerializeField]
    bool eggActive  = false;
   

   [SerializeField]
   GameObject ClickClick;
   private void HandleBar()
   {   


        TimeValue=  TimeLeftTxt.ellapsedTime;
        if(TimeValue>0)
            eggActive =false;

       
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

               if(autoBlink==false){
                    StopCoroutine(blinkblink());
                    autoBlink=true;
                    }

            

        }

            if( content.fillAmount ==1 )
           {

               if(autoBlink==true){
                    StartCoroutine(blinkblink());
                    autoBlink=false;
                    GameObject tmp = Instantiate(ClickClick);
                    tmp.transform.position = this.transform.position;
                    }


 
                TimeValue =0;

                eggActive =true;
                

        
                    content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
                      content.fillAmount= fillAmount;

                if (lerpColors) //If we need to lerp our colors
                {   
                    //Lerp the color from full to low
                    content.color = Color.Lerp(lowColor, fullColor, fillAmount);
                }


          }

//        if( GetComponent<Image>().sprite ==  GameObject.FindGameObjectWithTag("Spot_EggBar").transform.GetChild(0). GetComponent<Image>().sprite  )

// 흔들기  
    }
int k =0;
 
public int invenNumbShare; 

	bool autoBlink = true;
	bool blink =false;
	IEnumerator blinkblink()
	{
		while(true)
		{
			if(blink==false)
			{
				this.content.color = new Color32 ( 255, 255, 255, 40 );
				blink = true;
			}
			else if(blink==true){
				this.content.color = new Color32 (255, 255, 255, 255);
				blink=false;
			}
			yield return new WaitForSeconds(0.1f);
 
		}

	}

    void invokeDinoImg1sec()
    {
        
	        Transform EandStrans = GameObject.FindGameObjectWithTag("EandS").transform;
   	        Transform PlayerTrans = GameObject.FindGameObjectWithTag("Player").transform;
	
            EandStrans.Find("Img_EGG").GetComponent<SpriteRenderer>().sprite =PlayerTrans.GetChild(0).GetComponent<SpriteRenderer>().sprite;


    }



    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return 1-(value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
 


[SerializeField]
GameObject Explanation;
[SerializeField]
GameObject AdPanel_YN;
[SerializeField]
bool clicked =false;
    void OnMouseDown()
    {

        // if(clicked==false){
            if(eggActive==false)
            {   
                if(Explanation!=null)
                Explanation.SetActive(true);
                Debug.Log("activefalse");
            }

            else if(eggActive==true)
            {
                if(AdPanel_YN!=null)
                AdPanel_YN.SetActive(true);    
                eggActive=false;
                Debug.Log("true");
            }
            // clicked=true;
        // }
        // else if(clicked==true){
        //     if(eggActive==true)
        //     {   
        //         if(Explanation!=null)
        //         Explanation.SetActive(false);
        //         Debug.Log("activefalse");
        //     }

        //     else if(eggActive==false)
        //     {
        //         if(AdPanel_YN!=null)
        //         AdPanel_YN.SetActive(true);    

        //         Debug.Log("true");
        //     }
        //     clicked=false;
        // }
        

    }
    

}
 