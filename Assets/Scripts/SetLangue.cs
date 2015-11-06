using UnityEngine;
using System.Collections;

public class SetLangue : MonoBehaviour 
{
	public string startLangue;
	public string currentLangue;

	public void SetFrench ()
	{
		currentLangue = "French";
	}

	public void SetEnglish ()
	{
		currentLangue = "English";
	}
}
