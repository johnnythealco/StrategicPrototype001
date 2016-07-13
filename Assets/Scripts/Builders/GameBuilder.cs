using UnityEngine;
using System.Collections;

public class GameBuilder : MonoBehaviour
{
	public GameBuilder gameBuilder;
	public ResourceBuilder resourceBuilderPrefab;
	ResourceBuilder Builder;



	public void CreateResourceType ()
	{
		gameBuilder.gameObject.SetActive (false);
		Builder = (ResourceBuilder)Instantiate (resourceBuilderPrefab);

		Builder.onComplete += ResourceBuilder_onComplete;
	}


	void ResourceBuilder_onComplete ()
	{
		Builder.destroy (); 
		gameBuilder.gameObject.SetActive (true);
	}

	void OnDestroy ()
	{
		Builder.onComplete -= ResourceBuilder_onComplete;
	}

}
