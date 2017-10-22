using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region 현재 지원되지 않는 코드
/// <summary>
/// 제네릭형 모노비헤비어 상속 클래스는 유니티에서 AddComponent를 지원하지 않음
/// </summary>
//public class DestroyInvoker<T> : MonoBehaviour where T : MonoBehaviour
//{
//	public event Action<T> _eventDestroy;
//
//	virtual public void Init() { }
//
//	private void OnDestroy()
//	{
//		_eventDestroy?.Invoke( GetComponent<T>() );
//	}
//
//	public void Release()
//	{
//		Pool<T>.Destroy( gameObject );
//	}
//}
#endregion

public class DestroyInvoker : MonoBehaviour
{
	public event Action<GameObject> _eventDestroy;

	virtual public void Init() { }

	private void OnDestroy()
	{
		if( null != _eventDestroy )
		{
			_eventDestroy.Invoke( gameObject );
		}
	}
}