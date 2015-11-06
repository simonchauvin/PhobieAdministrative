using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigationManager : MonoBehaviour {

    private static NavigationManager _instance;

    // PUBLIC
    public NavigationState startingState;

    // PRIVATE
    private List<NavigationState> historic;
    private NavigationState currentState;


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
        historic = new List<NavigationState>();
        if (startingState == null)
        {
            Debug.LogError("You need to choose a starting state");
        }
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
}
