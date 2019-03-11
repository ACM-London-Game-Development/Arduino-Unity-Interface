# Arduino-Unity-Interface

A basic Unity script interface that opens a serial port for communicating with an Arduino that is running a sketch similar to this

https://create.arduino.cc/editor/DsharrockACM/0ec242b3-be66-4bff-a106-e55195c35703/preview

Contents:

ArduinoInput.cs - The main script that monitors and reads lines from a serial port and returns strings on request via <code>public string GetInput()</code>

SampleScene.unity - A basic scene with a GameObject with an ArduinoInput component on it

DebugWriter.cs - Awaits a press of the spacebar then calls the <code>GetInput()</code> method and writes the result to the console

LeftAndRightMovement.cs - An example of how to convert short string outputs from Arduino into basic object movement. Polls <code>GetInput()</code> continuously so denies any input to DebugWriter.
