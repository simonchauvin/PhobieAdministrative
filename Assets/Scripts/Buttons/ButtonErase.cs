using UnityEngine;
using System.Collections;

public class ButtonErase : MonoBehaviour 
{
	public AudioClip buttonEraseSFX;
	private ButtonCall buttonCall;
	private TextScreen textScreen;

	void Start ()
	{
		textScreen = FindObjectOfType<TextScreen>();
		buttonCall = FindObjectOfType<ButtonCall>();
	}

	public void Erase ()
	{
		buttonCall.audioSource.PlayOneShot (buttonEraseSFX);
		textScreen.textComposedNumber = null;
		textScreen.RefreshText ();
	}
}
