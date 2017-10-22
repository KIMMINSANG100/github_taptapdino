using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Bar_Exp_Script : MonoBehaviour
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


    public float MaxExpValue { get; set; }


//Nan의 문제는 fillamount 세번째칸 maxexp가 설정이 안되었기때문
    public float Value
    {   
        set
        {
            string[] tmp = expText.text.Split(':');

            expText.text = tmp[0] + ": " + value + " / " + MaxExpValue;
            

            fillAmount = Map(value, 0, MaxExpValue, 0, 1);
            
            exp= value;
        }
    }





    [SerializeField]
    private Text levelText;

    public int Level
    { 


        set
        {
         //   string[] tmplevel = levelText.text.Split(':');

            levelText.text = "Level" + ": " + value; 	
            level = value;
            //if()
        }


    }

    


///  표시하는거!


    void Start()
    {            MaxExpValue=100;

        if (lerpColors) //Sets the standard color
        {
            content.color = fullColor;
        }

        Value=0;


    levelCompare = ControlTowerScript.controlTowerScript.dinosLevel[ControlTowerScript.controlTowerScript.invennumberShared];
    level = ControlTowerScript.controlTowerScript.dinosLevel[ControlTowerScript.controlTowerScript.invennumberShared];
    exp = ControlTowerScript.controlTowerScript.dinosExp[ControlTowerScript.controlTowerScript.invennumberShared];
    }

private int level = 1;
private float exp ;
private float expCompare ;

float levelCompare=1;
[SerializeField]
private GameObject levelUpParticle;
[SerializeField]

private GameObject levelUpText;


bool thisStarted;

    void Update ()
    {
         



        if(expCompare!=exp)
        {  
                string[] tmp = expText.text.Split(':'); 

               expText.text = tmp[0] + ": " + exp + " / " + MaxExpValue;

        }

///////

        if(levelCompare!=level)
        {
            Debug.Log("levelup1");


		    if(level!=1 && thisStarted==true )
            {   
                Instantiate(levelUpParticle);
        //		CombatTextManager.Instance.CreateLevelUpText(levelUpParticle.transform.position + new Vector3( 0, 1,0));

            Debug.Log("levelup2");

            Vector2 screenPoint = Camera.main.WorldToViewportPoint(new Vector2(1,1));
 		
			if( ( screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)){
 			            Debug.Log("levelup3");

                GameObject tmpTxt = Instantiate(levelUpText);
                tmpTxt.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform);
                tmpTxt.transform.position = new Vector3( 0,0,0);   
                tmpTxt.transform.localScale = new Vector3( 10,10,10);    

                BtnSounds.instance.LevelUp();
                }
            }


             levelCompare=level;

        }
            //Makes sure that handle bar is called.
            HandleBar();

        expCompare = exp;

    }


    /// <summary>
    /// Updates the bar
        /// </summary>
    private void HandleBar()
    {
    
        if (fillAmount != content.fillAmount) //If we have a new fill amount then we know that we need to update the bar
        {
            //Lerps the fill amount so that we get a smooth movement
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);

            if (lerpColors) //If we need to lerp our colors
            {   
                //Lerp the color from full to low
                content.color = Color.Lerp(lowColor, fullColor, fillAmount);
            }
           
        }

        thisStarted=true;
    }





    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

}
