using UnityEngine;
using System.Collections;

public class ButtonSpeaker : MonoBehaviour 
{
	private ButtonCall buttonCall;
	private bool isOnSpeaker;
	
	void Start () 
	{
		buttonCall = FindObjectOfType<ButtonCall>();
		RefreshVolume ();
	}

	public void ToggleSpeaker () 
	{
		isOnSpeaker = !isOnSpeaker;

		if (isOnSpeaker)
			ActiveSpeaker ();
		else
			DesactiveSpeaker ();
	}

	private void ActiveSpeaker ()
	{
		buttonCall.currentVolumeSpeaker = buttonCall.volumeWithSpeaker;
		RefreshVolume ();
	}

	private void DesactiveSpeaker ()
	{
		buttonCall.currentVolumeSpeaker = buttonCall.volumeWithoutSpeaker;
		RefreshVolume ();
	}

	private void RefreshVolume ()
	{
		buttonCall.audioSource.volume = buttonCall.currentVolumeSpeaker;
	}
}
