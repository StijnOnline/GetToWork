using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading.Tasks;

public class ReplaceToolWindow : EditorWindow {

    private GameObject targetObject = null;
    private Vector3 positionOffset = Vector3.zero;
    private Vector3 rotationOffset = Vector3.zero;
    private float scaleMultiplier = 1f;
    private string responseText;

    [MenuItem("Window/Replace Selection")]
    static void Init() {
        ReplaceToolWindow window = (ReplaceToolWindow)EditorWindow.GetWindow(typeof(ReplaceToolWindow));
    }

    void OnGUI() {
        targetObject = (GameObject)EditorGUILayout.ObjectField(targetObject, typeof(GameObject));
        positionOffset = EditorGUILayout.Vector3Field("Position Offset", positionOffset);
        rotationOffset = EditorGUILayout.Vector3Field("Rotation Offset", rotationOffset);
        scaleMultiplier = EditorGUILayout.FloatField("Scale Multiplier", scaleMultiplier);

        if(GUILayout.Button("Replace Selection")) {
            responseText = Replace();

            ResetResponseText();
        }
        GUILayout.Label(responseText);
    }

    string Replace() {
        if(targetObject == null)
            return "Target object not set correctly";
        if(Selection.transforms.Length == 0)
            return "No objects Selected";

        foreach(GameObject referenceObject in Selection.gameObjects) {
            //Create New

            Vector3 globalPostionOffset = Vector3.zero;
            globalPostionOffset += referenceObject.transform.forward * positionOffset.z;
            globalPostionOffset += referenceObject.transform.right * positionOffset.x;
            globalPostionOffset += referenceObject.transform.up * positionOffset.y;

            GameObject created = Instantiate(targetObject,referenceObject.transform.position + globalPostionOffset, referenceObject.transform.rotation * Quaternion.Euler(rotationOffset));
            created.transform.localScale *= scaleMultiplier;
            Undo.RegisterCreatedObjectUndo(created,"Created Replacement");

            Undo.DestroyObjectImmediate(referenceObject);
        }

        return "Objects Replaced";
    }

    async void ResetResponseText() {
        await Task.Delay(600);
        responseText = "";
    }
}
