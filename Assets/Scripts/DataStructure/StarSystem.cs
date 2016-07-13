using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;




[System.Serializable]
public class StarSystem : Asset
{
	public List<Planet> planets;
	public List<Region> localRegions;
}


[System.Serializable]
public class Planet : Asset
{
	public string classification;
	public List<Region> regions;

}

[System.Serializable]
public class Region : Asset
{
	public string owner;
	public List<StructureType> structures;

}

[System.Serializable]
public class StructureType : Asset
{
	public int cost;
	public int influence;
	public Resources resourceCost;

	public CoreResource directEffect;

	public Resources inputs;
	public Resources outputs;
	
}
