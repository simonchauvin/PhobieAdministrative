using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScreen : MonoBehaviour 
{
	public Text thisText;
	public string textComposedNumber;

	void Start ()
	{
		thisText = GetComponent<Text>();
	}

	public void RefreshText ()
	{
		thisText.text = textComposedNumber;
	}
}
