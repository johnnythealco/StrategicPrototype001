using UnityEngine;
using System.Collections;

public class Gamesetup : MonoBehaviour
{

	public static Gamesetup Manager = null;

	void Awake ()
	{
		if (Manager == null)
		{
			Manager = this;

		} else if (Manager != this)
		{
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
			
	}

}
