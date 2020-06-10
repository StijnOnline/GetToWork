using System;
using UnityEngine;

public class SineMovement: MonoBehaviour
{
    [SerializeField] private SineData xPos;
    [SerializeField] private SineData yPos;
    [SerializeField] private SineData zPos;

    [SerializeField] private SineData xScale;
    [SerializeField] private SineData yScale;
    [SerializeField] private SineData zScale;


    private float timeOffset;
    private Vector3 startPos;
    private Vector3 startScale;

    [Serializable]
    class SineData {
        public float Minimum = -1f;
        public float Maximum = 1f;
        public float TimeOffset = 0f;
        public float TimeScale = 1f;
    }

    private void Start() {
        startPos = transform.position;
        startScale = transform.localScale;
        timeOffset = UnityEngine.Random.Range(0f, 2f * Mathf.PI );
    }

    private void Update() {
        Vector3 newPos = startPos;
        newPos.x += ((Mathf.Sin((Time.time + timeOffset + xPos.TimeOffset) * xPos.TimeScale) + 1f) / 2f * (xPos.Maximum - xPos.Minimum)) + xPos.Minimum;
        newPos.y += ((Mathf.Sin((Time.time + timeOffset + yPos.TimeOffset) * yPos.TimeScale) + 1f) / 2f * (yPos.Maximum - yPos.Minimum)) +yPos.Minimum;
        newPos.z += ((Mathf.Sin((Time.time + timeOffset + zPos.TimeOffset) * zPos.TimeScale) + 1f) / 2f * (zPos.Maximum - zPos.Minimum)) +zPos.Minimum;
        transform.position = newPos;

        Vector3 newScale = startScale;
        newScale.x += ((Mathf.Sin((Time.time + timeOffset + xScale.TimeOffset) * xScale.TimeScale) + 1f) / 2f * (xScale.Maximum - xScale.Minimum)) + xScale.Minimum;
        newScale.y += ((Mathf.Sin((Time.time + timeOffset + yScale.TimeOffset) * yScale.TimeScale) + 1f) / 2f * (yScale.Maximum - yScale.Minimum)) + yScale.Minimum;
        newScale.z += ((Mathf.Sin((Time.time + timeOffset + zScale.TimeOffset) * zScale.TimeScale) + 1f) / 2f * (zScale.Maximum - zScale.Minimum)) + zScale.Minimum;
        transform.localScale = newScale;
    }
}
