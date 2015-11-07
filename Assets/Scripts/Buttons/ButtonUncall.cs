using UnityEngine;
using System.Collections;

public class ButtonUncall : MonoBehaviour 
{
	public AudioClip buttonUncallSFX;

	private ButtonCallManager buttonCallManager;
	private ButtonCall buttonCall;

	void Start ()
	{
		buttonCall = FindObjectOfType<ButtonCall>();
		buttonCallManager = FindObjectOfType<ButtonCallManager>();
	}

	public void Uncall ()
	{
		buttonCall.audioSource.Stop ();
		buttonCall.audioSource.PlayOneShot (buttonUncallSFX);

		buttonCallManager.isPlayerInACall = false;
		buttonCallManager.SetCallButtons ();
	}
}
