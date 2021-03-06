﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigationManager : MonoBehaviour {

    private static NavigationManager _instance;

    // PUBLIC
    public NavigationState startingState;

    private AudioSource[] audioSources;
    public AudioSource audioBgSrc { get { return audioSources[0];}}
    public AudioSource audioClipsSrc { get { return audioSources[1];}}
    

    // PRIVATE
    private List<NavigationState> historic;
    private NavigationState currentState;


    //Arrows size
    public float arrowSize = 0.2f;
    public float labelOffset = 0.1f;

    public static NavigationManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("NavigationManager").GetComponent<NavigationManager>();
            }
            return _instance;
        }
    }

    void Start()
    {
        // Init
        audioSources = GetComponents<AudioSource>();

        historic = new List<NavigationState>();
        if (startingState == null)
        {
            Debug.LogError("You need to choose a starting state");
        }
    }

    public void init ()
    {
        currentState = startingState;
        currentState.activate();
    }

    void Update()
    {

    }

    public void switchState (NavigationState stateToSwitchTo)
    {
        historic.Add(currentState);
        currentState = stateToSwitchTo;
    }

    public void sendInput (string characterToSend)
    {
        currentState.receiveInput(characterToSend);
    }

    public void reset ()
    {
        currentState.deactivate();
        currentState = null;
        historic = new List<NavigationState>();
    }
}
