using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_INPUT : MonoBehaviour
{

    [SerializeField] private Transform steer = null;
    [SerializeField] private NewSteerInput steerInput = null;
    [SerializeField] private float PC_STEERSPEED = 1;

    private float Input_Hor = 0;
    private bool  Input_Brake = false;
    private bool Input_Boost = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
            GameManager.Instance.StartGame();
        Input_Hor = Input.GetAxis("Horizontal");

        Input_Brake = Input.GetKey(KeyCode.Space);
        Input_Boost = Input.GetKey(KeyCode.LeftShift) ;
    }

    void FixedUpdate() {

        steer.rotation *= Quaternion.Euler(PC_STEERSPEED * Input_Hor, 0, 0);

        steerInput.SetBrake(Input_Brake ? 1f : 0f);
        steerInput.SetBoost(Input_Boost ? 1f : 0f);
    }
}