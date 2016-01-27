using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public Transform end;
    public float defaultDist = 5f;
    public float offset;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
            end.position = hit.point + hit.normal * offset;
        else
            end.position = transform.position + transform.forward * defaultDist;
        GetComponent<LineRenderer>().SetPosition(1, end.localPosition);
    }
}
