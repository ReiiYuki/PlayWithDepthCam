using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Intel.RealSense;

public class GesturalDetection : MonoBehaviour {

    /**
     * Depth Camera Manager
     **/
    SenseManager senseManager;
    CaptureManager captureManager;

    // Tag for Log
    string TAG = "Depth Camera : ";

    //Call this before start
    void Awake()
    {
        InititalizeSenseManager();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Initialize Sense Manager
    void InititalizeSenseManager()
    {
        senseManager = Session.CreateInstance().CreateSenseManager();
        if (senseManager == null)
            Debug.Log(TAG+ "Sense Manager Initialize Failure!");
        else
        {
            Debug.Log(TAG + "Sense Manager Initialize Successful");
            InitializeCaptureManager();
        }
    }

    // Initialize Capture Manager
    void InitializeCaptureManager()
    {
        captureManager = senseManager.CaptureManager;
        if (captureManager == null)
            Debug.Log(TAG + "Capture Manager Initialize Failure!");
        else
        {
            Debug.Log(TAG + "Capture Manager Initialize Successful");

        }
    }


}
