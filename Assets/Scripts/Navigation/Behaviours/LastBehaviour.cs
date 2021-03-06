﻿using UnityEngine;
using System.Collections;

public class LastBehaviour : NavigationBehaviour {

    // PUBLIC
    public bool waitToEndOfStateClips = false;

    public float timeToWait;

    // PRIVATE
    private float timer;


    public override void Start()
    {
        base.Start();

        timer = 0f;

        //Set duration to en end of state
        if (waitToEndOfStateClips)
            timeToWait = GetComponent<NavigationState>().duration;
    }


    public override void Update()
    {
        base.Update();

        if (!Application.isPlaying)
        {
            //Set duration to en end of state
            if (waitToEndOfStateClips)
                timeToWait = GetComponent<NavigationState>().duration;
        }
        else
        {
            if (isActive)
            {
                timer += Time.deltaTime;
                if (timer >= timeToWait)
                {
                    KeyAudioManager keyAudioManager = FindObjectOfType<KeyAudioManager>();
                    InterfaceManager interfaceManager = FindObjectOfType<InterfaceManager>();
                    keyAudioManager.audioSource.Stop();
                    interfaceManager.GoToNormalInterface();
                    NavigationManager.instance.reset();
                    PlayerProfile.instance.reset();
                }
            }
        }

    }

    public override void activate()
    {
        base.activate();

        timer = 0f;

    }

    public override void deactivate()
    {
        base.deactivate();
    }

    public override void receiveInput(string input)
    {

    }
}
