using System;
using UnityEngine;
using UnityEngine.UI;

public class Bar_HP_Enemy : MonoBehaviour
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
    private Text hP_Text;   //////////


    [SerializeField]
    private Image content;

    private float fillAmount;  ///////////


    public float MaxHpValue { get; set; }

    public float Value
    {
        set
        {
            string[] tmp = hP_Text.text.Split(':');

            hP_Text.text = tmp[0] + ": " + value + " / " + MaxHpValue;

            fillAmount = Map(value, 0, MaxHpValue, 0, 1);
        }
    }



 

    




///  표시하는거!


    void Start()
    {
        if (lerpColors) //Sets the standard color
        {
            content.color = fullColor;
        }
    }

float level;
float levelCompare;
[SerializeField]
private GameObject levelUpParticle;

[SerializeField]
private GameObject levelUpText;

    void Update ()
    {
        
            
        if(levelCompare!=level)
        {
            Instantiate(levelUpParticle);
    //		CombatTextManager.Instance.CreateLevelUpText(levelUpParticle.transform.position + new Vector3( 0, 1,0));

            GameObject tmpTxt = Instantiate(levelUpText);
            tmpTxt.transform.SetParent(GameObject.FindGameObjectWithTag("DamageManager").transform);
            tmpTxt.transform.position = new Vector3( -4.8f,0,0);
        }
        //Makes sure that handle bar is called.
        HandleBar();
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
        levelCompare=level;
    }





    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
