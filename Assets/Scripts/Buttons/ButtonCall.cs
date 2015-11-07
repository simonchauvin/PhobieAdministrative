using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class ButtonCall : MonoBehaviour 
{
	public AudioSource audioSource;
	public AudioClip buttonCallSFX;
	public AudioClip num01SFX;
	public AudioClip num02SFX;
	public AudioClip numNotAttributedSFX;

	public string numToCall01;
	public string numToCall02;

	public float currentVolumeSpeaker;
	public float volumeWithSpeaker;
	public float volumeWithoutSpeaker;

	private TextScreen textScreen;
	private ButtonCallManager buttonCallManager;

	void Start ()
	{
		textScreen = FindObjectOfType<TextScreen>();
		buttonCallManager = FindObjectOfType<ButtonCallManager>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.A))
			ReceiveCall ();
	}

	public void CallNumero ()
	{
		StopLastSound ();
		audioSource.PlayOneShot (buttonCallSFX);

		buttonCallManager.isPlayerInACall = true;
		buttonCallManager.isPlayerGiveTheCall = true;
		buttonCallManager.SetCallButtons ();

		if (textScreen.textComposedNumber == numToCall01)
			CallNum01 ();
		else if (textScreen.textComposedNumber == numToCall02)
			CallNum02 ();
		else
			CallNumNotAttributed ();
	}

	public void ReceiveCall ()
	{
		buttonCallManager.isPlayerInACall = true;
		buttonCallManager.isPlayerGiveTheCall = false;
		buttonCallManager.SetCallButtons ();
	}

	private void CallNum01 ()
	{
		audioSource.PlayOneShot (num01SFX);
	}

	private void CallNum02 ()
	{
		audioSource.PlayOneShot (num02SFX);
	}

	private void CallNumNotAttributed ()
	{
		audioSource.PlayOneShot (numNotAttributedSFX);
	}

	private void StopLastSound ()
	{
		audioSource.Stop ();
	}
}
