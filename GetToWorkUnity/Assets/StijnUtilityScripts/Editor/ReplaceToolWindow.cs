using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading.Tasks;

public class ReplaceToolWindow : EditorWindow {

    
    private Object prefab = null;
    private GameObject originalObject = null;
    private GameObject replacedObject = null;
    private string newTag;
    private bool tagChildren;
    private int newLayer;
    private bool layerChildren;
    private bool keepParent;

    [MenuItem("Window/Replace Tool")]
    static void Init() {
        ReplaceToolWindow window = (ReplaceToolWindow)EditorWindow.GetWindow(typeof(ReplaceToolWindow));
    }

    void OnGUI() {
        GUILayout.Label("Copy Replace", EditorStyles.boldLabel);
        GUILayout.Label(
@"With this tool you only have to manually replace one object, this same action can then be used on multiple objects. This can be used to replace blockout objects into high poly models for example. This action is Undo-able.
1. Drag an object that needs to be replaced in the 'Original Object' field
2. Place a replacement object in the right position as if it were to replace the original object
3. Drag this object in the 'Replaced Object' field
4. Select other similar objects in the world that need to be replaced
5. Press the 'Replace Selection' button"
            , EditorStyles.wordWrappedLabel);
        prefab = EditorGUILayout.ObjectField("Prefab",prefab, typeof(GameObject),false);
        originalObject = (GameObject)EditorGUILayout.ObjectField("Original Object", originalObject, typeof(GameObject), true);
        replacedObject = (GameObject)EditorGUILayout.ObjectField("Replaced Object", replacedObject, typeof(GameObject),true);
        keepParent = EditorGUILayout.Toggle("Keep parent", keepParent);
        EditorGUILayout.Space(10);
        newTag = EditorGUILayout.TagField("New Tag", newTag);
        tagChildren = EditorGUILayout.Toggle("Tag all children", tagChildren);
        newLayer = EditorGUILayout.LayerField("New Layer", newLayer);
        layerChildren = EditorGUILayout.Toggle("Set layer of all children", layerChildren);
        
        if(GUILayout.Button("Replace Selection")) {
            CopyReplace();
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
            GameObject created = (GameObject) PrefabUtility.InstantiatePrefab(prefab);
            created.transform.rotation = referenceObject.transform.rotation * relativeRotation;
            created.transform.position = referenceObject.transform.position + referenceObject.transform.TransformDirection(relativePositionOffset);
            created.transform.localScale = replacedObject.transform.localScale;

            created.layer = newLayer;
            if(layerChildren) {
                foreach(Transform child in created.transform) {
                    child.gameObject.layer = newLayer;
                }
            }

            created.tag = newTag;
            if(tagChildren) {
                foreach(Transform child in created.transform) {
                    child.tag = newTag;
                }
            }

            created.transform.SetParent(referenceObject.transform.parent);

            Undo.RegisterCreatedObjectUndo(created, "Created Replacement");
            Undo.DestroyObjectImmediate(referenceObject);
        }
    }
}
