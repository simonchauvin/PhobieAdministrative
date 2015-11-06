using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigationManager : MonoBehaviour {

    private static NavigationManager _instance;

    
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
        historic = new List<NavigationState>();
    }


    void Update()
    {

    }

    public void switchState (NavigationState stateToSwitchTo)
    {
        historic.Add(currentState);
        currentState = stateToSwitchTo;
    }
}
