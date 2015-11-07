using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterfaceManager : MonoBehaviour 
{
	public AvailableInterfacesEnum possibeInterfaces;

	public GameObject dringInterface;
	public GameObject keyboardInterface;

	public GameObject receiveCall;
	public GameObject giveCall;

	public GameObject buttonCall;
	public GameObject buttonUncall;

	public GameObject buttonBack;

	public AudioClip buttonAcceptSFX;
	public AudioClip buttonDeclineSFX;

	private ReceiveCallManager receiveCallManager;
	private KeyAudioManager keyAudioManager;

	void Start ()
	{
		receiveCallManager = FindObjectOfType<ReceiveCallManager>();
		keyAudioManager = FindObjectOfType<KeyAudioManager>();
	}

	public void GoToDringInterface ()
	{
		possibeInterfaces = AvailableInterfacesEnum.Dring;
		keyboardInterface.SetActive (false);
		dringInterface.SetActive (true);
		receiveCall.SetActive (false);
		giveCall.SetActive (false);
		keyAudioManager.SetDring ();
	}

	public void GoToNormalInterface ()
	{
		possibeInterfaces = AvailableInterfacesEnum.Normal;
		keyboardInterface.SetActive (true);
		dringInterface.SetActive (false);
		buttonCall.SetActive (true);
		buttonUncall.SetActive (false);
		giveCall.SetActive (false);
		receiveCall.SetActive (false);

		if (receiveCallManager.activeCall)
			receiveCallManager.WillCallPlayer ();
	}

	public void GoToGiveCallInterface ()
	{
		possibeInterfaces = AvailableInterfacesEnum.GiveCall;
		buttonCall.SetActive (false);
		buttonUncall.SetActive (true);
		giveCall.SetActive (true);
	}

	public void GoToReceiveCallInterface ()
	{
		possibeInterfaces = AvailableInterfacesEnum.ReceiveCall;
		dringInterface.SetActive (false);
		keyboardInterface.SetActive (true);
		buttonCall.SetActive (false);
		buttonUncall.SetActive (true);
		receiveCall.SetActive (true);
	}

	public void AcceptCall ()
	{
		GoToReceiveCallInterface ();
		keyAudioManager.audioSource.PlayOneShot (buttonAcceptSFX);
		keyAudioManager.CancelDring ();
	}

	public void DeclineCall ()
	{
		GoToNormalInterface ();
		keyAudioManager.audioSource.PlayOneShot (buttonDeclineSFX);
		keyAudioManager.CancelDring ();
	}
}
