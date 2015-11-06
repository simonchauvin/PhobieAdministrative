using UnityEngine;
using System.Collections;

public class ButtonUncall : MonoBehaviour 
{
	private ButtonCall buttonCall;

	void Start ()
	{
		buttonCall = FindObjectOfType<ButtonCall>();
	}

	public void Uncall ()
	{
		buttonCall.audioSource.Stop ();
	}
}
