using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class only works if you have an ArduinoInput class on the same GameObject
[RequireComponent(typeof(ArduinoInputOutput))]
public class LeftAndRightMovement : MonoBehaviour
{

    ArduinoInputOutput arduinoInput;
    public float speed = 1.0f;

    void Start()
    {
        arduinoInput = GetComponent<ArduinoInputOutput>();
    }

    void Update()
    {
        string lastInput = arduinoInput.GetInput();

        if (lastInput == "L")
        {
            Debug.Log("Read " + lastInput);
            transform.Translate(Vector3.right * speed);
        }
        else if (lastInput == "R")
        {
            Debug.Log("Read " + lastInput);
            transform.Translate(Vector3.left * speed);
        }
        else if (lastInput != "")
        {
            Debug.Log("Read " + lastInput);
        }
    }
}
