using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneManager : MonoBehaviour
{
    //public Text microphoneText;
    public int duration;
    public int frequency;

    //Détermine si ça récrit par dessus à la fin
    public bool loop;

    private ButtonCall buttonCall;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //microphoneText.text = null;
        //Debug.Log("Name: " + device);
        /*foreach (string device in Microphone.devices)
            microphoneText.text = microphoneText.text + "Name: " + device;*/

        /*if (Microphone.devices.Length == 1)
            microphoneText.text = "Micro " + Microphone.devices[0];*/
#if UNITY_ANDROID
        StartCoroutine("LoadAudioClip");
#endif
    }

#if UNITY_ANDROID
	IEnumerator LoadAudioClip ()
	{
		string path = "file:///"+ Application.persistentDataPath + "/RecordedMessage.wav";
		WWW www = new WWW (path);
		yield return www;
		AudioClip audioClipLoaded = www.GetAudioClip (false, false, AudioType.WAV);
		audioSource.clip = audioClipLoaded;
    }
#endif

    public void SaveAudioClip()
    {
        SaveWav.Save("RecordedMessage", audioSource.clip);
    }

    public void RecordMicro()
    {
        audioSource.clip = null;
        audioSource.clip = Microphone.Start("Built-in Microphone", loop, duration, frequency);
    }

    public void StopMicro()
    {
        Microphone.End("Built-in Microphone");
        SaveAudioClip();
    }

    public void PlayMicro()
    {
        StopMicro();
        audioSource.Stop();
        audioSource.PlayOneShot(audioSource.clip);
    }
}
