using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonNumber : MonoBehaviour 
{
	private KeyAudioManager keyAudioManager;
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
		keyAudioManager = FindObjectOfType<KeyAudioManager>();
	}

	public void TapButton ()
	{
		textScreen.textComposedNumber = textScreen.thisText.text + currentNumber;
		textScreen.RefreshText ();
		PlaySFX ();

        NavigationManager.instance.sendInput(currentNumber);
	}

	public void PlaySFX ()
	{
		switch (currentNumber)
		{
			case "1" :
				keyAudioManager.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[0]);
				break;

			case "2" :
				keyAudioManager.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[1]);
				break;

			case "3" :
				keyAudioManager.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[2]);
				break;

			case "4" :
				keyAudioManager.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[3]);
				break;

			case "5" :
				keyAudioManager.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[4]);
				break;

			case "6" :
				keyAudioManager.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[5]);
				break;

			case "7" :
				keyAudioManager.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[6]);
				break;

			case "8" :
				keyAudioManager.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[7]);
				break;

			case "9" :
				keyAudioManager.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[8]);
				break;

			case "0" :
				keyAudioManager.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[9]);
				break;

			case "*" :
				keyAudioManager.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[10]);
				break;

			case "#" :
				keyAudioManager.audioSource.PlayOneShot (buttonNumberSFX.audioClipsList[11]);
				break;
		}
	}
}
