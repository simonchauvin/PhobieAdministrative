using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonSpeaker : MonoBehaviour 
{
	public AudioClip buttonHPOn;
	public AudioClip buttonHPOff;

	public Color colorSpeakerOn;
	public Color colorSpeakerOff;

	public Sprite spriteSpeakerOn;
	public Sprite spriteSpeakerOff;

	private GameObject buttonChild;
	private ButtonCall buttonCall;
	private Text childText;
	private Image thisImage;
	private bool isOnSpeaker;

	void Start () 
	{
		//buttonChild = transform.GetChild (0).gameObject;
		//childText = buttonChild.GetComponent<Text>();
		buttonCall = FindObjectOfType<ButtonCall>();
		thisImage = GetComponent<Image>();
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
		//childText.color = colorSpeakerOn;
		RefreshVolume ();
		buttonCall.audioSource.PlayOneShot (buttonHPOn);
		thisImage.sprite = spriteSpeakerOn;

	}

	private void DesactiveSpeaker ()
	{
		buttonCall.currentVolumeSpeaker = buttonCall.volumeWithoutSpeaker;
		//childText.color = colorSpeakerOff;
		RefreshVolume ();
		buttonCall.audioSource.PlayOneShot (buttonHPOff);
		thisImage.sprite = spriteSpeakerOff;
	}

	private void RefreshVolume ()
	{
		buttonCall.audioSource.volume = buttonCall.currentVolumeSpeaker;
	}
}
