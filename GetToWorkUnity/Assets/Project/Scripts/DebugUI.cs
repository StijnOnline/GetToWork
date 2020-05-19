using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private const string defaultText = "DEBUG";

    public void SetText(string text = defaultText) {
        textBox.SetText(textBox.text + text + "\n");
    }
}
