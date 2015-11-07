using UnityEngine;
using System.Collections;

public class ButtonQuit : MonoBehaviour 
{
	public AudioClip buttonQuitSFX;

	private KeyAudioManager keyAudioManager;
	
	void Start ()
	{
		keyAudioManager = FindObjectOfType<KeyAudioManager>();
	}

	public void ExitGame ()
	{
		keyAudioManager.audioSource.PlayOneShot (buttonQuitSFX);
		Application.Quit ();
	}
}
