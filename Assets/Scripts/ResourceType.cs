using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public enum ResourceCategory
{
	Critical = 0,
	Strategic = 1,
	Comodity = 2,
	BasicGoods = 3,
	LuxuryGoods = 4

}

[System.Serializable]
public class ResourceType : System.Object
{
	public string name;
	public Sprite icon;
	public ResourceCategory Category;
}

[System.Serializable]
public class Resource
{
	public ResourceType resource;
	public int value;

	public Resource (ResourceType _resource, int _value)
	{
		this.resource = _resource;
		this.value = _value;
	}


	public override string ToString ()
	{
		var _name = resource.name + ": ";

		var _value = value.ToString ();

		return string.Format (_name + _value);
	}
}

[System.Serializable]
public class Resources : System.Object
{
	public List<Resource> list = new List<Resource> ();

	/// <summary>
	/// Initializes a new instance of the <see cref="ResourceQuantity"/> class.
	/// </summary>
	/// <param name="_resources">Resources.</param>
	public Resources (List<Resource> _resources)
	{
		this.list = _resources;
	}

	public Resources ()
	{
		this.list = new List<Resource> ();
	}



	/// <summary>
	/// Add the specified resource and quantity.
	/// </summary>
	/// <param name="resource">Resource.</param>
	/// <param name="quantity">Quantity.</param>
	public void Add (ResourceType _resource, int quantity)
	{

		foreach (var listItem in list)
		{
			if (listItem.resource == _resource)
			{
				var number = listItem.value;
				number = number + quantity;
				return;
			} 
		}

		list.Add (new Resource (_resource, quantity));


	}

	/// <summary>
	/// Add or subtract the specified Resource Quantity.
	/// </summary>
	/// <param name="resourceQuantity">Resource quantity.</param>
	public void Add (Resources _resources)
	{
		foreach (var newitem in _resources.list)
		{
			var newResource = newitem.resource;
			var newValue = newitem.value;

			foreach (var resource in this.list)
			{
				//If the resource is in the list update the value.
				if (resource.resource == newResource)
				{
					var value = resource.value;
					value = value + newValue;
				} 
				//If the resouce is not in the list add it.
				else
				{
					list.Add (new Resource (newResource, newValue));
				}
	
	
			}
	
		}


	}


	public override string ToString ()
	{
		string output = "";
		foreach (var item in list)
		{
			output = output + item.ToString () + System.Environment.NewLine;
		}
		return output;
	}



}



