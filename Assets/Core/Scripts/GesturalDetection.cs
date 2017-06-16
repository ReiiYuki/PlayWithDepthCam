using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Intel.RealSense;

public class GesturalDetection : MonoBehaviour {

    SenseManager manager;
    string TAG = "Deptth Camera : ";
    void Awake()
    {
        InitSensor();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitSensor()
    {
        manager = Session.CreateInstance().CreateSenseManager();
        if (manager == null)
            Debug.Log(TAG+ "Sense Manager Connection Failure!");
        else
            Debug.Log(TAG+ "Sense ManagerConnection Successful");
    }
}
