using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class KeyAudioManager : MonoBehaviour 
{
	public AudioSource audioSource;
	public AudioClip ringSFX;

	public float volumeWithSpeaker;
	public float volumeWithoutSpeaker;

	public float timeBeforeAnotherRing;
	public int numberOfWaitingRingsMax;
	private int numberOfWaitingRings;

	private InterfaceManager interfaceManager;
	private float currentVolumeSpeaker;
    
	void Start ()
	{
		interfaceManager = FindObjectOfType<InterfaceManager>();
		audioSource = GetComponent<AudioSource>();
		SetNextNumberOfRings ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.A))
			SetDring ();
	}

	public void SpeakerOn ()
	{
		currentVolumeSpeaker = volumeWithSpeaker;
		RefreshVolume ();
	}

	public void SpeakerOff ()
	{
		currentVolumeSpeaker = volumeWithoutSpeaker;
		RefreshVolume ();
	}
	
	private void RefreshVolume ()
	{
		audioSource.volume = currentVolumeSpeaker;
	}

	public void SetDring ()
	{
		if (numberOfWaitingRings > 0)
		{
#if UNITY_ANDROID

			//Handheld.Vibrate ();
#endif
			audioSource.clip = ringSFX;
			audioSource.Play ();
			print ("ring");
			numberOfWaitingRings --;
			Invoke ("SetDring", timeBeforeAnotherRing);
		}
		else
		{
			print ("raccroche");
			SetNextNumberOfRings ();
			interfaceManager.GoToNormalInterface ();
		}
	}

	public void SetNextNumberOfRings ()
	{
		numberOfWaitingRings = numberOfWaitingRingsMax;
	}

	public void CancelDring ()
	{
		CancelInvoke ("SetDring");
	}
	
	private void StopLastSound ()
	{
		audioSource.Stop ();
	}
}
