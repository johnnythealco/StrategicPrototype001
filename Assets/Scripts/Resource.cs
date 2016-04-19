using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum ResourceType
{
	Critical = 0,
	Strategic = 1,
	BasicFood = 2,
	LuxuryFood = 3,
	LuxuryMinerals = 4,
	BasicGoods = 5,
	LuxuryGoods = 6

}

[System.Serializable]
public class Resource : System.Object
{
	public short ID;
	public ResourceType Type;
	public string name;
	public string description;
}

public struct ResourceCount
{
	public Resource resource;
	public int number;

	public ResourceCount (Resource _resource, int _number)
	{
		this.resource = _resource;
		this.number = _number;
	}
}

[System.Serializable]
public class ResourceQuantity : System.Object
{
	public List<ResourceCount> Resources = new List<ResourceCount> ();


	/// <summary>
	/// Add the specified resource and quantity.
	/// </summary>
	/// <param name="resource">Resource.</param>
	/// <param name="quantity">Quantity.</param>
	public void Add (Resource _resource, int quantity)
	{

		foreach (var listItem in Resources)
		{
			if (listItem.resource == _resource)
			{
				var number = listItem.number;
				number = number + quantity;
				return;
			} 
		}

		Resources.Add (new ResourceCount (_resource, quantity));


	}

	/// <summary>
	/// Add or subtract the specified Resource Quantity.
	/// </summary>
	/// <param name="resourceQuantity">Resource quantity.</param>
	public void Add (ResourceQuantity resourceQuantity)
	{
		foreach (var newitem in resourceQuantity.Resources)
		{
			var newResource = newitem.resource;
			var newquantity = newitem.number;

			foreach (var existinrResource in Resources)
			{
				if (existinrResource.resource == newResource)
				{
					var number = existinrResource.number;
					number = number + newquantity;
				} else
				{
					Resources.Add (new ResourceCount (newResource, newquantity));
				}
	
	
			}
	
		}


	}
}



