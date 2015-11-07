using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonSpeaker : MonoBehaviour 
{
	public AudioClip buttonHPOn;
	public AudioClip buttonHPOff;
	public Sprite spriteSpeakerOn;
	public Sprite spriteSpeakerOff;

	public bool isOnSpeaker;

	private GameObject buttonChild;
	private KeyAudioManager keyAudioManager;
	private Image thisImage;

	void Start () 
	{
		keyAudioManager = FindObjectOfType<KeyAudioManager>();
		thisImage = GetComponent<Image>();

		if (isOnSpeaker)
		{
			keyAudioManager.SpeakerOn ();
			thisImage.sprite = spriteSpeakerOn;
		}
		else
		{
			keyAudioManager.SpeakerOff ();
			thisImage.sprite = spriteSpeakerOff;
		}
	}

	public void ToggleSpeaker () 
	{
		isOnSpeaker = !isOnSpeaker;
		CheckSpeaker ();
	}

	private void CheckSpeaker ()
	{
		if (isOnSpeaker)
			ActiveSpeaker ();
		else
			DesactiveSpeaker ();
	}

	private void ActiveSpeaker ()
	{
		keyAudioManager.SpeakerOn ();
		keyAudioManager.audioSource.PlayOneShot (buttonHPOn);
		thisImage.sprite = spriteSpeakerOn;
	}

	private void DesactiveSpeaker ()
	{
		keyAudioManager.SpeakerOff ();
		keyAudioManager.audioSource.PlayOneShot (buttonHPOff);
		thisImage.sprite = spriteSpeakerOff;
	}
}
