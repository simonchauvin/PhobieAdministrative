using UnityEngine;
using System.Collections;

public class NavigationManager : MonoBehaviour {

    private static NavigationManager _instance;


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

    }


    void Update()
    {

    }
}
