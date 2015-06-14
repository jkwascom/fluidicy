using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TransformTracker))]
public class TransformTrackerEditor : Editor
{
	
	public override void OnInspectorGUI()
	{
		TransformTracker myTarget = (TransformTracker)target;
		int count = 0;
		foreach (var item in myTarget.storedTransforms) {

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Position " + (++count).ToString());
			if(GUILayout.Button("Load")){
				myTarget.LoadStored(item);
			}
			if(GUILayout.Button("Delete")){
				myTarget.DeleteStored(item);
				EditorUtility.SetDirty(target);
			}
			EditorGUILayout.EndHorizontal();
		}

		if(GUILayout.Button("Save")){
			myTarget.SaveCurrent();
			EditorUtility.SetDirty(target);
		}
		
		//myTarget.experience = EditorGUILayout.IntField("Experience", myTarget.experience);
		//EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
	}
}

