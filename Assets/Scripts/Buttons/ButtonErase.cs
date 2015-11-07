using UnityEngine;
using System.Collections;

public class ButtonErase : MonoBehaviour 
{
	public AudioClip buttonEraseSFX;
	private KeyAudioManager keyAudioManager;
	private TextScreen textScreen;

	void Start ()
	{
		textScreen = FindObjectOfType<TextScreen>();
		keyAudioManager = FindObjectOfType<KeyAudioManager>();
	}

	public void Erase ()
	{
		keyAudioManager.audioSource.PlayOneShot (buttonEraseSFX);
		textScreen.textComposedNumber = null;
		textScreen.RefreshText ();
	}
}
