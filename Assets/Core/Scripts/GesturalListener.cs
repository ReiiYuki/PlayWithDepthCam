using UnityEngine;
public abstract class GesturalListener : MonoBehaviour{

    public string gesture;

    public abstract void Action();

    void OnSetupSuccess()
    {
        GetComponent<GesturalManager>().AddListener(gesture, this);
    }

}
