using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GUICleanUp))]
public class GUICleanUpEditor : Editor {

    public override void OnInspectorGUI()
    {
        GUICleanUp mytarget = (GUICleanUp)target;

        if (GUILayout.Button("Clean Up"))
        {
            mytarget.CleanUp();
        }
    }
}
