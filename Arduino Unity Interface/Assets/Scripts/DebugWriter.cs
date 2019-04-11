using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class only works if you have an ArduinoInput class on the same GameObject
[RequireComponent(typeof(ArduinoInputOutput))]
public class DebugWriter : MonoBehaviour
{

    ArduinoInputOutput arduinoInput;

    void Start()
    {
        arduinoInput = GetComponent<ArduinoInputOutput>();
    }


    void Update()
    {
        // Whenever the Space Key is pressed, we output the latest line to the debug log
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string lastInput = arduinoInput.GetInput();
            if (lastInput != "")
            {
                Debug.Log("Last Input was " + lastInput);
            }
        }
    }
}
