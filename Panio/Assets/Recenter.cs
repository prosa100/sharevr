using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class Recenter : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        var trackedTransform = OVRManager.tracker.GetPose(double.NaN);
        print(OVRManager.tracker.isPositionTracked + "," + trackedTransform.position);
        if (Input.GetKeyDown(KeyCode.Home))
        {
            transform.position = trackedTransform.position;
            //transform.rotation = trackedTransform.ro
        }
        //{
        //    InputTracking.Recenter();
        //    transform.parent.position += Camera.main.transform.position - transform.position;
        //}
    }
}
