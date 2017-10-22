using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
class EggStat
{
    

    
    public void Initialize()
    {      

        this.MaxTime = maxTime;
        this.CurrentTime = currentTime;

        
    }











    [SerializeField]
    private Bar_EggTimeScript time_bar;  
    public float currentTime = 0;

    public float CurrentTime
    {
        get
        {
            return currentTime;     
        }
        set
        {
            //Clamps the current value between 0 and max
            this.currentTime = Mathf.Clamp(value, 0, MaxTime);

            //Updates the bar
            time_bar.TimeValue= currentTime;

        }
    }

    

    [SerializeField]
    private float maxTime;

    public float MaxTime
    {
        get
        {
            return maxTime;
        }
        set
        {
            //Updates the ba.r's max value
            time_bar.MaxTimeValue = value;

            //Sets the max value
            this.maxTime = value;
        }

    }


[SerializeField]
private int currentNumber;
    public int NumberOfEgg
    {
        get
        {
            return currentNumber;
        }
        set
        {
            //Updates the ba.r's max value
            time_bar.numberOfMine = value;

            //Sets the max value
            this.currentNumber = value;
        }

    }



}

