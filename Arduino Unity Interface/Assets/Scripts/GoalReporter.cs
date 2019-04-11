using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalReporter : MonoBehaviour
{
    [SerializeField] ArduinoInputOutput inputOutput;
    [SerializeField] string goalString = "";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inputOutput.SendOutput(goalString);
        }
    }
}
