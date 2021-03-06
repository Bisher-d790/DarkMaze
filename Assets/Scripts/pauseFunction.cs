﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseFunction : MonoBehaviour {

	public static pauseFunction instance = null;
	public bool paused;


	// Use this for initialization
	void Start () {

		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

	}


	public void trunPauseOn()
	{
		paused = true;

		if (paused)
		{
			Time.timeScale = 0;
			paused = false;
		}
	}

	public void trunPauseOff()
	{
		paused = false;

		if (!paused)
		{
			Time.timeScale = 1;
			paused = true;
		}
	}

}