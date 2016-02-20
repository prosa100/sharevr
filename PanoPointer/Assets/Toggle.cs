using UnityEngine;
using System.Collections;

public class Toggle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
   public GameObject hide;

    public bool active = false;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hide.SetActive(active ^= true);
        }
    }
}
