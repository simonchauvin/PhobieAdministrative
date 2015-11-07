using UnityEngine;
using System.Collections;

public class ButtonCall : MonoBehaviour 
{
	public AudioClip buttonCallSFX;
	public AudioClip noCreditSFX;
	public float durationInvoke;

	private KeyAudioManager keyAudioManager;
	private InterfaceManager interfaceManager;

	void Start ()
	{
		keyAudioManager = FindObjectOfType<KeyAudioManager>();
		interfaceManager = FindObjectOfType<InterfaceManager>();
	}

	public void CallNumero ()
	{
		//StopLastSound ();
		keyAudioManager.audioSource.PlayOneShot (buttonCallSFX);
		Invoke ("NoCredit", durationInvoke);
	}

	public void NoCredit ()
	{
		keyAudioManager.audioSource.PlayOneShot (noCreditSFX);
	}


}
