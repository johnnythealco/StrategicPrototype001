using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Register : ScriptableObject
{
	public ResourceRegister resourceRegister;
	public StructureRegister structureRegister;


	public static Resources getCriticalResources ()
	{
		var result = new Resources ();

		foreach (var item in this.resourceRegister.MasterList)
		{
			if (item.Category == ResourceCategory.Critical)
			{
				result.Add (item, 0);
			}
		}
	}

}

public class ResourceRegister : ScriptableObject
{
	public List<ResourceType> MasterList = new List<ResourceType> ();

}

public class StructureRegister : ScriptableObject
{
	public List<Structure> MasterList = new List<Structure> ();
}

public class CommodityRegister : ScriptableObject
{
	public List<CommodityType> MasterList = new List<CommodityType> ();
}

