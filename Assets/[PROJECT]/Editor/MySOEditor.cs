using UnityEngine;
using UnityEditor;

public class MySOEditor : Editor
{
    SerializedProperty myConcreteObjectsProp;

    private void OnEnable()
    {
        myConcreteObjectsProp = serializedObject.FindProperty("skillRoots");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(myConcreteObjectsProp, true);

        serializedObject.ApplyModifiedProperties();
    }
}
