﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEditor.EditorTools;

[EditorTool("Reposition Parent Tool")]
public class RepositionParentTool : EditorTool {

    [SerializeField]
    Texture2D m_ToolIcon;
    GUIContent m_IconContent;

    void OnEnable() {
        m_IconContent = new GUIContent() {
            image = m_ToolIcon,
            text = "Reposition Parent Tool",
            tooltip = "Reposition Parent Tool"
        };
    }

    public override GUIContent toolbarIcon {
        get { return m_IconContent; }
    }

    // This is called for each window that your tool is active in. Put the functionality of your tool here.
    public override void OnToolGUI(EditorWindow window) {
        EditorGUI.BeginChangeCheck();

        Vector3 position = Tools.handlePosition;

        using(new Handles.DrawingScope(Color.green)) {
            position = Handles.Slider(position, Vector3.right);
        }

        if(GUILayout.Button("Center")) {
        }

        if(EditorGUI.EndChangeCheck()) {
            Vector3 delta = position - Tools.handlePosition;

            Undo.RecordObjects(Selection.transforms, "Move Platform");

            foreach(var transform in Selection.transforms)
                transform.position += delta;
        }
    }
}
