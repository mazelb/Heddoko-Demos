using UnityEngine;
using System.Collections;
using UnityEngine.UI;
	
public class SceneController : MonoBehaviour 
{
	public GameObject StartScreen;
	public GameObject EndScreen;
	public GameObject HeddokoMan;
	public Text TimerEndText;
	public GUIText TimerText;

	private float mTimer = 0.0f;
	private bool mStartTimer = false;
	private Vector3 mInitialPosition = Vector3.zero;

	// Use this for initialization
	void Start () 
	{
		//show the start message
		ShowStartScreen(true);
		//Hide the end message
		ShowEndScreen(false);
		//Get the current position of HeddokoMan
		mInitialPosition = HeddokoMan.transform.localPosition;
		Debug.Log(mInitialPosition);
	}
	
	public void ShowStartScreen (bool vShow) 
	{
		StartScreen.SetActive (vShow);
	}

	public void ShowEndScreen (bool vShow) 
	{
		EndScreen.SetActive (vShow);
	}
	
	public void ResetTimer () 
	{
		mTimer = 0.0f;
	}

	public void StartTimer () 
	{
		mStartTimer = true;
	}

	public void StopTimer () 
	{
		mStartTimer = false;
	}

	public void ResetAvatar () 
	{
		HeddokoMan.transform.localPosition = mInitialPosition;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.A))
		{ 
			//Hide the start message
			ShowStartScreen(false);
			
			//Hide the end message
			ShowEndScreen(false);

			//Reset the heddokoman position
			ResetAvatar();

			//Start the timer 
			ResetTimer();
			StartTimer();
		} 

		if (Input.GetKeyDown (KeyCode.D) || Input.GetMouseButtonDown(1)) 
		{ 
			//Stop the timer 
			StopTimer();

			TimerEndText.text = TimerText.text;

			//Show the End message 
			ShowEndScreen(true);
		} 

		if (Input.GetKeyDown (KeyCode.R)) 
		{ 
			Application.LoadLevel (0); 
		} 

		if (mStartTimer) 
		{
			mTimer += Time.deltaTime;
			int minutes = (int)(mTimer / 60);
			int seconds = (int)(mTimer % 60);
			int fractions = (int)(mTimer * 100);
			fractions = fractions % 100;

			TimerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds,fractions);

		}
	}
}
