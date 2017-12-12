using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_People : MonoBehaviour 
{
	//public GameObject People;

	public float ThrustX;
	public float ThrustY;
	public float ThrustZ;
	public Rigidbody PeopleBody;

	public AudioSource People_Audio_Source;
	public AudioClip Walking_Sound;

	public Vector3 StartOriginalPosition;

	// Use this for initialization
	void Start () 
	{
		PeopleBody = GetComponent<Rigidbody>();

		StartOriginalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		People_Audio_Source.PlayOneShot (Walking_Sound, 0.7f);

		PeopleBody.AddForce (ThrustX, ThrustY, ThrustZ, ForceMode.Impulse);

		if (transform.position.x < 120 || transform.position.x > 350 ||
			transform.position.z < 110 || transform.position.z > 515)
		{
			transform.position = StartOriginalPosition;
		}
	}
}
