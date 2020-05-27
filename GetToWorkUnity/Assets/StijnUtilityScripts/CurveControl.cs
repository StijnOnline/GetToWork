//Simple class to control your scene with curves using UnityEvents
//Made by Stijn van Deijzen

using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyCurveEvent : UnityEvent<float>{}

public class CurveControl : MonoBehaviour
{
    public AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 0);
    public MyCurveEvent curveEvent = new MyCurveEvent();

    void Update()
    {
        if (curveEvent != null)
        {
            curveEvent.Invoke(curve.Evaluate(Time.time));
        }
    }
}