using UnityEngine;
using System.Collections;
using System.Linq;

public class GravityGun : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public Material markerMat;
    // Update is called once per frame
    void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.rigidbody)
            {
                //    hit.rigidbody.gameObject.GetComponentsInChildren<Collider>().Select(x => x.bounds).Aggregate(
                //        hit.collider.bounds,
                //        (prior, next) => { prior.Encapsulate(prior); return prior; });
                foreach (var meshFilter in hit.rigidbody.GetComponentsInChildren<MeshFilter>())
                {
                    Graphics.DrawMesh(meshFilter.mesh, Vector3.zero, Quaternion.identity, markerMat, 0);
                    markerMat.renderQueue = 
                   Graphics.DrawMesh(meshFilter.mesh, meshFilter.transform.worldToLocalMatrix/**Matrix4x4.Scale(1.1f*Vector3.one)*/, markerMat, 0);
                }
            }
            
        }
	}
}
