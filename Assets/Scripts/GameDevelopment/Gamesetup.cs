using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gamesetup : MonoBehaviour
{
	public Register register;


	public static Gamesetup Manager = null;

	public List<ResourceType> AllResources{ get { return register.AllResources; } }

	public List<ResourceType> StrategicResources{ get { return register.StrategicResources; } }

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
