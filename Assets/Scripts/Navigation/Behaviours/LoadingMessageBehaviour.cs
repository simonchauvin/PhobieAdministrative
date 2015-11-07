using UnityEngine;
using System.Collections;

public class LoadingMessageBehaviour : NavigationBehaviour
{
    public string url;

    private int retrievedCacheHackNumber;


    public virtual void Start()
    {
        base.Start();
    }

    public virtual void Update()
    {
        base.Update();

    }

    public override void activate()
    {
        base.activate();

        StartCoroutine("retrieveCacheHackNumber");
    }

    public virtual void receiveInput(string input)
    {

    }

    IEnumerator retrieveCacheHackNumber()
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
        targetNavigationState.audioClips = new DelayedAudio[1];
        targetNavigationState.audioClips[0] = new DelayedAudio();
        targetNavigationState.audioClips[0].audioClip = null;
        WWW www = new WWW(url + "message_" + retrievedCacheHackNumber + ".wav");

        // Wait for download to complete
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
        }
        else
        {
            targetNavigationState.audioClips[0].audioClip = www.audioClip;
            navigateToTarget();
        }
    }
}
