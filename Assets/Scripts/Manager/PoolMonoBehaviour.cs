public interface IPoolElement
{
	/// <summary>
	/// 요소가 재활용 될 때 호출되는 함수
	/// </summary>
	void Init();
}

public abstract class PoolMonoBehaviour<T> : DestroyInvoker, IPoolElement
	where T : PoolMonoBehaviour<T>
{
	public override abstract void Init();

	/// <summary>
	/// 자원을 완전히 해제하지 않고 재활용 할 수 있도록 대기처리
	/// </summary>
	public void Release()
	{
		Pool<T>.Release( gameObject );
	}
}