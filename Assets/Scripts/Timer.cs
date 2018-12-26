using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public static Timer instance = null;
	[SerializeField] Text timer;
	[SerializeField] private int timeforPause;
	private int seconds;
	private int minutes;
	public bool timerWorking;


	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
	}



	// Use this for initialization
	void Start () {

		timerWorking = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		TimerOn ();
	}



	private void TimerOn(){

		if (timerWorking) {


			if (seconds < 60) {
				seconds++;
			} else {
				minutes++;
				seconds = 0;
			}

			timer.text = minutes + ":" + seconds;
		}
	}


	public void StopTime(){
		StartCoroutine (_StopTime ());
	}


	IEnumerator _StopTime()
	{
		timerWorking = false;
		yield return new WaitForSeconds(timeforPause);
		timerWorking = true;
	}

}

