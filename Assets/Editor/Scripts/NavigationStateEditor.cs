using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(NavigationState))]
public class NavigationStateEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }

    void OnSceneGUI()
    {
        NavigationState myTarget = (NavigationState)target;
        Vector3 pos = myTarget.transform.position;
        Handles.Label(pos, "-------->" + myTarget.name);

        myTarget.GetComponent<Renderer>().material.SetColor("_EmissionColor", myTarget.color);
    }

}
