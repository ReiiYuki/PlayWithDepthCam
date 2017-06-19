using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Intel.RealSense;
using Intel.RealSense.Hand;

public class GesturalManager : MonoBehaviour {

    public string[] gestureActions;

    HandManager handManager;

    string TAG = "Gestural Manager : ";

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        UpdateHandGesture();
    }

    public void EnableGestures()
    {
        handManager = GetComponent<HandManager>();
        foreach (string gesture in gestureActions)
        {
            Debug.Log(TAG + gesture+" Enabled!");
            handManager.handConfiguration.EnableGesture(gesture, true);
        }
        handManager.handConfiguration.ApplyChanges();
        GetComponent<DepthCameraManger>().StartDevice();
    }

    public void UpdateHandGesture()
    {
        if (GetComponent<DepthCameraManger>().isStart)
            if (handManager.handData != null)
                if (handManager.handData.FiredGestureData != null)
                    foreach (GestureData gesture in handManager.handData.FiredGestureData)
                    {
                        IHand hand;
                        if (GetComponent<HandManager>().handData.QueryHandDataById(gesture.handId,out hand) == Status.STATUS_NO_ERROR)
                        {
                            if (hand.BodySide == BodySideType.BODY_SIDE_LEFT)
                                this.SendMessage("OnLeftHand" + gesture.name, SendMessageOptions.DontRequireReceiver);
                            else if (hand.BodySide == BodySideType.BODY_SIDE_RIGHT)
                                this.SendMessage("OnRightHand" + gesture.name, SendMessageOptions.DontRequireReceiver);
                            this.SendMessage("On" + gesture.name, SendMessageOptions.DontRequireReceiver);
                        }
                    }
    }

    void Onspreadfingers()
    {
        Debug.Log("Yes");
    }

    void OnLeftHandspreadfingers()
    {
        Debug.Log("LYes");
    }

    void OnRightHandspreadfingers()
    {
        Debug.Log("RYes");
    }
}
