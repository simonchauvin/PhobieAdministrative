using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class KeyAudioManager : MonoBehaviour 
{
	public AudioSource audioSource;
	public AudioClip ringSFX;

	public float volumeWithSpeaker;
	public float volumeWithoutSpeaker;

	private InterfaceManager interfaceManager;
	private float currentVolumeSpeaker;

	
	void Start ()
	{
		interfaceManager = FindObjectOfType<InterfaceManager>();
		audioSource = GetComponent<AudioSource>();
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
#if UNITY_ANDROID
		Handheld.Vibrate ();
#endif
		audioSource.clip = ringSFX;
		audioSource.Play ();
	}
	
	private void StopLastSound ()
	{
		audioSource.Stop ();
	}
}
