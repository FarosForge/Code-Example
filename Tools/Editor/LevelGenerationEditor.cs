using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelGeneration))]
public class LevelGenerationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelGeneration gen = (LevelGeneration)target;

        if(GUILayout.Button("Generate Level"))
        {
            gen.Generate();
        }
        if (GUILayout.Button("Reset Level"))
        {
            gen.Reset();
        }
    }
}
