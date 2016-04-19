using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Register : ScriptableObject
{


}

public class ResourceRegister : ScriptableObject
{
	public List<Resource> GameResources = new List<Resource> ();
}

public class StructureRegister : ScriptableObject
{
	public List<Structure> GameStructures = new List<Structure> ();
}

