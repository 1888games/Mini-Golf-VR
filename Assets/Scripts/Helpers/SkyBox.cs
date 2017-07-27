using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour {

	public float rotation;
	private Skybox skybox;
	public float rotateSpeed = 0.01f;

	// Use this for initialization
	void Start () {

		skybox = GetComponent<Skybox> ();
	}
	
	// Update is called once per frame
	void Update () {

		rotation -= Time.deltaTime * rotateSpeed;
		RenderSettings.skybox.SetFloat ("_Rotation", rotation);
	}
}
