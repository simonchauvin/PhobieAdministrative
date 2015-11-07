using UnityEngine;
using System.Collections;

public class ReceiveCallManager : MonoBehaviour 
{
	public float timeBeforeACall;
	public int incrementationRingsNumber;
	public bool activeCall;

	private InterfaceManager interfaceManager;
	private KeyAudioManager keyAudioManager;

	void Start ()
	{
		interfaceManager = FindObjectOfType<InterfaceManager>();
		keyAudioManager = FindObjectOfType<KeyAudioManager>();

		if (activeCall)
			WillCallPlayer ();
	}

	public void WillCallPlayer ()
	{
		Invoke ("CallPlayer", timeBeforeACall);
	}

	public void CallPlayer ()
	{
		keyAudioManager.numberOfWaitingRingsMax += incrementationRingsNumber;
		interfaceManager.GoToDringInterface ();
	}
}
