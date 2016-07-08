using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ResourceListDisplay : MonoBehaviour
{

	public Transform target;
	public ResourceDisplay resourceDisplay;

	List<ResourceDisplay> resourceList = new List<ResourceDisplay> ();

	public delegate void ResourceTypeListDisplayDelegate (ResourceType _resourceType);

	public event ResourceTypeListDisplayDelegate onResourceTypeClick;

	public delegate void ResourceListDisplayDelegate (Resource _resource);

	public event ResourceListDisplayDelegate onResourceClick;

	public void Prime (List<ResourceType> _resourceTypes)
	{
		clearList ();

		foreach (var resource in _resourceTypes)
		{
			ResourceDisplay listItem = (ResourceDisplay)Instantiate (resourceDisplay);
			listItem.transform.SetParent (target, false);
			listItem.Prime (resource);
			listItem.onClickType += OnTypeClick;

			resourceList.Add (listItem);		
			
		}
	}

	public void Prime (List<Resource> _resources)
	{
		clearList ();

		foreach (var resource in _resources)
		{
			ResourceDisplay listItem = (ResourceDisplay)Instantiate (resourceDisplay);
			listItem.transform.SetParent (target, false);
			listItem.Prime (resource);
			listItem.onClickResource += OnResourceClick;

			resourceList.Add (listItem);		

		}
	}


	void OnDestroy ()
	{
		foreach (var resource in resourceList)
		{
			//Unsubscribe form events

			resource.onClickType -= OnTypeClick;


			resource.onClickResource -= OnResourceClick;
			

		}
	}

	void OnTypeClick (ResourceType _resourceType)
	{
		if (onResourceTypeClick != null)
			onResourceTypeClick.Invoke (_resourceType);
	}

	void OnResourceClick (Resource _resource)
	{
		if (onResourceClick != null)
			onResourceClick.Invoke (_resource);
	}

	void clearList ()
	{
		foreach (var item in resourceList)
		{
			item.onClickType -= OnTypeClick;
			item.onClickResource -= OnResourceClick;
		}

		for (int i = 0; i < target.childCount; i++)
		{
			Destroy (target.GetChild (i).gameObject);
		}
		
	}



}
