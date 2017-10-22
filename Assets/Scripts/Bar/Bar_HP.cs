using System;
using UnityEngine;
using UnityEngine.UI;

public class Bar_HP : MonoBehaviour
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
    private Text hpText;   //////////


    [SerializeField]
    private Image content;

    private float fillAmount;  ///////////


    public float MaxHpValue { get; set; }


//Nan의 문제는 fillamount 세번째칸 maxexp가 설정이 안되었기때문
    public float Value
    {   
        set
        {
            //string[] tmp = hpText.text.Split(':');

           // hpText.text = tmp[0] + ": " + value + " / " + MaxHpValue;
            
            hpText.text =  value + " / " + MaxHpValue;

            fillAmount = Map(value, 0, MaxHpValue, 0, 1);
            
            hp= value;
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
    {            MaxHpValue=100;

        if (lerpColors) //Sets the standard color
        {
            content.color = fullColor;
        }

        Value=0;


    }

private int level = 1;
private float hp ;
private float hpCompare ;

float levelCompare=1;
[SerializeField]
private GameObject levelUpParticle;
[SerializeField]

private GameObject levelUpText;

 

    void Update ()
    {
         



        if(hpCompare!=hp)
        {  
//                string[] tmp = hpText.text.Split(':'); 

//               hpText.text = tmp[0] + ": " + hp + " / " + MaxHpValue;

        }

///////

        if(levelCompare!=level)
        {

		    if(level!=1 )
            {   
                Instantiate(levelUpParticle);
        //		CombatTextManager.Instance.CreateLevelUpText(levelUpParticle.transform.position + new Vector3( 0, 1,0));

                GameObject tmpTxt = Instantiate(levelUpText);
                tmpTxt.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform);
                tmpTxt.transform.position = new Vector3( 0,0,0);   
                tmpTxt.transform.localScale = new Vector3( 1,1,1);    
 
            }


             levelCompare=level;

        }
            //Makes sure that handle bar is called.
            HandleBar();

        hpCompare = hp;

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
    }





    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }


}
