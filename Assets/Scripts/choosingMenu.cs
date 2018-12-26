using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choosingMenu : MonoBehaviour {


	[SerializeField] AudioSource mainTheme;
	[SerializeField] AudioClip _sfx;



	AudioSource sfx;

	// Use this for initialization
	void Start () {

		sfx = GetComponent <AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Loadlvl1(string scene)
	{
		SceneManager.LoadScene (scene);
	}



	public void playSfx(){

		mainTheme.Stop ();
		sfx.PlayOneShot (_sfx, 1);

	}

	public void Exit(){
		Application.Quit ();
	}




}
