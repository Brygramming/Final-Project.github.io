using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserBeam : MonoBehaviour 
{
	public AudioSource WinningSource;
	public AudioClip WinningSound;

	private int ScoreCount;
	public Text CountingText;
	public Text WinningText;
	//public AudioSource WonAudioSource;
	public AudioClip WonAudioClip;

	// Use this for initialization
	void Start () 
	{
		WinningSource = GetComponent<AudioSource> ();
		ScoreCount = 0;
		SetCountText ();
		WinningText.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		Ray beam = Camera.main.ScreenPointToRay (Input.mousePosition);

		Debug.DrawRay (beam.origin, beam.direction * 1000f);

		RaycastHit BeamHit = new RaycastHit ();

		if (Physics.Raycast (beam, out BeamHit, 1000f, LayerMask.GetMask("Instruments"))) 
		{
			if (Input.GetMouseButtonDown(0))
			{
				Destroy (BeamHit.collider.gameObject);
				WinningSource.PlayOneShot (WinningSound, 10f);
				ScoreCount = ScoreCount + 1;
				SetCountText ();
				Debug.Log ("Hit!!");
			}
		}
		//if (Input.GetMouseButtonDown (1))
		//{
			//BeamHit.rigidbody.AddForce (Random.insideUnitSphere * 80000f);
		//}
	}
	void SetCountText ()
	{
		CountingText.text = "Instruments Found: " + ScoreCount;

		if (ScoreCount >= 15) 
		{
			WinningText.text = "Thanks for Playing!";
			WinningSource.PlayOneShot (WonAudioClip, 6f);
		}
	}
}
