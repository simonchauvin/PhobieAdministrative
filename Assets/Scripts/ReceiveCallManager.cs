using UnityEngine;
using System.Collections;

public class ReceiveCallManager : MonoBehaviour 
{
	public float timeBeforeACall;
	public bool activeCall;
	private InterfaceManager interfaceManager;

	void Start ()
	{
		interfaceManager = FindObjectOfType<InterfaceManager>();

		if (activeCall)
			WillCallPlayer ();
	}

	public void WillCallPlayer ()
	{
		Invoke ("CallPlayer", timeBeforeACall);
	}

	public void CallPlayer ()
	{
		interfaceManager.GoToDringInterface ();
	}
}
