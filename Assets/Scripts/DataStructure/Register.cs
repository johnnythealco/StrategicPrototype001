using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Register : ScriptableObject
{
	public  ResourceRegister resourceRegister;
	public  StructureRegister structureRegister;

	public List<ResourceType> AllResources{ get { return resourceRegister.MasterList; } }

	public List<ResourceType> StrategicResources{ get { return resourceRegister.StrategicResources; } }



}

public class ResourceRegister : ScriptableObject
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
	public List<Structure> MasterList = new List<Structure> ();
}



