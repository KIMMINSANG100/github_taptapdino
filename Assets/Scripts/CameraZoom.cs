
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    public float perspectiveZoomSpeed = 0.1f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.1f;        // The rate of change of the orthographic size in orthographic mode.

[SerializeField]
float xMin;

[SerializeField]
float xMax;

[SerializeField]
float yMin;

[SerializeField]
float yMax;


[SerializeField]
Vector3 thisZpos;

Vector3 prevPos;

Vector2 targetPosition;

float touchingTime;
[SerializeField]
bool cameraZoomOn=false;

[SerializeField]
private float x;


[SerializeField]
private float y;


void Start()
{
    prevPos = this.transform.position;
    StartCoroutine("cameraToZeroStart");
    transform.position =   new Vector3 (21.5f,1.19f);
}
    void Update()
    {
        if(shakecam==true && y ==0)
        {
            StartCoroutine("ShakeCam");
            y=1;
        }
 
        else
        StopCoroutine("ShakeCam");

        check_Double_Tap();


        //if(Input.GetMouseButtonDown(0) && tapCount==0)

 

       // if(Input.GetMouseButton(0))
     //   touchingTime += Time.deltaTime;

    
     if( tapCount ==0&& cameraZoomOn==true)
    {            
   //          transform.position = prevPos;
             

            if (Input.touchCount == 2)
            {

          //  touched=2;
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            

         
         //this.transform.position += ( -  Camera.main.ScreenToWorldPoint(touchZero.position) + (Vector3) targetPosition ) + thisZpos;
 

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;


  //.  if( this. transform.position != (Vector3) targetPosition_Touch )
     //      this.transform.position = ( prevPos - (Vector3) targetPosition_Touch ) *  deltaMagnitudeDiff *0.5f;


         //  


            // If the GetComponent<Camera>(); is orthographic...
          
          
          
          
            if (GetComponent<Camera>().orthographic)
            {

                // ... change the orthographic size based on the change in distance between the touches.
                GetComponent<Camera>().orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                // Make sure the orthographic size never drops below zero.
                GetComponent<Camera>().orthographicSize = Mathf.Max(GetComponent<Camera>().orthographicSize, 0.1f);

               if( GetComponent<Camera>().orthographicSize  >=11)
                    {
                        GetComponent<Camera>().orthographicSize =11;
                    }

                else if( GetComponent<Camera>().orthographicSize <=3)
                    {
                        GetComponent<Camera>().orthographicSize  =3;
                    }

                    xMin =(-14.3f)- GetComponent<Camera>().orthographicSize/11*(-14.3f);
                    xMax = (52.5f)- GetComponent<Camera>().orthographicSize/11*(14.3f);        
              

                    yMin =(-8f)- GetComponent<Camera>().orthographicSize/11*(-8f);
                    yMax = (8f)- GetComponent<Camera>().orthographicSize/11*(8f);        
              
                    CameraRange();
              }


            
            
            else
                {
                    // Otherwise change the field of view based on the change in distance between the touches.
                    GetComponent<Camera>().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                    // Clamp the field of view to make sure it's between 0 and 180.
                    GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 0.1f, 179.9f);
                    if( GetComponent<Camera>().fieldOfView  >=11)
                    {
                        GetComponent<Camera>().fieldOfView =11;
                    }

                    else if( GetComponent<Camera>().fieldOfView <=3)
                    {
                        GetComponent<Camera>().fieldOfView  =3;
                    }
                 
                 

                }
            }


                    xMin =(-14.4f)- GetComponent<Camera>().orthographicSize/11*(-14.3f);
                    xMax = (52.5f)- GetComponent<Camera>().orthographicSize/11*(14.3f);        



                    yMin =(-8f)- GetComponent<Camera>().orthographicSize/11*(-8f);
                    yMax = (8f)- GetComponent<Camera>().orthographicSize/11*(8f);        

    }
    

                    xMin =(-14.4f)- GetComponent<Camera>().orthographicSize/11*(-14.3f);
                    xMax = (52.5f)- GetComponent<Camera>().orthographicSize/11*(14.3f);        



                    yMin =(-8f)- GetComponent<Camera>().orthographicSize/11*(-8f);
                    yMax = (8f)- GetComponent<Camera>().orthographicSize/11*(8f);        

            
/*

            if(Input.touchCount==1 )
            {
           
           this.transform.position = ( -  Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3) prevPos *2 ) + thisZpos;
        

  

            prevPos = transform.position;
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
        
            }
        



        
        // If there are two touches on the device...
   
 
    }

    if(Input.touchCount==0)
    {
        prevPos =transform.position;
        targetPosition = new Vector3(0,0,0);
    }
 */
           CameraRange(); 
			
        	this.transform.position = new Vector3 ( Mathf.Clamp( this.transform.position.x, xMin, xMax),Mathf.Clamp( this.transform.position.y, yMin, yMax+0.6f), this.transform.position.z );


    }


    void CameraRange()
    {
        if(!(this.transform.position.x > xMin && this.transform.position.x < xMax
        && this.transform.position.y > yMin && this.transform.position.y < yMax))           

            {
                if(this.transform.position.x <= xMin )
				this.transform.position = new Vector3( xMin+0.001f, this.transform.position.y+0.6f)+ thisZpos;
        

           		else if(this.transform.position.x >= xMax )
				this.transform.position = new Vector3( xMax-0.001f, this.transform.position.y+0.6f)+ thisZpos;


            	else if(this.transform.position.y <= yMin )
				this.transform.position = new Vector3( this.transform.position.x, yMin+0.001f+0.6f)+ thisZpos;


            	else if(this.transform.position.y >= yMax )
				this.transform.position = new Vector3( this.transform.position.x, yMax-0.001f+0.6f)+ thisZpos;

            }
 



    }


int tapCount=0;
float doubleTapTimer;

[SerializeField]
float doubleTapInterval =0.2f;
    void check_Double_Tap()
    {
         if (Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Began)
         {
             tapCount++;
         }
         if (tapCount > 0)
         {
             doubleTapTimer += Time.deltaTime;
         }
         if (tapCount >= 2)
         {
             //What you want to do
             doubleTapTimer = 0.0f; 
             tapCount = 0;
         }
         if (doubleTapTimer > doubleTapInterval)    
         {
             doubleTapTimer = 0f;
             tapCount = 0;
         
         }
    }


public bool shakecam;
    IEnumerator ShakeCam()
    {
        yield return new WaitForSeconds(0.05f);
            transform.position += new Vector3 (0.2f, 0 ,0 );

        yield return new WaitForSeconds(0.05f);
            transform.position += new Vector3 (-0.2f, 0 ,0 );

        yield return new WaitForSeconds(0.05f);
            transform.position += new Vector3 (0.14f, 0 ,0 );

        yield return new WaitForSeconds(0.05f);
            transform.position += new Vector3 (-0.14f, 0 ,0 );
        yield return new WaitForSeconds(0.05f);
            transform.position += new Vector3 (0.08f, 0 ,0 );

        yield return new WaitForSeconds(0.05f);
            transform.position += new Vector3 (-0.08f, 0 ,0 );
        
            shakecam=false;
            y=0;
        StopCoroutine("ShakeCam");
        
    }



    IEnumerator MoveCam()
    {
        yield return new WaitForSeconds(0.05f);
            transform.position += new Vector3 (0.15f, 0 ,0 );

        yield return new WaitForSeconds(0.05f);
            transform.position += new Vector3 (-0.15f, 0 ,0 );

        yield return new WaitForSeconds(0.05f);
            transform.position += new Vector3 (0.1f, 0 ,0 );

        yield return new WaitForSeconds(0.05f);
            transform.position += new Vector3 (-0.1f, 0 ,0 );
        yield return new WaitForSeconds(0.05f);
            transform.position += new Vector3 (0.06f, 0 ,0 );

        yield return new WaitForSeconds(0.05f);
            transform.position += new Vector3 (-0.06f, 0 ,0 );
        
            shakecam=false;
            y=0;
        StopCoroutine("MoveCam");
        
    }

    	IEnumerator cameraToZeroStart()
        {
            yield return new WaitForSeconds(2);
            StartCoroutine("cameraToZero");

        }

    	IEnumerator cameraToZero()
	{
		yield return new  WaitForSeconds(0.01f);
        this.transform.position-=new Vector3(0.5f,0,0);
        
        if(transform.position.x>8.26f)
        StartCoroutine("cameraToZero");

 		
        if(transform.position.x<8.26f)
        StopCoroutine("cameraToZero");

	}


}