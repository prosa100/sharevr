using UnityEngine;
using System.Collections;


public class PlayWithReflectionProbes : MonoBehaviour
{

    public ReflectionProbe probe;

    // Use this for initialization
    void Start()
    {

    }

    void OnGUI()
    {
        GUILayout.Box(probe.texture);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
