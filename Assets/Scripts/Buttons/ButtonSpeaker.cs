using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonSpeaker : MonoBehaviour 
{
	public AudioClip buttonHPOn;
	public AudioClip buttonHPOff;

	public Color colorSpeakerOn;
	public Color colorSpeakerOff;

	private GameObject buttonChild;
	private ButtonCall buttonCall;
	private Text childText;
	private bool isOnSpeaker;

	void Start () 
	{
		buttonChild = transform.GetChild (0).gameObject;
		childText = buttonChild.GetComponent<Text>();
		buttonCall = FindObjectOfType<ButtonCall>();
		DesactiveSpeaker ();
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
		childText.color = colorSpeakerOn;
		RefreshVolume ();
		buttonCall.audioSource.PlayOneShot (buttonHPOn);
	}

	private void DesactiveSpeaker ()
	{
		buttonCall.currentVolumeSpeaker = buttonCall.volumeWithoutSpeaker;
		childText.color = colorSpeakerOff;
		RefreshVolume ();
		buttonCall.audioSource.PlayOneShot (buttonHPOff);
	}

	private void RefreshVolume ()
	{
		buttonCall.audioSource.volume = buttonCall.currentVolumeSpeaker;
	}
}
