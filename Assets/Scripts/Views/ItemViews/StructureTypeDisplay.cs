using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StructureTypeDisplay : MonoBehaviour
{
	public Text displayname;
	public Text description;
	public Image icon;
	public Text cost;
	public Text influence;




	public InputField displaynameInput;
	public InputField descriptionInput;
	public InputField creditCostInput;
	public InputField influenceCostInput;
	public ResourceListBuilder resourceCostBuilder;
	public CoreResourceDisplay directEffectInput;
	public ResourceListBuilder InputsListBuilder;
	public ResourceListBuilder OutputsListBuilder;

	protected StructureType structureType;

	public delegate void StructureTypeDisplayDelegate (StructureType _structureType);

	public event StructureTypeDisplayDelegate onUpdate;

	public void Prime (StructureType _structureType)
	{
		structureType = _structureType; 

		if (displayname != null)
			displayname.text = structureType.name;
		if (description != null)
			description.text = structureType.descriptions;
		if (icon != null)
			icon.sprite = structureType.smallImage;
		if (cost != null)
			cost.text = structureType.cost.ToString ();
		if (influence != null)
			influence.text = structureType.influence.ToString ();
		if (displaynameInput != null)
			displaynameInput.text = structureType.name;
		if (descriptionInput != null)
			descriptionInput.text = structureType.descriptions;
		if (creditCostInput != null)
			creditCostInput.text = structureType.cost.ToString ();
		if (influenceCostInput != null)
			influenceCostInput.text = structureType.influence.ToString ();

		if (resourceCostBuilder != null)
		{
			resourceCostBuilder.Prime (structureType.inputs.list);
			resourceCostBuilder.onResourceUpdate += onResourceCostUpdat;
		}
		if (directEffectInput != null)
		{
			directEffectInput.Prime (structureType.directEffect);
			directEffectInput.onUpdateResource += onUpdateDirectEffect;
		}

		if (InputsListBuilder != null)
		{
			InputsListBuilder.Prime (structureType.inputs.list);
			InputsListBuilder.onResourceUpdate += onUpdateInputs;
		}
		if (OutputsListBuilder != null)
		{
			OutputsListBuilder.Prime (structureType.outputs.list);
			OutputsListBuilder.onResourceUpdate += onUpdateOutputs;
		}
	
	}

	void onResourceCostUpdat (List<Resource> _resources)
	{
		structureType.resourceCost.list = _resources;
		if (onUpdate != null)
			onUpdate.Invoke (structureType);
	}

	void onUpdateOutputs (List<Resource> _resources)
	{
		structureType.outputs.list = _resources;
		if (onUpdate != null)
			onUpdate.Invoke (structureType);
	}

	void onUpdateInputs (List<Resource> _resources)
	{
		structureType.inputs.list = _resources;
		if (onUpdate != null)
			onUpdate.Invoke (structureType);
	}

	void onUpdateDirectEffect (CoreResource _coreResource)
	{
		structureType.directEffect = _coreResource;
		if (onUpdate != null)
			onUpdate.Invoke (structureType);
	}


	public void GetInput ()
	{
		if (displaynameInput != null)
			structureType.name = displaynameInput.text;
		if (descriptionInput != null)
			structureType.descriptions = descriptionInput.text;
		if (displaynameInput != null)
			structureType.name = displaynameInput.text;
		if (displaynameInput != null)
			structureType.name = displaynameInput.text;
	}


	void OnDestroy ()
	{
		
		directEffectInput.onUpdateResource -= onUpdateDirectEffect;
		InputsListBuilder.onResourceUpdate -= onUpdateInputs;
		OutputsListBuilder.onResourceUpdate -= onUpdateOutputs;


	}





	

	 
}
