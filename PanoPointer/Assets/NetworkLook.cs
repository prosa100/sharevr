using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkLook : NetworkBehaviour
{
    public Transform pointer;
    /*
    [SyncVar]
    public bool highlight = false;
    public GameObject pointer;
    */
    //Split stuff
    public float lookSpeed = 0.1f;
    public Behaviour[] localOnly;
    void Start()
    {
        if (isLocalPlayer)
        {
            Camera.main.enabled = false;
            //mct.parent = transform;
            //mct.localPosition = Vector3.zero;
            //mct.localRotation = Quaternion.identity;
            foreach (var c in localOnly)
            {
                c.enabled = true;

            }
        }
    }


    // Use this for initialization
    void Update()
    {
        if (isLocalPlayer)
        {
            transform.rotation *=  Quaternion.Euler(Time.deltaTime * lookSpeed * Input.GetAxis("Vertical"), Time.deltaTime * lookSpeed * Input.GetAxis("Horizontal"), 0);
            //if (Input.GetButtonDown("Fire2"))
            if(Input.GetKeyDown(KeyCode.Space))
                transform.localRotation = Quaternion.identity;
            //highlight = Input.GetButton("Fire1");
        }
        //pointer.SetActive(highlight);
    }

}
