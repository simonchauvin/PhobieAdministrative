using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigationState : MonoBehaviour
{
	/// <summary>
	/// The navigation states count.
	/// </summary>
	public static int navigationStatesCount;

	/// <summary>
	/// Gets the identifier.
	/// </summary>
	/// <value>The identifier.</value>
	public int id {get; private set;}

	/// <summary>
	/// The audio.
	/// </summary>
	public AudioClip audio;

	/// <summary>
	/// The navigation behaviours.
	/// </summary>
	private NavigationBehaviour[] navigationBehaviours;

	/// <summary>
	/// The is active.
	/// </summary>
	public bool isActive {get; private set;}

	/// <summary>
	/// Init.
	/// </summary>
	void Awake()
	{
		//Get attached navigation behaviours
		navigationBehaviours = GetComponents<NavigationBehaviour>();

		//Set Id
		id = navigationStatesCount;
		navigationStatesCount ++;
	}



	/// <summary>
	/// Activate this instance.
	/// </summary>
	public void activate()
	{
		isActive = true;
		//Activate every attached NavigationBehaviour
		foreach(NavigationBehaviour navigationBehaviour in navigationBehaviours)
		{
			navigationBehaviour.activate();
		}

		//Play Audio
	}


	/// <summary>
	/// Deactivate this instance.
	/// </summary>
	public void deactivate()
	{
		isActive = false;
		//Deactivate every attached NavigationBehaviour
		foreach(NavigationBehaviour navigationBehaviour in navigationBehaviours)
		{
			navigationBehaviour.deactivate();
		}

		//Stop Audio

		//
		NavigationManager.instance.switchState(this);
	}



}
