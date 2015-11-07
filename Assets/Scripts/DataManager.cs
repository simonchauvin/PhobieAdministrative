using System.IO;
using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour
{
    public string url;

    private AudioSource audioSource;
    private AudioSource audioSourceTemp;

    private int cacheHackNumberToRecord;
    private int retrievedCacheHackNumber;

	
	void Start ()
    {
        audioSource = GetComponents<AudioSource>()[0];
        audioSourceTemp = GetComponents<AudioSource>()[1];
	}
	
	
	void Update ()
    {
        /* FOR DEBUG PURPOSES
	    if (Input.GetKeyDown(KeyCode.F))
        {
            recordMessage();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            stopRecording();
            StartCoroutine("recordCacheHackNumber");
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine("retrieveCacheHackNumber");
        }*/
	}

    IEnumerator recordCacheHackNumber()
    {
        WWWForm form = new WWWForm();
        form.AddField("cacheHackNumber", cacheHackNumberToRecord);

        WWW www = new WWW(url + "recordCacheHackNumber.php?nocache=" + Random.value, form);

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
        }
        else
        {
            print("Finished upload cach hack number");
            StartCoroutine("sendMessage");
        }
    }

    IEnumerator retrieveCacheHackNumber ()
    {
        WWW www = new WWW(url + "retrieveCacheHackNumber.php?nocache=" + Random.value);

        // Wait for download to complete
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
        }
        else
        {
            retrievedCacheHackNumber = int.Parse(www.text);
            StartCoroutine("retrieveMessage");
        }
    }

    IEnumerator retrieveMessage()
    {
        audioSource.clip = null;
        WWW www = new WWW(url + "message_" + retrievedCacheHackNumber + ".wav");

        // Wait for download to complete
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
        }
        else
        {
            audioSource.clip = www.audioClip;
            audioSource.Play();
        }
    }

    void recordMessage ()
    {
        audioSourceTemp.clip = Microphone.Start("Built-in Microphone", false, 20, 44100);
    }

    void stopRecording ()
    {
        Microphone.End("Built-in Microphone");
        cacheHackNumberToRecord = Random.Range(0, 99);
        SaveWav.Save("message_" + cacheHackNumberToRecord, audioSourceTemp.clip);
    }

    IEnumerator sendMessage()
    {
        string name = "message_" + cacheHackNumberToRecord;
        byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "\\" + name + ".wav");
        WWWForm form = new WWWForm();
        form.AddBinaryData("message", bytes, name + ".wav", "application/octet-stream");

        WWW w = new WWW(url + "recordMessage.php?nocache=" + Random.value, form);
        yield return w;

        if (!string.IsNullOrEmpty(w.error))
        {
            print(w.error);
        }
        else
        {
            print("Finished Uploading message");
        }
    }
}
