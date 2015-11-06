using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public AudioClip audioBg;

    /// <summary>
    /// 
    /// </summary>
    public bool loopBg = true;

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
    /// Init.
    /// </summary>
    void Awake()
    {
        //Get attached navigation behaviours
        navigationBehaviours = GetComponents<NavigationBehaviour>();

        //Set Id
        id = navigationStatesCount;
        navigationStatesCount++;
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
        NavigationManager.instance.audioBgSrc.clip = audioBg;
        NavigationManager.instance.audioBgSrc.loop = loopBg;
        NavigationManager.instance.audioBgSrc.Play();

        StartCoroutine("playClips");
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

        //Update current state and history in navigation manager
        NavigationManager.instance.switchState(this);
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
        activate();
    }

}
