using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnsNeedUpdate : MonoBehaviour {

    [SerializeField]
    Button InputField;
	// Use this for initialization
	void Start () {
		
        StartCoroutine("CoroutUpdate");
	}
	    int clicknumber = 0;

	// Update is called once per frame

    IEnumerator CoroutUpdate()
    {

        while(true){
        if (Input.GetMouseButton(0))
        {
            clicknumber++;

            if (this.name == "clickMotion(Clone)" && clicknumber == 8)
            {

                Destroy(this.gameObject);
            }
        }



            if (this.name == "MeatBtn")
            {
                transform.Find("number").GetComponent<Text>().text = ControlTowerScript.controlTowerScript.meat.ToString();

                if (ControlTowerScript.controlTowerScript.meat <= 0)
                {
                    GetComponent<Button>().enabled = false;
                }

                else
                {
                    GetComponent<Button>().enabled = true;
                }
            }


            if (this.name == "PotionBtn")
            {

                transform.Find("number").GetComponent<Text>().text = ControlTowerScript.controlTowerScript.potion.ToString();


                if (ControlTowerScript.controlTowerScript.potion <= 0)
                {
                    GetComponent<Button>().enabled = false;
                }

                else
                {
                    GetComponent<Button>().enabled = true;
                }
            }

            if (this.name == "HurbBtn")
            {

                transform.Find("number").GetComponent<Text>().text = ControlTowerScript.controlTowerScript.expHurb.ToString();

                if (ControlTowerScript.controlTowerScript.expHurb <= 0)
                {
                    GetComponent<Button>().enabled = false;
                }

                else
                {
                    GetComponent<Button>().enabled = true;
                }
            }

        yield return new WaitForSeconds(0.2f);

                    
        }
    }    
    }
     