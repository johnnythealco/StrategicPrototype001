using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceListBuilder : MonoBehaviour
{

	public ResourceTypeSelect resourceTypeSelect;
	public ResourceListDisplay resourcesDisplay;

	List<Resource> resources = new List<Resource> ();
	List<ResourceType> resourceTypes = new List<ResourceType> ();



	void Prime (List<ResourceType> _ResourceTypes)
	{
		resourceTypes.AddRange (_ResourceTypes);
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


	public void AddResourceType ()
	{
		var TypeSelect = (ResourceTypeSelect)Instantiate (resourceTypeSelect);
		TypeSelect.Prime (resourceTypes);
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
