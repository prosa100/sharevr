using UnityEngine;

public class LaserPointer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public Transform end;
    public float defaultDist = 5f;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
            end.position = hit.point;
        else
            end.position = transform.position + transform.forward * defaultDist;
        GetComponent<LineRenderer>().SetPosition(1, end.localPosition);
    }
}
