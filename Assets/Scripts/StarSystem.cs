using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class StarSystem : System.Object
{
	short id;
	string name;
	string descriptions;


}


[System.Serializable]
public class Planet : System.Object
{
	short id;
	string name;
	string descriptions;


}

[System.Serializable]
public class Region : System.Object
{
	short id;
	string name;
	string descriptions;


}

[System.Serializable]
public class Structure : System.Object
{
	public short id;
	public string name;
	public string descriptions;
	public ResourceQuantity cost;
}
