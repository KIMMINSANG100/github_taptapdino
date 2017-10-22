using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public static class Pool
{
	/// <summary>
	/// 객체를 생성하고 메모리풀로 관리
	/// </summary>
	public static T Instantiate<T>( T target )
		where T : MonoBehaviour
	{
		return Pool<T>.Instantiate( target );
	}

	/// <summary>
	/// 메모리풀에서 관리하는 객체를 비활성 처리
	/// </summary>
	public static void Release<T>( T target )
		where T : MonoBehaviour
	{
		Pool<T>.Release( target );
	}
}

/// <summary>
/// 관리를 할 컬렉션 데이터
/// </summary>
/// <typeparam name="T"></typeparam>
public static class Pool<T>
	where T : MonoBehaviour
{
	private static List<T> _activeList = new List<T>();
	private static List<T> _inactiveList = new List<T>();

	public static T Instantiate( T target )
	{
		T instance = Recycle( () => UnityEngine.Object.Instantiate( target ) );
		instance.gameObject.SetActive( true );

		if( instance is IPoolElement )
		{
			( (IPoolElement)instance ).Init();
		}

		return instance;
	}

	public static void Release( GameObject target )
	{
		if( null == target ) return;

		Release( target.GetComponent<T>() );
	}

	public static void Release( T target )
	{
		if( null == target ) return;

		T instance = _activeList.FirstOrDefault( x => x == target );
		if( null != instance )
		{
			_activeList.Remove( instance );
		}
		else
		{
			instance = target;
			instance.name += "[Pool]";
		}
		_inactiveList.Add( instance );

		instance.gameObject.SetActive( false );
	}

	public static void Clear( bool bForceAll = false )
	{
		for( int i = 0, max = _inactiveList.Count; i < max; i++ )
		{
			GameObject.Destroy( _inactiveList[i].gameObject );
		}
		_inactiveList.Clear();

		if( bForceAll )
		{
			for( int i = 0, max = _activeList.Count; i < max; i++ )
			{
				GameObject.Destroy( _activeList[i].gameObject );
			}
			_activeList.Clear();
		}
	}

	private static T Recycle( Func<T> instantiateInstance )
	{
		T instance = default( T );
		if( _inactiveList.Count <= 0 )
		{
			//Debug.LogFormat( "Instantiate {0}", target.name );
			if( null != instantiateInstance )
			{
				instance = instantiateInstance.Invoke();
			}
			instance.name += "[Pool]";
			AddDestroyEvent( instance );
			_activeList.Add( instance );
		}
		else
		{
			instance = _inactiveList[0];
			_activeList.Add( _inactiveList[0] );
			_inactiveList.RemoveAt( 0 );
		}
		return instance;
	}

	private static void AddDestroyEvent( T instance )
	{
		var invoker = instance.GetComponent<DestroyInvoker>();
		if( null == invoker )
		{
			invoker = instance.gameObject.AddComponent<DestroyInvoker>();
		}
		invoker._eventDestroy += OnDestroy;
	}

	private static void Destroy( T target )
	{
		GameObject.Destroy( target );
		ExceptElement( target );
	}

	private static void OnDestroy( GameObject target )
	{
		ExceptElement( target.GetComponent<T>() );
	}

	private static void ExceptElement( T target )
	{
		if( null == target ) return;

		//Debug.LogFormat( "OnDestroy {0}", target.name );
		_activeList.Remove( target );
		_inactiveList.Remove( target );
	}
}