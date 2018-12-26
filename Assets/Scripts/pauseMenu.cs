using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{

	[SerializeField] private GameObject mainCanvas;
	[SerializeField] private GameObject pauseCanvas;
	[SerializeField] private AudioClip _sfx;
	[SerializeField] private AudioSource sfx;
	public player_movement _playerMovement;


	void Start()
	{
	}

	void Update(){

		if (Input.GetButtonDown("pause")){
			PauseMenuOnOff ();	
		}

	}



	public void PauseMenuOnOff()
	{
		sfx.PlayOneShot (_sfx, 1);

		if (mainCanvas.activeInHierarchy)
		{
			mainCanvas.SetActive(false);
			_playerMovement._paused = true;
			pauseFunction.instance.trunPauseOn ();
			pauseCanvas.SetActive (true);
		}
		else
		{
			pauseCanvas.SetActive (false);
			mainCanvas.SetActive(true);
			_playerMovement._paused = false;
			pauseFunction.instance.trunPauseOff ();

		}
	}




}