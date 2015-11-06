using UnityEngine;
using System.Collections;

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
	/// The line renderer.
	/// </summary>
	private LineRenderer lineRenderer;

	/// <summary>
	/// The color of the line.
	/// </summary>
	public Color lineColor;

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

		lineRenderer = GetComponent<LineRenderer>();
		if(lineRenderer == null)
			Debug.LogError("You must attach a lineRenderer to a NaviationBehaviour.");

		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(lineColor, Color.white);
		lineRenderer.SetWidth(0.2F, 0.05F);
		lineRenderer.SetVertexCount(2);
			
	}


	public virtual void Update()
	{
		updateLineRenderer();
	}
	
    public void activate ()
    {
        isActive = true;
    }

    public void deactivate()
    {
        isActive = false;
    }

	/// <summary>
	/// Updates the line renderer.
	/// </summary>
	public void updateLineRenderer()
	{
		lineRenderer.SetColors(lineColor, Color.white);
		lineRenderer.SetWidth(0.25F, 0.02F);
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
	/// Receives the input.
	/// </summary>
	/// <param name="input">Input.</param>
	public virtual void receiveInput(string input)
	{

	}


}
