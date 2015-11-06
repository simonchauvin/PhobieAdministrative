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

    ///// <summary>
    ///// The line renderer.
    ///// </summary>
    //private LineRenderer lineRenderer;

    /// <summary>
    /// 
    /// </summary>
    public GameObject arrowPrefab;
    private GameObject arrow;

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

        //lineRenderer = GetComponent<LineRenderer>();
        //if(lineRenderer == null)
        //	Debug.LogError("You must attach a lineRenderer to a NaviationBehaviour.");
        //
        //
        //lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        //lineRenderer.SetColors(lineColor, Color.white);
        //lineRenderer.SetWidth(0.05F, 0.05F);
        //lineRenderer.SetVertexCount(2);

        arrow = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject;
    }


	public virtual void Update()
	{
		updateLineRenderer();
	}
	
    public virtual void activate ()
    {
        isActive = true;
    }

    public virtual void deactivate()
    {
        isActive = false;
    }

	/// <summary>
	/// Updates the line renderer.
	/// </summary>
	public void updateLineRenderer()
	{
        //lineRenderer.SetColors(lineColor, Color.white);
        //lineRenderer.SetWidth(0.25F, 0.02F);
        //lineRenderer.SetPosition(0, transform.position);
        //lineRenderer.SetPosition(1, targetNavigationState.transform.position);

        Vector3 targetPos = targetNavigationState.transform.position;
        Vector3 dir = targetPos - transform.position;
        Vector3 halfPosition = transform.position + dir * 0.5f;

        //Check
        if(arrow == null)
            arrow = Instantiate(arrowPrefab, halfPosition, transform.rotation) as GameObject;

        float size = NavigationManager.instance.arrowSize;
        arrow.transform.localScale = new Vector3(size, size, size);
        arrow.transform.position = halfPosition;
        arrow.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);

        //Color
        arrow.GetComponent<SpriteRenderer>().color = lineColor;

        Debug.DrawLine(transform.position, targetPos, lineColor);
       
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
