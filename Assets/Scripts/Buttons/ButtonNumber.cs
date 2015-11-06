using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonNumber : MonoBehaviour 
{
	private TextScreen textScreen;
	private GameObject childText;
	private Text buttonText;
	private string currentNumber;

	void Start ()
	{
		textScreen = FindObjectOfType<TextScreen>();
		childText = transform.GetChild (0).gameObject;
		currentNumber = childText.GetComponent<Text>().text;
	}

	public void TapButton ()
	{
		//print (currentNumber);
		textScreen.textComposedNumber = textScreen.thisText.text + currentNumber;
		textScreen.RefreshText ();

        NavigationManager.instance.sendInput(currentNumber);
	}
}
