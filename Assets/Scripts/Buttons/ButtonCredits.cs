using UnityEngine;
using System.Collections;

public class ButtonCredits : MonoBehaviour 
{
	public GameObject creditsUI;
	private bool isInCredits;

	void Start ()
	{
		SetCreditsWindow ();
	}

	public void Credits ()
	{
		isInCredits = !isInCredits;
		SetCreditsWindow ();
	}

	private void SetCreditsWindow ()
	{
		creditsUI.SetActive (isInCredits);
	}
}
