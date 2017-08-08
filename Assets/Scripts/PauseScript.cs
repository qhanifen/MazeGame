using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

public GameObject pause;

	void Awake () {
		pause.SetActive (false);
	}
	
	void Start (){

	}

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
		    if (pause.active == false)
			{
				Pause();
			}
			else
			{
				Unpause();
			}
		}
	}

	public void Pause () 
	{
			pause.SetActive (true);
			Time.timeScale = 0F;
	}

	public void Unpause()
	{
		pause.SetActive (false);
		Time.timeScale = 1F;
	}

	public void Exit () {
		Application.LoadLevel ("Title");
		pause.SetActive (false);
		Time.timeScale = 1F;
	}
}
