using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(NavigationBehaviour))]
public class NavigationBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }

    
    void OnSceneGUI()
    {
        NavigationBehaviour myTarget = (NavigationBehaviour)target;
        Vector3 dir = myTarget.targetNavigationState.transform.position - myTarget.transform.position;

        Handles.Label(myTarget.transform.position + dir * 0.5f, typeof(NavigationBehaviour).ToString());
    }

}