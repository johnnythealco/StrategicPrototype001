using UnityEngine;
using System.Collections;

public class JKTesting : MonoBehaviour
{
	public Register register;
	// Use this for initialization
	void Start ()
	{
		var resources = register.resourceRegister.MasterList;
		var structures = register.structureRegister.MasterList;

		Resources testResources = new Resources ();

		foreach (var item in resources)
		{
			testResources.Add (item, 100);
			
		}

		Debug.Log (testResources.ToString ());

	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
