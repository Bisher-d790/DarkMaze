using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Death : MonoBehaviour {




	public void GoHome(){
		pauseFunction.instance.trunPauseOff ();
		SceneManager.LoadScene ("mainMenu");
	}

	public void Restart(){
		pauseFunction.instance.trunPauseOff ();
		SceneManager.LoadScene ("lvl1");
	}

	public void Exit(){
		Application.Quit ();
	}


}
