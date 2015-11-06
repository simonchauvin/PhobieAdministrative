using UnityEngine;
using System.Collections;

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
	/// The line renderer.
	/// </summary>
	private LineRenderer lineRenderer;

	/// <summary>
	/// The is active.
	/// </summary>
	public bool isActive {get; private set;}

	/// <summary>
	/// The color of the line.
	/// </summary>
	public Color lineColor;

	/// <summary>
	/// Init
	/// </summary>
	void Start()
	{
		parentNavigationState = GetComponent<NavigationState>();
		if(parentNavigationState == null)
			Debug.LogError("A navigation state must be attached to " + name + " for the navigationbehaviour to work.");

		if(targetNavigationState == null)
			Debug.LogError("A navigation state target must be specified.");


		lineRenderer = GetComponent<LineRenderer>();
		if(lineRenderer == null)
			Debug.LogError("You must attach a lineRenderer to a NaviationBehaviour.");

		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(lineColor, lineColor);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.SetVertexCount(2);
			
	}

	void Update()
	{
		//updateLineRenderer();
	}
	
	/// <summary>
	/// Updates the line renderer.
	/// </summary>
	public void updateLineRenderer()
	{
		lineRenderer.SetPosition(0, transform.position);
		lineRenderer.SetPosition(1, targetNavigationState.transform.position);
	}

	/// <summary>
	/// Navigates to target.
	/// </summary>
	public void navigateToTarget()
	{
		parentNavigationState.deactivate();
		targetNavigationState.activate();
	}

	/// <summary>
	/// Activate this instance.
	/// </summary>
	public void activate()
	{
		isActive = true;
	}

	/// <summary>
	/// Deactivate this instance.
	/// </summary>
	public void deactivate()
	{
		isActive = false;
	}

}
