using UnityEngine;
using System.Collections;

public class ButtonCallManager : MonoBehaviour 
{
	public GameObject buttonCall;
	public GameObject buttonUncall;

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
		buttonCall.SetActive (!isPlayerInACall);
		buttonUncall.SetActive (isPlayerInACall);

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
