using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
class DinoStat
{

/*
이름
스프라이트이미지
레벨
진화정도

공격력

경험치
진화정도
*/


/// 이름
	/*
	public string dinoName;

	public string DinoName
	{
		get{ 			return dinoName; 	}

		set{ 			this.dinoName = value; }
	
	}


// 이건 레벨
    public int currentLevel;
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            this.currentLevel	 	= Mathf.Clamp(value, 0, 200);        //Clamps the current value between 0 and max
            expBar.Level			= currentLevel;         			  //Updates the bar
        }
    }

    public float currentEvolution;
    public float CurrentEvolution
    {
        get
        {
            return currentEvolution;
        }
        set
        {
			            this.currentEvolution	 = value;        //Clamps the current value between 0 and max

		
        }
    }

//이건 공격력

    public float currentAttackPower;
    public float CurrentAttackPower
    {
        get
        {
            return currentAttackPower;
        }
        set
        {
            this.currentAttackPower	 = value;        //Clamps the current value between 0 and max
         //   bar.Level			 = currentLevel;         			  //Updates the bar
        }
    }



    public float powerLevel;
    public float PowerLevel
    {
        get
        {
            return powerLevel;
        }
        set
        {
            this.powerLevel	 = value;
        }
    }


    public float dinosAdrenalineLv;
    public float DinosAdrenalineLv
    {
        get
        {
            return dinosAdrenalineLv;
        }
        set
        {
            this.dinosAdrenalineLv	 = value;
        }
    }



    public float criticalRateLv;
    public float CriticalRateLv
    {
        get
        {
            return criticalRateLv;
        }
        set
        {
            this.criticalRateLv	 = value;
        }
    }



    public float critPowerLv;
    public float CritPowerLv
    {
        get
        {
            return critPowerLv;
        }
        set
        {
            this.critPowerLv	 = value;
        }
    }



    public float autoLv;
    public float AutoLv
    {
        get
        {
            return autoLv;
        }
        set
        {
            this.autoLv	 = value;
        }
    }

	


/// 이건 경험치 ----------------------------
    [SerializeField]
    private BarScript expBar;

    [SerializeField]
    private float maxExp=20;
    public float currentExp;
    

    public float CurrentExp
    {
        get { 
            return currentExp;
        	}
        set{
			this.currentExp		= Mathf.Clamp(value, 0, MaxExp  );
            expBar.Value 		= currentExp;            //Updates the bar
        }
    }


    public float MaxExp
    {
        get{
            return maxExp;
        	}
        set
        {
            this.maxExp			 = value; //Sets the max value
                        expBar.MaxExpValue	 = value; //Updates the bar's max value

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
            this.currentRage = Mathf.Clamp(value, 0, MaxRage);
            rage_bar.Value	 = currentRage;
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
            rage_bar.MaxRageValue 	= value;
            this.maxRage 			= value;
        }
    }



//rage trigger
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
        }
    }






     public void Initialize()
    {      
        maxExp=20;
		this.DinoName 	= dinoName;
        //Updates the bar
        this.MaxExp 	= maxExp;
        this.CurrentExp = currentExp;

		this.CurrentAttackPower = currentAttackPower;
        this.currentLevel = 1;


        this.MaxRage	 = maxRage;
        this.CurrentRage = currentRage;



        this.CurrentEvolution   =   currentEvolution;
	
		this.PowerLevel			=	powerLevel 			;
		this.DinosAdrenalineLv  = 	dinosAdrenalineLv;
		this.CriticalRateLv 	= 	criticalRateLv ;
		this.CritPowerLv		=	critPowerLv;
        this.AutoLv             =   autoLv;
/*
이름
스프라이트이미지
레벨
진화정도
경험치
진화정도


        //currentAttackPower = 10;
        

        currentLevel=1;        
     	powerLevel=1;
   		dinosAdrenalineLv=1;
    	criticalRateLv=1;
	 	critPowerLv=1;
        autoLv =1;



        this.MaxRage = maxRage;
        this.CurrentRage = currentRage;

    }
*/



}

 