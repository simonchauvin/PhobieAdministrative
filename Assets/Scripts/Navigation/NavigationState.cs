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
		//Play Audio
	}


	/// <summary>
	/// Deactivate this instance.
	/// </summary>
	public void deactivate()
	{
		//Stop Audio

		//Update current state and history in navigation manager
		NavigationManager.instance.switchState(this);
	}

	/// <summary>
	/// Receives the input.
	/// </summary>
	/// <param name="input">Input.</param>
	public void receiveInput(string input)
	{
		foreach(NavigationBehaviour navigationBehaviour in navigationBehaviours)
		{
			navigationBehaviour.receiveInput(input);
		}
	}

}
