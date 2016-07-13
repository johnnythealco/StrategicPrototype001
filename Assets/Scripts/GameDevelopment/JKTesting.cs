using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JKTesting : MonoBehaviour
{
	public ResourceListBuilder resourceListBuilder;
	public List<Resource> resources;

	void Start ()
	{
		resources = new List<Resource> ();
		resourceListBuilder.Prime (resources);
		resourceListBuilder.onResourceUpdate += onResourceUpdate;
	}

	void onResourceUpdate (List<Resource> _resources)
	{
		resources = _resources;
	}


}
