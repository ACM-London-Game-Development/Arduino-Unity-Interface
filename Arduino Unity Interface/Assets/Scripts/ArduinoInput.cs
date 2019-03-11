using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// We need to add this reference to be able to use the SerialPort class
using System.IO.Ports;

public class ArduinoInput : MonoBehaviour
{
    // This variable will be used to refer to the port that our Arduino is available on.
    SerialPort arduinoPort;

    // These are the details of the connection that we wish to make to our Arduino. The port name and baud rate must match what we see and set in Arduino Create
    [SerializeField] string portName = "";
    [SerializeField] int baudRate = 9600;

    // The timeout setting for reading from the Arduino stream
    [SerializeField] int readTimeout = 10;

    // Used as a quicker reference to whether our port has been opened successfully or not
    bool portOpen = false;

    // User defined list of valid inputs from the IO stream
    public string[] validInputs = null;

    // Unbounded list of inputs that is pushed out to the calling class in a FIFO manner by default
    List<string> inputList = new List<string>();


    // GetInput returns the oldest input string from the input list
    public string GetInput()
    {
        string inputString = "";

        // Uncomment this to track the size of the input buffer vs output
        // Debug.Log("Input List Size is " + inputList.Count);

        if (inputList.Count > 0)
        {
            // Copy the oldest List item
            inputString = inputList[0];

            // Remove that item from the list
            inputList.RemoveAt(0);

            // Return the value
            return inputString;

        }
        
        return inputString;
    }

    void Awake()
    {
        // Set up our Serial Port with the given settings
        arduinoPort = new SerialPort(portName, baudRate);
        // Open that port
        arduinoPort.Open();

        // Check if the port is open or not
        if (arduinoPort.IsOpen)
        {
            portOpen = true;
            arduinoPort.ReadTimeout = readTimeout;
        }
        else
        {
            Debug.LogError("Unable to Open Port on " + portName);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (portOpen)
        {
            // Get the current input from the serial port stream
            string currentInput = GetRawInputLine();

            // If the input is valid, then we add it to our input list
            if (currentInput != "")
            {
                inputList.Add(currentInput);
            }
        }
    }

    string GetRawInputLine()
    {
        string myString = "";

        // This is wrapped in a Try/Catch as IO exceptions are common
        try
        {
            // Read in the next available line on the port
            myString = arduinoPort.ReadLine();

            // Trim any whitespace
            myString.Trim();

            // If myString is a valid Input, then return it
            foreach (string i in validInputs)
            {
                if (myString == i)
                {
                    return myString;
                }
            }

            // Otherwise set it back to an empty string to return
            myString = "";
        }
        catch (System.Exception)
        {
            // no-op, just to silence the timeouts. 
            // (my arduino sends 12-16 byte packets every 0.1 secs)
        }

        // If we're here, the Try.Catch failed or the string was invalid, so we'll be returning an empty string
        return myString;
    }


}
