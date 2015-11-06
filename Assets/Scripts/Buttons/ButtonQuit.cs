using UnityEngine;
using System.Collections;

public class ButtonQuit : MonoBehaviour 
{
	public AudioClip buttonQuitSFX;
	private ButtonCall buttonCall;

	void Start ()
	{
		buttonCall = FindObjectOfType<ButtonCall>();
	}

	public void ExitGame ()
	{
		buttonCall.audioSource.PlayOneShot (buttonQuitSFX);
		Application.Quit ();
	}
}
