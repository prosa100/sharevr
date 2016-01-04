using UnityEngine;
using WiimoteApi;
using System.Linq;

public class WiimotePointer : MonoBehaviour {

    Wiimote remote;
    void Awake()
    {
        WiimoteManager.FindWiimotes(); // Poll native bluetooth drivers to find Wiimotes
        remote = WiimoteManager.Wiimotes.FirstOrDefault();
        remote.ActivateWiiMotionPlus();

        remote.SendDataReportMode(InputDataType.REPORT_BUTTONS_EXT19);

        //remote.SendDataReportMode(InputDataType.REPORT_INTERLEAVED);
        remote.SendPlayerLED(true, false, false, true);
    }

    // Use this for initialization
    void Start () {
	
	}

    public float gyroScale = 1;
    public float clamp = 10;
    public Vector3 gyroDrift = new Vector3(12, -5, 8);
    float chop(float x, float thresh = 1)
    {
        return (Mathf.Abs(x) > thresh) ? x : 0;
    }
	// Update is called once per frame
	void Update () {
        if (remote == null)
            return;
        
        while (remote.ReadWiimoteData() > 0);
        // ReadWiimoteData() returns 0 when nothing is left to read.  So by doing this we continue to
        // update the Wiimote until it is "up to date."

        //remote.st
        //print(remote.Button.a);
        var motion = remote.MotionPlus;
        
        
        var gyro =  new Vector3(-motion.PitchSpeed, motion.YawSpeed, motion.RollSpeed);
        print(gyro);
        var gyroQuat = Quaternion.Euler(Time.deltaTime * (gyro - gyroDrift));
        transform.rotation *= gyroQuat;
        MotionPlusData data = remote.MotionPlus; // data!
    }

    void OnDestroy()
    {
        WiimoteManager.Cleanup(remote);

    }
}
