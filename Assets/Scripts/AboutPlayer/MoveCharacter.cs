using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
   Vector3 distance;

   void Update () 
   {
      if(Input.GetMouseButtonDown(0))
      {
         Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         pos = new Vector3(pos.x, pos.y);
         distance = pos - transform.position;
      }
      else if(Input.GetMouseButton(0))
      {
         Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);	
         transform.position = new Vector3(pos.x, pos.y) - distance;
      }

      Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
          Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
      transform.position = new Vector3(
         Mathf.Clamp(transform.position.x, min.x, max.x),
         Mathf.Clamp(transform.position.y, min.y, max.y),
         transform.position.z);
         
   }

}
