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

	public AudioClip buttonAcceptSFX;
	public AudioClip buttonDeclineSFX;

	private ReceiveCallManager receiveCallManager;
	private KeyAudioManager keyAudioManager;
	private ButtonCall buttonCall;

	private GameObject buttonCallObj;
	private GameObject buttonUncallObj;
	
	private GameObject buttonBackObj;

	void Start ()
	{
		receiveCallManager = FindObjectOfType<ReceiveCallManager>();
		keyAudioManager = FindObjectOfType<KeyAudioManager>();

		buttonCall = FindObjectOfType<ButtonCall>();

		buttonCallObj = buttonCall.gameObject;
		buttonBackObj = FindObjectOfType<ButtonErase>().gameObject;
		buttonUncallObj = FindObjectOfType<ButtonUncall>().gameObject;
		SetNormalInterface ();
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
		SetNormalInterface ();
		if (receiveCallManager.activeCall)
			receiveCallManager.WillCallPlayer ();
	}

	private void SetNormalInterface ()
	{
		possibeInterfaces = AvailableInterfacesEnum.Normal;
		keyboardInterface.SetActive (true);
		dringInterface.SetActive (false);
		buttonCallObj.SetActive (true);
		buttonUncallObj.SetActive (false);
		giveCall.SetActive (false);
		receiveCall.SetActive (false);
		//buttonBack.transform.localPosition = new Vector3 (150, buttonBack.transform.localPosition.y, 0);
	}

	public void GoToGiveCallInterface ()
	{
		possibeInterfaces = AvailableInterfacesEnum.GiveCall;
		SetCallInterface ();
	}

	public void GoToReceiveCallInterface ()
	{
		possibeInterfaces = AvailableInterfacesEnum.ReceiveCall;
		SetCallInterface ();
	}

	private void SetCallInterface ()
	{
		dringInterface.SetActive (false);
		keyboardInterface.SetActive (true);
		buttonCallObj.SetActive (false);
		buttonUncallObj.SetActive (true);
		receiveCall.SetActive (true);
		//buttonBack.transform.localPosition = new Vector3 (-150, buttonBack.transform.localPosition.y, 0);
	}

	public void AcceptCall ()
	{
		GoToReceiveCallInterface ();
		keyAudioManager.audioSource.Stop ();
		keyAudioManager.audioSource.PlayOneShot (buttonAcceptSFX);
		keyAudioManager.SetNextNumberOfRings ();
		keyAudioManager.CancelDring ();
		buttonCall.CancelCall ();
	}

	public void DeclineCall ()
	{
		GoToNormalInterface ();
		keyAudioManager.audioSource.Stop ();
		keyAudioManager.audioSource.PlayOneShot (buttonDeclineSFX);
		keyAudioManager.SetNextNumberOfRings ();
		keyAudioManager.CancelDring ();
		buttonCall.CancelCall ();
	}
}
