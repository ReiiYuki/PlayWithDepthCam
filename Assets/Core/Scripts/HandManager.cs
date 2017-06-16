using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Intel.RealSense;
using Intel.RealSense.Hand;

public class HandManager : MonoBehaviour {

    // Hand Manger Component
    HandModule handModule;
    HandConfiguration handConfiguration;
    HandData handData;
    
    // Tag for Log
    string TAG = "Hand Manager : ";
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Activate Hand Module
    public void SetupHandModule(SenseManager senseManager)
    {
        handModule = HandModule.Activate(senseManager);
        if (handModule == null)
            Debug.Log(TAG + "Failed Loading Hand Module");
        else
        {
            Debug.Log(TAG + "Hand Module is loaded successful");
            SetupHandConfiguration();
        }
    }

    // Setup Hand Configuration
    void SetupHandConfiguration()
    {
        handConfiguration = handModule.CreateActiveConfiguration();
        if (handConfiguration == null)
            Debug.Log(TAG + "Failed Creating Hand Configuration");
        else
        {
            Debug.Log(TAG + "Successful Creating Hand Configuration");
            CreateHandData();
        }
    }

    void CreateHandData()
    {
        handData = handModule.CreateOutput();
        if (handData == null)
            Debug.Log(TAG + "Failed to create output");
        else
        {
            Debug.Log(TAG + "Successful to create output");

        }
    }
}
