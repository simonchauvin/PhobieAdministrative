using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonNumber : MonoBehaviour 
{
	private ButtonCall buttonCall;
	private ButtonNumberSFX buttonNumberSFX;
	private TextScreen textScreen;
	private GameObject childText;
	private Text buttonText;
	private string currentNumber;

	void Start ()
	{
		textScreen = FindObjectOfType<TextScreen>();
		childText = transform.GetChild (0).gameObject;
		currentNumber = childText.GetComponent<Text>().text;
		buttonNumberSFX = FindObjectOfType<ButtonNumberSFX>();
		buttonCall = FindObjectOfType<ButtonCall>();
	}

	public void TapButton ()
	{
		textScreen.textComposedNumber = textScreen.thisText.text + currentNumber;
		textScreen.RefreshText ();
		PlaySFX ();
	}

	public void PlaySFX ()
	{
		switch (currentNumber)
		{
			case "1" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[0]);
				break;

			case "2" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[1]);
				break;

			case "3" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[2]);
				break;

			case "4" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[3]);
				break;

			case "5" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[4]);
				break;

			case "6" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[5]);
				break;

			case "7" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[6]);
				break;

			case "8" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[7]);
				break;

			case "9" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[8]);
				break;

			case "0" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[9]);
				break;

			case "*" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[10]);
				break;

			case "#" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[11]);
				break;

			case "13" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[12]);
				break;

			case "14" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[13]);
				break;

			case "15" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[14]);
				break;

			case "16" :
				buttonCall.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[15]);
				break;
		}
	}
}
