using UnityEngine;
using System.Collections;

public class ButtonUncall : MonoBehaviour 
{
	public AudioClip buttonUncallSFX;
	private ButtonCall buttonCall;

	void Start ()
	{
		buttonCall = FindObjectOfType<ButtonCall>();
	}

	public void Uncall ()
	{
		buttonCall.audioSource.Stop ();
		buttonCall.audioSource.PlayOneShot (buttonUncallSFX);
	}
}
