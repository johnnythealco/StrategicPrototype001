using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceTypeSelect : MonoBehaviour
{
	public ResourceListDisplay InuptsList;
	public ResourceListDisplay OutputsList;


	List<ResourceType> availableResources = new List<ResourceType> ();
	List<ResourceType> selectedResources = new List<ResourceType> ();

	public delegate void ResourceTypeListDelegate (List<ResourceType> _resourceTypes);

	public event ResourceTypeListDelegate onSelect;

	public void Prime (List<ResourceType> _availableResources)
	{
		availableResources.AddRange (_availableResources);
		InuptsList.Prime (availableResources);
		InuptsList.onResourceTypeClick += InuptsListListItemClick;
		OutputsList.onResourceTypeClick += OutputsListListItemClick;
	}


	void Select ()
	{
		if (onSelect != null)
			onSelect.Invoke (selectedResources);
	}

	void OnDestroy ()
	{
		InuptsList.onResourceTypeClick -= InuptsListListItemClick;
		OutputsList.onResourceTypeClick -= OutputsListListItemClick;
	}

	void OutputsListListItemClick (ResourceType _resource)
	{
		selectedResources.Remove (_resource);
		availableResources.Add (_resource);
		InuptsList.Prime (availableResources);
		OutputsList.Prime (selectedResources);
	}

	void InuptsListListItemClick (ResourceType _resource)
	{
		Debug.Log ("List item Clicked: " + _resource.name);
		availableResources.Remove (_resource);
		selectedResources.Add (_resource);
		InuptsList.Prime (availableResources);
		OutputsList.Prime (selectedResources);


	}

	//	public List<Resource> SelectResource ()
	//	{
	//
	//		var resourceSelection = new List<Resource> ();
	//
	//		foreach (var resourceType in selectedResources)
	//		{
	//			var resource = new Resource (resourceType.name, 0);
	//			resourceSelection.Add (resource);
	//		}
	//		return resourceSelection;
	//	}

	public void EndSelection ()
	{
		Select ();
		Destroy (gameObject);
	}

}
