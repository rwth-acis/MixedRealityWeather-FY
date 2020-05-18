using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapManager : MonoBehaviour
{
    SpeechInputHandler speechInputHandler;
    SolverHandler solverHandler;
    private void Start()
    {
        speechInputHandler = GetComponent<SpeechInputHandler>();
        solverHandler = GetComponent<SolverHandler>();

        //speechInputHandler.AddResponse("Snap", ToggleSnap);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            ToggleSnap();

    }

    public void ToggleSnap()
    {
        print("Snap Toggled");
        solverHandler.enabled = !solverHandler.enabled;
    }
}
