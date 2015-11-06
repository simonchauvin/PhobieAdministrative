using UnityEngine;
using System.Collections;

public class ButtonErase : MonoBehaviour 
{
	private TextScreen textScreen;

	void Start ()
	{
		textScreen = FindObjectOfType<TextScreen>();
	}

	public void Erase ()
	{
		print ("erase");
		textScreen.textComposedNumber = null;
		textScreen.RefreshText ();
	}
}
