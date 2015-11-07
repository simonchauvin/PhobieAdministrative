using UnityEngine;
using System.Collections;

public class ButtonCredits : MonoBehaviour 
{
	public GameObject creditsUI;
	public AudioClip buttonCreditsSFX;

	private KeyAudioManager keyAudioManager;
	private bool isInCredits;

	void Start ()
	{
		keyAudioManager = FindObjectOfType<KeyAudioManager>();
		SetCreditsWindow ();
	}

	public void Credits ()
	{
		isInCredits = !isInCredits;
		keyAudioManager.audioSource.PlayOneShot (buttonCreditsSFX);
		SetCreditsWindow ();
	}

	private void SetCreditsWindow ()
	{
		creditsUI.SetActive (isInCredits);
	}
}
