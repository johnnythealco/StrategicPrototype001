using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JKTesting : MonoBehaviour
{
	public StructureTypeDisplay structureTypeDisplay;
	public List<StructureType> structures;

	void Start ()
	{

		structureTypeDisplay.Prime (structures [0]);  
		structureTypeDisplay.onUpdate += StructureTypeDisplay_onUpdate;
	}

	void StructureTypeDisplay_onUpdate (StructureType _structureType)
	{
		structures [0] = _structureType;
	}


}
