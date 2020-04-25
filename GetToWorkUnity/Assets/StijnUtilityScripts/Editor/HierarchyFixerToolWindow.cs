using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HierarchyFixerToolWindow : EditorWindow {
    [MenuItem("Window/Hierarchy Fixer")]
    static void Init() {
        HierarchyFixerToolWindow window = (HierarchyFixerToolWindow)EditorWindow.GetWindow(typeof(HierarchyFixerToolWindow));
        //Debug.Log(StringCompare.findstem(new string[] {"test Boom","Boom 3 (Clone)","boomding"}));
        //Debug.Log(StringCompare.SimpleComparison("Boom", "Boom (3) (Clone)"));
    }

    void OnGUI() {
        GUILayout.Label("Testing");
        if(GUILayout.Button("Scan")) {
            List<GameObject> ObjectsToScan = new List<GameObject>();
            SceneManager.GetActiveScene().GetRootGameObjects(ObjectsToScan);


            ObjectGroup[] foundgroups = Scan(ObjectsToScan);


            foreach(var foundGroups in foundgroups) {
                Debug.Log("Group " + foundGroups.commonName);
                foreach(var groupObjects in foundGroups.objects) {
                    Debug.Log(groupObjects.name);
                }
            }
        }
    }

    private ObjectGroup[] Scan(List<GameObject> _objectsToScan) {

        List<GameObject> unsorted = new List<GameObject>();
        List<ObjectGroup> groups = new List<ObjectGroup>();

        while(unsorted.Count > 0) {
            bool Done = false;
            GameObject currentScanning = unsorted[0];
            unsorted.RemoveAt(0);

            foreach(var group in groups) {
                if(StringCompare.SimpleComparison(group.commonName, currentScanning.name)) {
                    group.objects.Add(currentScanning);
                    Done = true;
                    break;
                }
            }
            if(!Done) {
                foreach(var unsortedObject in unsorted) {
                    if(StringCompare.SimpleComparison(unsortedObject.name, currentScanning.name)) {
                        ObjectGroup newGroup = new ObjectGroup(StringCompare.ReduceName(currentScanning.name));
                        newGroup.objects.Add(currentScanning);
                        newGroup.objects.Add(unsortedObject);
                        unsorted.Remove(unsortedObject);
                        groups.Add(newGroup);
                        Done = true;
                        break;
                    }
                }
            }
        }

        return groups.ToArray();
    }

    class ObjectGroup {
        public string commonName { get; private set; }
        public List<GameObject> objects = new List<GameObject>();

        public ObjectGroup(string _commonName) {
            commonName = _commonName;
        }
    }
}
