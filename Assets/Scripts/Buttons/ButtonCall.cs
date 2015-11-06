﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class ButtonCall : MonoBehaviour 
{
	public AudioSource audioSource;

	public AudioClip num01SFX;
	public AudioClip num02SFX;
	public AudioClip numNotAttributedSFX;

	public string numToCall01;
	public string numToCall02;

	public float currentVolumeSpeaker;
	public float volumeWithSpeaker;
	public float volumeWithoutSpeaker;

	private TextScreen textScreen;

	void Start ()
	{
		textScreen = FindObjectOfType<TextScreen>();
		audioSource = GetComponent<AudioSource>();
	}

	public void CallNumero ()
	{
		if (textScreen.textComposedNumber == numToCall01)
			CallNum01 ();
		else if (textScreen.textComposedNumber == numToCall02)
			CallNum02 ();
		else
			CallNumNotAttributed ();
	}

	private void CallNum01 ()
	{
		StopLastSound ();
		audioSource.PlayOneShot (num01SFX);
	}

	private void CallNum02 ()
	{
		StopLastSound ();
		audioSource.PlayOneShot (num02SFX);
	}

	private void CallNumNotAttributed ()
	{
		StopLastSound ();
		audioSource.PlayOneShot (numNotAttributedSFX);
	}

	private void StopLastSound ()
	{
		audioSource.Stop ();
	}
}
