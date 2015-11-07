using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class NavigationState : MonoBehaviour
{
    /// <summary>
    /// The navigation states count.
    /// </summary>
    public static int navigationStatesCount;

    /// <summary>
    /// Gets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public int id { get; private set; }

    /// <summary>
    /// The audio.
    /// </summary>
    public AudioBackground.Type audioBgType;

    /// <summary>
    /// 
    /// </summary>
    public bool loopBg = true;

    /// <summary>
    /// Volume of the bg sound.
    /// </summary>
    public float volume = 1f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    public DelayedAudio[] audioClips;

    /// <summary>
    /// 
    /// </summary>
    public float delayToReplayState = 0f;

    /// <summary>
    /// The navigation behaviours.
    /// </summary>
    private NavigationBehaviour[] navigationBehaviours;

    /// <summary>
    /// 
    /// </summary>
    public Color color;

    /// <summary>
    /// 
    /// </summary>
    public float duration {get; set;}

    /// <summary>
    /// Init.
    /// </summary>
    void Awake()
    {
        //Get attached navigation behaviours
        navigationBehaviours = GetComponents<NavigationBehaviour>();

        //Set Id
        id = navigationStatesCount;
        navigationStatesCount++;

        //Color
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);

        //
        duration = 0f;
        foreach(DelayedAudio delayedAudio in audioClips)
        {
            duration += delayedAudio.delay + delayedAudio.audioClip.length;
        }
        duration += delayToReplayState;
    }


    /// <summary>
    /// Activate this instance.
    /// </summary>
    public void activate()
    {
        foreach (NavigationBehaviour navigationBehaviour in navigationBehaviours)
        {
            navigationBehaviour.activate();
        }

        //Play Audio
        NavigationManager.instance.audioBgSrc.clip = AudioBackground.instance.retrieveAudioClip(audioBgType);
        NavigationManager.instance.audioBgSrc.volume = volume;
        NavigationManager.instance.audioBgSrc.loop = loopBg;
        NavigationManager.instance.audioBgSrc.Play();

        StartCoroutine("playClips");

        //Color
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
    }


    /// <summary>
    /// Deactivate this instance.
    /// </summary>
    public void deactivate()
    {
        foreach (NavigationBehaviour navigationBehaviour in navigationBehaviours)
        {
            navigationBehaviour.deactivate();
        }

        //Stop Audio
        NavigationManager.instance.audioBgSrc.Stop();
        NavigationManager.instance.audioClipsSrc.Stop();
        StopCoroutine("playClips");

        //Color
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
    }

    /// <summary>
    /// Receives the input.
    /// </summary>
    /// <param name="input">Input.</param>
    public void receiveInput(string input)
    {
        foreach (NavigationBehaviour navigationBehaviour in navigationBehaviours)
        {
            navigationBehaviour.receiveInput(input);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator playClips()
    {
        if (audioClips.Length == 0)
            yield break;

        int clipId = 0;
        while(clipId < audioClips.Length)
        {
            //PlayBack delay
            float delay = audioClips[clipId].delay;
            yield return new WaitForSeconds(delay);

            //Play
            NavigationManager.instance.audioClipsSrc.clip = audioClips[clipId].audioClip;
            NavigationManager.instance.audioClipsSrc.Play();

            //Wait for length of clip
            float clipLength = audioClips[clipId].audioClip.length;
            yield return new WaitForSeconds(clipLength);

            clipId++;
        }
        //Last Delay before reset state
        yield return new WaitForSeconds(delayToReplayState);

        //Stop current Audio
        NavigationManager.instance.audioBgSrc.Stop();
        NavigationManager.instance.audioClipsSrc.Stop();
        //Launch audio again
        //Play Audio
        NavigationManager.instance.audioBgSrc.clip = AudioBackground.instance.retrieveAudioClip(audioBgType);
        NavigationManager.instance.audioBgSrc.volume = volume;
        NavigationManager.instance.audioBgSrc.loop = loopBg;
        NavigationManager.instance.audioBgSrc.Play();

        StartCoroutine("playClips");
    }

}
