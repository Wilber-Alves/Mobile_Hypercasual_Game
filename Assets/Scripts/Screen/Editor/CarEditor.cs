using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Car))]

public class CarEditor : Editor
{
    override public void OnInspectorGUI()
    {
        Car myTarget = (Car)target;
        myTarget.speed = EditorGUILayout.IntField("Speed", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("Gear", myTarget.gear);

        EditorGUILayout.LabelField("Total Speed", myTarget.TotalSpeed.ToString());
        EditorGUILayout.HelpBox("This is a custom editor for the Car class. " +
            "It allows you to edit the speed and gear properties, " +
            "and it also displays the total speed " +
            "calculated from those properties.", MessageType.Info);

        if(myTarget.TotalSpeed > 200)
        {
            EditorGUILayout.HelpBox("The total speed is quite high! " +
                "Make sure to adjust the speed and gear accordingly.", MessageType.Warning);
        }
    }
}
