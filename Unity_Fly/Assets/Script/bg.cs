using UnityEngine;
using System.Collections;

public class bg : MonoBehaviour {
	public float m_speed = 0.05f;
	private Material _ScrollMaterial;

	// Use this for initialization
	void Start () {
		this._ScrollMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		this._ScrollMaterial.mainTextureOffset = new Vector2 (m_speed * Time.time, 0);

	}

    

}
