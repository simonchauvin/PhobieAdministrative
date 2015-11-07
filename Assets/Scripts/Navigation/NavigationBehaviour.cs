﻿using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif


[ExecuteInEditMode]
public class NavigationBehaviour : MonoBehaviour {

	/// <summary>
	/// parent navigation.
	/// </summary>
	private NavigationState parentNavigationState;

	/// <summary>
	/// target navigation.
	/// </summary>
	public NavigationState targetNavigationState;

    /// <summary>
    /// 
    /// </summary>
    public GameObject arrowPrefab;
    private GameObject arrow;

	/// <summary>
	/// The color of the line.
	/// </summary>
	public Color lineColor = Color.cyan;

    /// <summary>
    /// Whether the state is active or not.
    /// </summary>
    public bool isActive { get; set; }


	/// <summary>
	/// Init
	/// </summary>
	public virtual void Start()
	{
		parentNavigationState = GetComponent<NavigationState>();
		if(parentNavigationState == null)
			Debug.LogError("A navigation state must be attached to " + name + " for the navigationbehaviour to work.");

		if(targetNavigationState == null)
			Debug.LogError("A navigation state target must be specified.");

        arrow = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject;
        arrow.name = "arrow_" + name;
        arrow.transform.parent = GameObject.Find("GUIArrows").transform;
    }


    public virtual void Update()
    {
        //ARROW AND LINE
        Vector3 targetPos = targetNavigationState.transform.position;
        Vector3 dir = targetPos - transform.position;
        Vector3 halfPosition = transform.position + dir * 0.5f;

        //Check
        if (arrow == null)
        {
            arrow = Instantiate(arrowPrefab, halfPosition, transform.rotation) as GameObject;
            arrow.name = "arrow_" + name;
            arrow.transform.parent = GameObject.Find("GUIArrows").transform;
        }

        float size = NavigationManager.instance.arrowSize;
        arrow.transform.localScale = new Vector3(size, size, size);
        arrow.transform.position = halfPosition;
        arrow.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
        arrow.GetComponent<SpriteRenderer>().color = lineColor;

        Debug.DrawLine(transform.position, targetPos, lineColor);

        //TEXTS
        //Vector3 offsettedPosition = transform.position + dir * NavigationManager.instance.labelOffset;
        //
    }


//#if UNITY_EDITOR
//    public void OnSceneGUI()
//	{
//        Debug.Log("on scene gui");
//        Vector3 targetPos = targetNavigationState.transform.position;
//        Vector3 dir = targetPos - transform.position;
//        Vector3 offsettedPosition = transform.position + dir * NavigationManager.instance.labelOffset;
//        Handles.Label(offsettedPosition, "NAME : " + name);
//    }
//#endif

    public virtual void activate ()
    {
        isActive = true;
    }

    public virtual void deactivate()
    {
        isActive = false;
    }


    /// <summary>
    /// Navigates to target.
    /// </summary>
    public void navigateToTarget()
	{
		parentNavigationState.deactivate();
		targetNavigationState.activate();
        NavigationManager.instance.switchState(targetNavigationState);
	}

	/// <summary>
	/// Receives the input.
	/// </summary>
	/// <param name="input">Input.</param>
	public virtual void receiveInput(string input)
	{

	}


}
