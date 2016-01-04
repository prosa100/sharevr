using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkLook : NetworkBehaviour
{
    /*
    [SyncVar]
    public bool highlight = false;
    public GameObject pointer;
    */
    //Split stuff
    public float lookSpeed = 0.1f;
    public MonoBehaviour[] localOnly;
    void Start()
    {
        if (isLocalPlayer)
        {
            var mct = Camera.main.transform;
            mct.parent = transform;
            mct.localPosition = Vector3.zero;
            mct.localRotation = Quaternion.identity;
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
            transform.eulerAngles += Time.deltaTime * lookSpeed * new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            //if (Input.GetButtonDown("Fire2"))
            if(Input.GetKeyDown(KeyCode.Space))
                transform.localRotation = Quaternion.identity;
            //highlight = Input.GetButton("Fire1");
        }
        //pointer.SetActive(highlight);
    }

}
