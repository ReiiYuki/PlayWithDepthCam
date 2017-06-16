using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Intel.RealSense;
using Intel.RealSense.Hand;

public class DepthCameraManger : MonoBehaviour {

    /**
     * Depth Camera Component
     **/
    SenseManager senseManager;
    CaptureManager captureManager;
    DeviceInfo deviceInfo;
    HandConfiguration handConfiguration;

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
            LoadCapture();
        }
    }

    // Load Capture from Group Sensor Info
    void LoadCapture()
    {
        ImplDesc desc = new ImplDesc()
        {
            group = ImplGroup.IMPL_GROUP_SENSOR,
            subgroup = ImplSubgroup.IMPL_SUBGROUP_VIDEO_CAPTURE
        };
        Capture capture;
        if (senseManager.Session.CreateImpl<Capture>(senseManager.Session.QueryImpl(desc, 0), out capture) < Status.STATUS_NO_ERROR)
            Debug.Log(TAG + "Initialize Capture Failure!");
        else
        {
            if (capture == null || capture.DeviceInfo == null)
                Debug.Log(TAG+"No Capture Connected!");
            else if (capture.DeviceInfo.Length == 0)
                Debug.Log(TAG + "No Camera Connected!");
            else
            {
                CaptureDevice(capture);
            }
        }
    }

    // Capture Device
    void CaptureDevice(Capture capture)
    {
        deviceInfo = capture.DeviceInfo[0];
        if (deviceInfo == null)
            Debug.Log(TAG + "Fail to obtain camera!");
        else
        {
            if (captureManager.SetFileName(deviceInfo.name, true) < Status.STATUS_NO_ERROR)
                Debug.Log(TAG + "Fail to connect to " + deviceInfo.name);
            else
            {
                Debug.Log(TAG + "Connect to " + deviceInfo.name);
                SetupHandModule();
            }
        }
    }

    // Activate Hand Module
    void SetupHandModule()
    {
        HandModule handModule = HandModule.Activate(senseManager);
        if (handModule == null)
            Debug.Log(TAG + "Failed Loading Hand Module");
        else
        {
            Debug.Log(TAG + "Hand Module is loaded successful");
            SetupHandConfiguration(handModule);
        }
    }

    // Setup Hand Configuration
    void SetupHandConfiguration(HandModule handModule)
    {
        handConfiguration = handModule.CreateActiveConfiguration();
        
    }
}
