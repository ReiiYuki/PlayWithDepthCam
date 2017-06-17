using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GesturalManager : MonoBehaviour {

    Dictionary<string, List<GesturalListener>> actions;

	// Use this for initialization
	void Start () {
        actions = new Dictionary<string, List<GesturalListener>>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<HandManager>().handData!=null)
            if (GetComponent<HandManager>().handData.FiredGestureData!=null)
              foreach (var g in GetComponent<HandManager>().handData.FiredGestureData)
                 Debug.Log(g.name);
	}

    public void AddListener(string gesture, GesturalListener listener) {

    }
}
