using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/*

[Serializable]
class Stat1
{




    /// 이건 경험치 STAT----------------------------
    [SerializeField]
    private BarScript bar;

    [SerializeField]
    private float maxExp;
    public float currentExp;
    

    public float CurrentExp
    {
        get
        {
            return currentExp;
        }
        set
        {
            //Clamps the current value between 0 and max
            this.currentExp = Mathf.Clamp(value, 0, MaxExp  );

            //Updates the bar
            bar.Value = currentExp;

        }
    }
    public float MaxExp
    {
        get
        {
            return maxExp;
        }
        set
        {
            //Updates the bar's max value
            bar.MaxExpValue = value;

            //Sets the max value
            this.maxExp = value;
        }
    }

    
    public void Initialize()
    {      

        //Updates the bar
        this.MaxExp = maxExp;
        this.CurrentExp = currentExp;


        this.CurrentLevel = currentLevel;


        this.MaxRage = maxRage;
        this.CurrentRage = currentRage;


        
 
    }





    public int currentLevel;
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
    
        }
        set
        {
            //Clamps the current value between 0 and max
            this.currentLevel = Mathf.Clamp(value, 0, 200);

            //Updates the bar
            bar.Level = currentLevel;

        }
    }


    

        


    [SerializeField]
    private Bar_Rage_Scr rage_bar;  
    public float currentRage = 0;
    public float CurrentRage
    {
        get
        {

            return currentRage; 
        }
        set
        {
            //Clamps the current value between 0 and max
            this.currentRage = Mathf.Clamp(value, 0, MaxRage);

            //Updates the bar
            rage_bar.Value = currentRage;

        }
    }


    [SerializeField]
    private float maxRage;

    public float MaxRage
    {
        get
        {
            return maxRage;
        }
        set
        {
            //Updates the ba.r's max value
            rage_bar.MaxRageValue = value;

            //Sets the max value
            this.maxRage = value;
        }

    }




    [SerializeField]
    public bool rageDone;
    public bool RageDone
    {
        get
        {
            if(rage_bar.rage_start)
                return true;
            else if(!rage_bar.rage_start)
                return false;
            else
            return false;

        }

        set
        {
          //   rageDone=value;
        }
    }






 



}

*/
[Serializable]

class EnemyStat
{
    
    /// 이건 경험치 STAT----------------------------
    [SerializeField]
    private Bar_HP_Enemy bar;

    [SerializeField]
    private float maxHp;
    public float currentHp;
    

    public void Initialize()
    {      
        //Updates the bar
        this.MaxHp = maxHp;
        this.CurrentHp = currentHp;       
 
    }
    public float CurrentHp
    {
        get
        {
            return currentHp;
        }
        set
        {
            //Clamps the current value between 0 and max
            this.currentHp = Mathf.Clamp(value, 0, MaxHp);

            //Updates the bar
            bar.Value = currentHp;

        }
    }
    public float MaxHp
    {
        get
        {
            return maxHp;
        }
        set
        {
            //Updates the bar's max value
            bar.MaxHpValue = value;

            //Sets the max value
            this.maxHp = value;
        }
    }

    
}
