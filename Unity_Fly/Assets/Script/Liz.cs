using UnityEngine;
using System.Collections;

public class Liz : MonoBehaviour
{
    public float x_time = 1.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    x_time -= Time.deltaTime;
	    if (x_time <= 0)
	        Destroy(gameObject);

	}
}
