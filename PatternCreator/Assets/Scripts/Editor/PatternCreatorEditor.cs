using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PatternCreator))]
public class PatternCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        PatternCreator myTarget = (PatternCreator)target;

        if(GUILayout.Button("Create Pattern"))
        {
            myTarget.CreatePattern();
        }
    }
}
