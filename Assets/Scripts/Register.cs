using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Register : ScriptableObject
{
	public  ResourceRegister resourceRegister;
	public  StructureRegister structureRegister;


}

public class ResourceRegister : ScriptableObject
{
	public List<ResourceType> MasterList = new List<ResourceType> ();

}

public class StructureRegister : ScriptableObject
{
	public List<Structure> MasterList = new List<Structure> ();
}



