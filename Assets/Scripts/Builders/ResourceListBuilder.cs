using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ResourceListBuilder : MonoBehaviour
{
	public Register register;
	public ResourceTypeSelect resourceTypeSelect;
	public Transform buttonControls;
	public Transform target;
	public ResourceDisplay resourceTypeAddDisplay;
	public ResourceDisplay resourceTypeDeleteDisplay;

	ResourceTypeSelect TypeSelect;
	List<ResourceDisplay> resourceDisplayList = new List<ResourceDisplay> ();

	List<Resource> resources;
	List<ResourceType> resourceTypes = new List<ResourceType> ();

	#region Delegates & Events

	public delegate void ResourceListBuilderDelegate (List<Resource> _resources);

	public event ResourceListBuilderDelegate onResourceUpdate;

	public delegate void ResourceListDisplayDelegate (Resource _resource);

	public event ResourceListDisplayDelegate onResourceClick;


	#endregion

	#region Event Callers


	void OnResourceClick (Resource _resource)
	{
		if (onResourceClick != null)
			onResourceClick.Invoke (_resource);
	}

	void OnResourceUpdate (Resource _resource)
	{

		foreach (var item in resources)
		{
			if (item.resource == _resource.resource)
			{
				item.value = _resource.value;
			} 
		}
		if (onResourceUpdate != null)
			onResourceUpdate.Invoke (resources);

	}

	void OnTypeSelect (List<ResourceType> _resourceTypes)
	{
		foreach (var resourceType in _resourceTypes)
		{
			var resource = new Resource (resourceType.name, 0);
			resources.Add (resource);
		}
		Prime (resources);
	}



	#endregion



	void SetResourceTypes (List<ResourceType> _ResourceTypes)
	{
		resourceTypes.Clear ();
		resourceTypes.AddRange (_ResourceTypes);
	}

	public void Prime (List<Resource> _resources)
	{
		clearList ();
		resources = _resources;
		foreach (var resource in resources)
		{
			ResourceDisplay listItem = (ResourceDisplay)Instantiate (resourceTypeAddDisplay);
			listItem.transform.SetParent (target, false);
			listItem.Prime (resource);
			listItem.gameObject.tag = "ResourceDisplay";
			listItem.onClickResource += OnResourceClick;
			listItem.onUpdateResource += OnResourceUpdate;
			resourceDisplayList.Add (listItem);		
		}
			
		buttonControls.SetAsLastSibling ();
		if (onResourceUpdate != null)
			onResourceUpdate.Invoke (resources);
	}


	public void PrimeForDelete ()
	{
		clearList ();
		foreach (var resource in resources)
		{
			ResourceDisplay listItem = (ResourceDisplay)Instantiate (resourceTypeDeleteDisplay);
			listItem.transform.SetParent (target, false);
			listItem.Prime (resource);
			listItem.gameObject.tag = "ResourceDisplay";
			listItem.onDeleteResource += onDeleteResource;
			resourceDisplayList.Add (listItem);		
		}

		buttonControls.SetAsLastSibling ();
		if (onResourceUpdate != null)
			onResourceUpdate.Invoke (resources);
	}

	void onDeleteResource (Resource _resource)
	{
		resources.Remove (_resource);
		Prime (resources);
		if (onResourceUpdate != null)
			onResourceUpdate.Invoke (resources);
		
	}


	public void AddResourceType ()
	{
		TypeSelect = (ResourceTypeSelect)Instantiate (resourceTypeSelect);
		List<ResourceType> _resourceTypes = new List<ResourceType> (resourceTypes);
		foreach (var item in resources)
		{
			_resourceTypes.Remove (item.type);
		}

		TypeSelect.Prime (_resourceTypes);
		TypeSelect.onSelect += OnTypeSelect;
	}

	void Awake ()
	{
		resourceTypes.AddRange (register.AllResources);
	}

	void clearList ()
	{
		foreach (var item in resourceDisplayList)
		{
			item.onClickResource -= OnResourceClick;
		}

		for (int i = 0; i < target.childCount; i++)
		{
			if (target.GetChild (i).gameObject.tag == "ResourceDisplay")
			{
				Destroy (target.GetChild (i).gameObject);
			}
		}

	}

	void OnDestroy ()
	{
		foreach (var resource in resourceDisplayList)
		{
			resource.onClickResource -= OnResourceClick;
			resource.onUpdateResource -= OnResourceUpdate;

		}
	}

}
