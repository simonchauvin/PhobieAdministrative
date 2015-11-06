using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonSpeaker : MonoBehaviour 
{
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
	}

	private void DesactiveSpeaker ()
	{
		buttonCall.currentVolumeSpeaker = buttonCall.volumeWithoutSpeaker;
		childText.color = colorSpeakerOff;
		RefreshVolume ();
	}

	private void RefreshVolume ()
	{
		buttonCall.audioSource.volume = buttonCall.currentVolumeSpeaker;
	}
}
