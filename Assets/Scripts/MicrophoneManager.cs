using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class MicrophoneManager : MonoBehaviour 
{
	public Text microphoneText;
	public int duration;
	public int frequency;

	//Détermine si ça récrit par dessus à la fin
	public bool loop;

	private ButtonCall buttonCall;
	private AudioSource audioSource;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();

		microphoneText.text = null;
		//Debug.Log("Name: " + device);
		foreach (string device in Microphone.devices) 
			microphoneText.text = microphoneText.text + "Name: " + device;

		if (Microphone.devices.Length == 1)
			microphoneText.text = "Micro " + Microphone.devices[0];
	}

	public void RecordMicro ()
	{
		audioSource.clip = Microphone.Start ("Built-in Microphone", loop, duration, frequency);
	}

	public void StopMicro ()
	{
		Microphone.End ("Built-in Microphone");
	}

	public void PlayMicro ()
	{
		StopMicro ();
		audioSource.Stop ();
		audioSource.PlayOneShot (audioSource.clip);
	}
}
