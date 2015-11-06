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

		LoadAudioClip ();
	}

	public void LoadAudioClip ()
	{
		//audioSource.clip = DataFile.Load<AudioClip> (Application.persistentDataPath + "/RecordedMessage.wav");
		AudioClip recordedClip = Resources.Load<AudioClip>(Application.persistentDataPath + "/RecordedMessage.wav");
		print (recordedClip);

		//string path = Application.persistentDataPath;
		//string file = "/RecordedMessage.wav";

		//Resources.Load (path, file);
	}

	public void SaveAudioClip ()
	{
		SaveWav.Save ("RecordedMessage", audioSource.clip);
	}

	public void RecordMicro ()
	{
		audioSource.clip = Microphone.Start ("Built-in Microphone", loop, duration, frequency);
	}

	public void StopMicro ()
	{
		Microphone.End ("Built-in Microphone");
		SaveAudioClip ();
	}

	public void PlayMicro ()
	{
		StopMicro ();
		audioSource.Stop ();
		audioSource.PlayOneShot (audioSource.clip);
	}
}
