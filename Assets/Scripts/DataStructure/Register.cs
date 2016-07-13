using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Register : ScriptableObject
{
	public  ResourceTypeRegister resourceTypeRegister;
	public  StructureRegister structureRegister;

	public List<ResourceType> AllResources{ get { return resourceTypeRegister.MasterList; } }

	public List<ResourceType> StrategicResources{ get { return resourceTypeRegister.StrategicResources; } }



}

public class ResourceTypeRegister : ScriptableObject
{
	public List<ResourceType> MasterList = new List<ResourceType> ();

	public List<ResourceType> StrategicResources { get { return getResourceListByCategory (ResourceCategory.Strategic); } }


	List<ResourceType> getResourceListByCategory (ResourceCategory category)
	{
		List<ResourceType> result = new List<ResourceType> ();

		foreach (var item in MasterList)
		{
			if (item.Category == category)
			{
				result.Add (item);
			}
		}

		return result;
	}

	public ResourceType getResourceType (string _name)
	{
		

		foreach (var item in MasterList)
		{
			if (item.name == _name)
			{
				return item;
			}
		}

		return null;
	}

}

public class StructureRegister : ScriptableObject
{
	public List<StructureType> MasterList = new List<StructureType> ();
}



