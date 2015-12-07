using UnityEngine;
using System.Collections;

public class CameraGS : MonoBehaviour {
	public Transform target;
	public Vector3 offPos;
	// Use this for initialization
	void Start () {
		offPos = target.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position - offPos;
	}
}
