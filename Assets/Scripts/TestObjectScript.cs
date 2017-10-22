using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

	public Transform targetMarker;
	Ray ray;
	RaycastHit hitInfo;
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
 			if(Physics.Raycast(ray.origin,ray.direction, out hitInfo ))
			{
 					Vector3 targetPosition =hitInfo.point;
					targetMarker.position = targetPosition;
			}
		}



				
	}




/*
 적 오브젝트의 플레이어 오브젝트 위치파악 
 1) 위치 파악
 2) 회전
 3) 정지 공격 or 이동
*/
	public Transform targetTransform;

	[SerializeField]
	float revealDistance;
	void StopPos()
	{

		if( Vector3.Distance(transform.position, targetTransform.position) < revealDistance)
		{
			return;

		}

	}

/*
돌아다닐 위치 얻기
GetNextPosition();
*/

	 
}


