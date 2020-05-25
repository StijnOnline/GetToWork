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

    private GameObject originalObject = null;
    private GameObject replacedObject = null;

    [MenuItem("Window/Replace Tool")]
    static void Init() {
        ReplaceToolWindow window = (ReplaceToolWindow)EditorWindow.GetWindow(typeof(ReplaceToolWindow));
    }

    void OnGUI() {


        GUILayout.Label("Simple Replace", EditorStyles.boldLabel);
        targetObject = (GameObject)EditorGUILayout.ObjectField(targetObject, typeof(GameObject));
        positionOffset = EditorGUILayout.Vector3Field("Position Offset", positionOffset);
        rotationOffset = EditorGUILayout.Vector3Field("Rotation Offset", rotationOffset);
        scaleMultiplier = EditorGUILayout.FloatField("Scale Multiplier", scaleMultiplier);

        if(GUILayout.Button("Replace Selection")) {
            SimpleReplace();
        }

        GUILayout.Space(20);
        GUILayout.Label("Copy Replace", EditorStyles.boldLabel);
        GUILayout.Label(
@"With this tool you only have to manually replace one object, this same action can then be used on multiple objects. This can be used to replace blockout objects into high poly models for example. This action is Undo-able.
1. Drag an object that needs to be replaced in the 'Original Object' field
2. Place a replacement object in the right position as if it were to replace the original object
3. Drag this object in the 'Replaced Object' field
4. Select other similar objects in the world that need to be replaced
5. Press the 'Replace Selection' button"
            , EditorStyles.wordWrappedLabel);
        originalObject = (GameObject)EditorGUILayout.ObjectField("Original Object", originalObject, typeof(GameObject));
        replacedObject = (GameObject)EditorGUILayout.ObjectField("Replaced Object", replacedObject, typeof(GameObject));
        if(GUILayout.Button("Replace Selection")) {
            CopyReplace();
        }
    }

    void SimpleReplace() {
        if(targetObject == null)
            return;
        if(Selection.transforms.Length == 0)
            return;

        foreach(GameObject referenceObject in Selection.gameObjects) {
            //Create New
            Vector3 globalPostionOffset = referenceObject.transform.TransformDirection(positionOffset);
            GameObject created = Instantiate(targetObject,referenceObject.transform.position + globalPostionOffset, referenceObject.transform.rotation * Quaternion.Euler(rotationOffset));
            created.transform.localScale *= scaleMultiplier;
            Undo.RegisterCreatedObjectUndo(created,"Created Replacement");
            Undo.DestroyObjectImmediate(referenceObject);
        }
    }

    void CopyReplace() {
        if(originalObject == null) {
            Debug.LogError("Replace Tool Error: original object unknown");
            return;
        }
        if(replacedObject == null) {
            Debug.LogError("Replace Tool Error: replaced object unknown");
            return;
        }
        if(Selection.transforms.Length == 0) {
            Debug.LogError("Replace Tool Error: nothing selected");
            return;
        }

        Quaternion relativeRotation = Quaternion.Inverse(originalObject.transform.rotation) * replacedObject.transform.rotation;
        Vector3 globalPositionOffset = replacedObject.transform.position - originalObject.transform.position;
        Vector3 relativePositionOffset = originalObject.transform.InverseTransformDirection(globalPositionOffset);

        foreach(GameObject referenceObject in Selection.gameObjects) {
            //Create New
            GameObject created = Instantiate(replacedObject);
            created.transform.rotation = referenceObject.transform.rotation * relativeRotation;
            created.transform.position = referenceObject.transform.position + referenceObject.transform.TransformDirection(relativePositionOffset);
            created.transform.localScale = replacedObject.transform.localScale;
            Undo.RegisterCreatedObjectUndo(created, "Created Replacement");
            Undo.DestroyObjectImmediate(referenceObject);
        }
    }
}
