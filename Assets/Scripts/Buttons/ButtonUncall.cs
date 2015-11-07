using UnityEngine;
using System.Collections;

public class ButtonUncall : MonoBehaviour 
{
	public AudioClip buttonUncallSFX;

	private InterfaceManager interfaceManager;
	private KeyAudioManager keyAudioManager;
	
	void Start ()
	{
		keyAudioManager = FindObjectOfType<KeyAudioManager>();
		interfaceManager = FindObjectOfType<InterfaceManager>();
	}

	public void Uncall ()
	{
		keyAudioManager.audioSource.Stop ();
		keyAudioManager.audioSource.PlayOneShot (buttonUncallSFX);
		interfaceManager.GoToNormalInterface ();
	}
}
