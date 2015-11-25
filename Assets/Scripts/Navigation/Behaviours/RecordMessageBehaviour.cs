using UnityEngine;
using System.Collections;
using System.IO;

public class RecordMessageBehaviour : NavigationBehaviour
{
    public string url;

    public char characterToEnter;

    public int maxRecordingTime;

    private AudioSource audioSourceTemp;

    private string cacheHackNumberToRecord;
    private float timer;
    private float actualRecordingTime;
    private bool recordingEnded;


    public override void Start()
    {
        base.Start();

        audioSourceTemp = GetComponents<AudioSource>()[0];
        timer = 0f;
        actualRecordingTime = 0f;
        recordingEnded = false;
    }

    public override void Update()
    {
        base.Update();

        if (isActive)
        {
            timer += Time.deltaTime;
            actualRecordingTime += Time.deltaTime;
            if (!recordingEnded && timer >= maxRecordingTime)
            {
                stopRecording();
                StartCoroutine("sendMessage");
            }
        }
    }

    public override void activate()
    {
        base.activate();

        timer = 0f;
        actualRecordingTime = 0f;
        recordingEnded = false;
        recordMessage();
    }

    public override void receiveInput(string input)
    {
        if (!recordingEnded && input.Equals(characterToEnter.ToString()))
        {
            //stopRecording();
            //StartCoroutine("recordCacheHackNumber");
        }
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
        }
    }

    IEnumerator sendMessage()
    {
        string name = "message_" + cacheHackNumberToRecord;
        byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/" + name + ".wav");
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
            StartCoroutine("recordCacheHackNumber");
            navigateToTarget();
        }
    }

    void recordMessage()
    {
        audioSourceTemp.clip = Microphone.Start("Built-in Microphone", false, maxRecordingTime, 44100);
    }

    void stopRecording()
    {
        recordingEnded = true;

        Microphone.End("Built-in Microphone");

        // Trim clip
        AudioClip ac = audioSourceTemp.clip;
        float lengthL = ac.length;
        float samplesL = ac.samples;
        float samplesPerSec = (float)samplesL / lengthL;
        float[] samples = new float[(int)(samplesPerSec * actualRecordingTime)];
        ac.GetData(samples, 0);
        audioSourceTemp.clip = AudioClip.Create("RecordedSound", (int)(actualRecordingTime * samplesPerSec), 1, 44100, false, false);
        audioSourceTemp.clip.SetData(samples, 0);

        cacheHackNumberToRecord = Random.Range(1111, 9999).ToString();
        SaveWav.Save("message_" + cacheHackNumberToRecord, audioSourceTemp.clip);
    }
}
