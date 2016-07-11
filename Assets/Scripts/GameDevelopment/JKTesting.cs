using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JKTesting : MonoBehaviour
{
	public ResourceTypeSelect resourceTypeSelect;
	public List<Resource> resources = new List<Resource> ();
	public ResourceListDisplay resourcesDisplay;

	void Start ()
	{
		resourcesDisplay.Prime (resources);
		resourcesDisplay.onResourceUpdate += ResourcesDisplay_onResourceUpdate;
	}

	void ResourcesDisplay_onResourceUpdate (Resource _resource)
	{

		foreach (var item in resources)
		{
			if (item.resource == _resource.resource)
			{
				item.value = _resource.value;
			} 
		}

	}


	public void ShowResourceSelector ()
	{
		var allResources = Gamesetup.Manager.AllResources; 
		var TypeSelect = (ResourceTypeSelect)Instantiate (resourceTypeSelect);
		TypeSelect.Prime (allResources);
		TypeSelect.onSelect += OnTypeSelect;
	}

	void OnTypeSelect (List<ResourceType> _resourceTypes)
	{
		foreach (var resourceType in _resourceTypes)
		{
			var resource = new Resource (resourceType.name, 0);
			resources.Add (resource);
		}
		resourcesDisplay.Prime (resources);
	}


}
