using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Commodity : System.Object
{
	public CommodityType commodity;
	public int value;

	public Commodity (CommodityType _commodity, int _value)
	{
		this.commodity = _commodity;
		this.value = _value;
	}


	public override string ToString ()
	{
		var _name = commodity.name + ": ";

		var _value = value.ToString ();

		return string.Format (_name + _value);
	}
	
}

public enum CommodityCategory
{
	BasicGoods = 0,
	LuxuryGoods = 1
}


[System.Serializable]
public class CommodityType : System.Object
{
	public string name;
	public Sprite icon;
	public CommodityCategory Category;
	public int healthBonus;
	public int comfortBonus;
}


[System.Serializable]
public class Commodities : System.Object
{
	public List<Commodity> list = new List<Commodity> ();

	/// <summary>
	/// Initializes a new instance of the <see cref="CommodityQuantity"/> class.
	/// </summary>
	/// <param name="_commodities">Commodities.</param>
	public Commodities (List<Commodity> _commodities)
	{
		this.list = _commodities;
	}



	public Commodities ()
	{
		this.list = new List<Commodity> ();
	}



	/// <summary>
	/// Add the specified commodity and quantity.
	/// </summary>
	/// <param name="commodity">Commodity.</param>
	/// <param name="quantity">Quantity.</param>
	public void Add (CommodityType _commodity, int quantity)
	{

		foreach (var listItem in list)
		{
			if (listItem.commodity == _commodity)
			{
				var number = listItem.value;
				number = number + quantity;
				return;
			} 
		}

		list.Add (new Commodity (_commodity, quantity));


	}

	/// <summary>
	/// Add or subtract the specified Commodity Quantity.
	/// </summary>
	/// <param name="commodityQuantity">Commodity quantity.</param>
	public void Add (Commodities _commodities)
	{
		foreach (var newitem in _commodities.list)
		{
			var newCommodity = newitem.commodity;
			var newValue = newitem.value;

			foreach (var commodity in this.list)
			{
				//If the commodity is in the list update the value.
				if (commodity.commodity == newCommodity)
				{
					var value = commodity.value;
					value = value + newValue;
				} 
				//If the resouce is not in the list add it.
				else
				{
					list.Add (new Commodity (newCommodity, newValue));
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

