using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GUICleanUp : MonoBehaviour {

	// Update is called once per frame
	public void CleanUp () {
	    foreach(Transform child in transform)
        {
            DestroyImmediate(child);
        }
	}
}
