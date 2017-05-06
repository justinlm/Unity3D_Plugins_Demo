using UnityEngine;

/// <summary>
/// 
/// </summary>
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	/// <summary>
	/// 
	/// </summary>
	private static T _Instance;

	private static bool _WasDestryed;

	/// <summary>
	/// singleton property
	/// </summary>
	public static T Instance
	{
	    get
	    {
	        if (_WasDestryed)
	            return null;

	        if (_Instance == null)
	        {
	            _Instance = GameObject.FindObjectOfType(typeof(T)) as T;

	            if (_Instance == null)
	            {
	                GameObject gameObject = new GameObject(typeof(T).Name);
	                GameObject.DontDestroyOnLoad(gameObject);

	                _Instance = gameObject.AddComponent(typeof(T)) as T;
	            }
	        }

	        return _Instance;
	    }
	}

	/// <summary>
	/// 
	/// </summary>
	protected virtual void OnDestroy()
	{
	    if (_Instance)
	        Destroy(_Instance);

	    _Instance = null;
	    _WasDestryed = true;
	}
}