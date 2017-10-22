using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bar_Rage_Scr : MonoBehaviour
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
    private Text expText;   //////////


    [SerializeField]
    private Image content;

    private float fillAmount;  ///////////


    public float MaxRageValue { get; set; }

    public float RageValue
    {


        set
        {
            string[] tmp = expText.text.Split(':');

            expText.text =value + " / " + MaxRageValue;
// tmp[0] + ": " + 
            fillAmount = Map(value, 0, MaxRageValue, 0, 1);
        }
    }



    void Start()
    {
        MaxRageValue = 650;
        RageValue=0;
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

public bool rage_start= false;
int i=0;

[SerializeField]
private GameObject rageParticle;


    private void HandleBar()
    {   
        //    content.fillAmount = Mathf.Lerp(fillAmount,0, Time.deltaTime * lerpSpeed);
        // 게이지 풀!! 분노시작!!


        // 분노 파티클

        if(content.fillAmount==1 )//&& ! content.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Rage") )
        {
            //content.GetComponent<Animator>().SetTrigger("RageStart");
    //분노상태 색깔변화            
            rage_start=true;

            GetComponent<Text>().text= "MAX";
    // 분노
          RageValue=0;
    
        }





        if (fillAmount != content.fillAmount) //If we have a new fill amount then we know that we need to update the bar
          {           
              content.fillAmount = fillAmount;
        
                if (lerpColors) //If we need to lerp our colors
                {   
                        content.fillAmount = Mathf.Lerp(fillAmount ,0, Time.deltaTime * lerpSpeed);

                }
            }


    //시간이 지나고 분노끝! 게이지 0
        
        if(content.fillAmount!=1 &&rage_start==true )//&& content.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Rage"))
        { 

                
           //     for(int k =0 ; k<5 ; k++)
          //  transform.parent.transform.parent.transform.GetComponent<SpriteRenderer>().color = new Vector4 ( 255, 255, 255, 255);


//                if(content.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Rage_Default"))
                {
                   fillAmount=0;
                }
            }    


    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }


public void RageEnd()
{
     RageValue=0;
}


private float fallDelay = 5 ;
	IEnumerator Rage_Continue()
	{
		yield return new WaitForSeconds(fallDelay);
        
        if(fillAmount!=1)
        {

            rage_start= false;
        }    

    }


public void RageParticle()
{
    
    
            GameObject tmp = Instantiate(rageParticle);
            tmp.transform.position = new Vector3 ( -4.95f, -1.12f , 1);
}
}
