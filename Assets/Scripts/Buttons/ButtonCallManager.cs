using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonCallManager : MonoBehaviour 
{
	public Image buttonCall;
	public Image buttonUncall;

	public GameObject receiveCallUI;
	public GameObject giveCallUI;

	public bool isPlayerInACall;
	public bool isPlayerGiveTheCall;

	void Start ()
	{
		SetCallButtons ();
	}

	public void SetCallButtons ()
	{
		buttonCall.enabled = !isPlayerInACall;
		buttonUncall.enabled = isPlayerInACall;

		if (isPlayerInACall)
		{
			receiveCallUI.SetActive (!isPlayerGiveTheCall);
			giveCallUI.SetActive (isPlayerGiveTheCall);
		}
		else
		{
			receiveCallUI.SetActive (isPlayerInACall);
			giveCallUI.SetActive (isPlayerInACall);
		}
	}
}
