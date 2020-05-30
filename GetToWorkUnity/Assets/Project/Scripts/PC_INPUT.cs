using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_INPUT : MonoBehaviour
{

    [SerializeField] private Transform steer = null;
    [SerializeField] private SteerInput steerInput = null;
    [SerializeField] private float PC_STEERSPEED = 1;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
            GameManager.Instance.StartGame();
        steer.rotation *= Quaternion.Euler(PC_STEERSPEED * Input.GetAxis("Horizontal"), 0, 0);

        steerInput.SetBrake( Input.GetKey(KeyCode.Space) ? 1f : 0f);
        steerInput.SetBoost( Input.GetKey(KeyCode.LeftShift) ? 1f : 0f);
    }
}