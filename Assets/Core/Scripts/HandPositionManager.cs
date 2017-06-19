using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Intel.RealSense.Hand;
using Intel.RealSense;

public class HandPositionManager : MonoBehaviour {
    HandManager handManager;
    public GameObject g,s;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        UpdateHandPosition();
	}

    void UpdateHandPosition()
    {
        handManager = GetComponent<HandManager>();
        if (GetComponent<DepthCameraManger>().isStart)
            if (handManager.handData != null)
            {
                for (int i = 0; i < handManager.handData.NumberOfHands; i++)
                {
                    IHand hand;
                    if (handManager.handData.QueryHandData(AccessOrderType.ACCESS_ORDER_BY_TIME,i,out hand) == Status.STATUS_NO_ERROR)
                    {
                        if (hand.BodySide == BodySideType.BODY_SIDE_LEFT)
                        {
                            Debug.Log("Left : " + hand.MassCenterWorld.x*10 + " " + hand.MassCenterWorld.y * 10 + " " + hand.MassCenterWorld.z * 10);
                            g.transform.position = new Vector3(hand.MassCenterWorld.x * 100, hand.MassCenterWorld.y * 100, hand.MassCenterWorld.z * 100);
                        }
                        else if (hand.BodySide == BodySideType.BODY_SIDE_RIGHT){
                            Debug.Log("Right : " + hand.MassCenterWorld.x * 10 + " " + hand.MassCenterWorld.y * 10 + " " + hand.MassCenterWorld.z * 10);
                            s.transform.position = new Vector3(hand.MassCenterWorld.x * 100, hand.MassCenterWorld.y * 100, hand.MassCenterWorld.z * 100);
                        }
                    }
                }
            }
    }
}
