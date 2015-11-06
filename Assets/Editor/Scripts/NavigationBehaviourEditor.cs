using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(NavigationBehaviour))] 
public class NavigationBehaviourEditor : Editor {

	public override void OnInspectorGUI() 
	{
		NavigationBehaviour script = (NavigationBehaviour) target;
		DrawDefaultInspector();
	}
}
