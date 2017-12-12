using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextDisable : MonoBehaviour 
{
	public Canvas Menu;
	public Button PlayButton;
	public Text PlayPrefab;
	public Text ObjectiveText;

	public Text TimesupText;
	public Text CountdownTimerText;
	public float Timer = 90;
	float TimeRemaining = 90;

	// Use this for initialization
	void Start ()
	{
		Menu = Menu.GetComponent<Canvas> ();
		PlayButton = PlayButton.GetComponent<Button> ();
		PlayPrefab = PlayPrefab.GetComponent<Text> ();
		ObjectiveText = ObjectiveText.GetComponent<Text> ();

		CountdownTimerText = CountdownTimerText.GetComponent<Text> ();
		TimesupText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (ObjectiveText.enabled == false) 
		{
			TimeRemaining = Timer - Time.time;
		} 

		else if (Input.GetMouseButtonDown (0)) 
		{
			PlayPrefab.enabled = false;
			ObjectiveText.enabled = false;
			Timer += Time.time;

			//Timer -= Time.deltaTime;
			//CountdownTimerText.text = "Time: " + Timer.ToString ("f0");
		}
		CountdownTimerText.text = "Time: " + (int)TimeRemaining;

		if (TimeRemaining < 0)
		{
			TimesupText.text = "Times Up!";
		}
	}
}

	//void PlayPress()
	//{
		//PlayButton.enabled = true;
	//}
