using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ResourceDisplay : MonoBehaviour
{

	protected ResourceType resourceType;
	protected Resource resource;
	public Text displayname;
	public Image icon;
	public Text Category;
	public Text baseprice;
	public Text prosperity;
	public Text health;
	public Text quantity;

	public delegate void ResourceTypeDisplayDelegate (ResourceType _resource);

	public event ResourceTypeDisplayDelegate onClickType;

	public delegate void ResourceDisplayDelegate (Resource _resource);

	public event ResourceDisplayDelegate onClickResource;

	public void Prime (ResourceType _resourceType)
	{
		if (_resourceType == null || _resourceType.name == null)
			return;

		resourceType = _resourceType;

		if (displayname != null)
			displayname.text = resourceType.name;
		if (icon != null)
			icon.sprite = resourceType.icon;
		if (Category != null)
			Category.text = resourceType.Category.ToString (); 		
		if (baseprice != null)
			baseprice.text = resourceType.baseprice.ToString (); 
		if (prosperity != null)
			prosperity.text = resourceType.prosperity.ToString (); 
		if (health != null)
			health.text = resourceType.health.ToString (); 

	}

	public void Prime (Resource _resource)
	{
		if (_resource == null || _resource.resource == null)
			return;

		resource = _resource;	
		resourceType = _resource.type;

		Prime (resourceType);
	
		if (quantity != null)
			quantity.text = resource.value.ToString (); 
		
	
	
	}


	public void Click ()
	{
		if (onClickType != null)
			onClickType.Invoke (resourceType);

		if (onClickResource != null)
			onClickResource.Invoke (resource);
	
	}



}
