using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveUpDown : MonoBehaviour {

bool k =false;

void Start()
{

this.GetComponent<Rigidbody2D>().velocity = new Vector3 (this.GetComponent<Rigidbody2D>().velocity.x , UDvelocity);
	MovUD();
}

[SerializeField]
float UDvelocity=0.4f;


void MovUD()
{
	if(this.GetComponent<Rigidbody2D>()!=null){
	this.GetComponent<Rigidbody2D>().velocity = new Vector3 (this.GetComponent<Rigidbody2D>().velocity.x , -this.GetComponent<Rigidbody2D>().velocity.y);
	Invoke("MovUD",1);}
}



}