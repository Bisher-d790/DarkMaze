using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEmitter : MonoBehaviour {

	public float Intensity;
	public float fadeIn_Time;
	public float Wait_ON_Time;
	public float fadeOut_Time;


	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Light>().intensity = 0;
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine(FadeIn());
		StartCoroutine(FadeOut());
	}

	IEnumerator FadeIn(){
		float LightPerSec = Intensity / fadeIn_Time;
		float LightPerRefresh = (LightPerSec / 25);

		while (this.gameObject.GetComponent<Light>().intensity < Intensity){
			this.gameObject.GetComponent<Light>().intensity += LightPerRefresh;
			yield return new WaitForSeconds((1/50));
		}
	}

	IEnumerator FadeOut()
	{
		yield return new WaitForSeconds(Wait_ON_Time);

		float LightPerSec = Intensity / fadeOut_Time;
		float LightPerRefresh = (LightPerSec / 25);

		while (this.gameObject.GetComponent<Light>().intensity > 0.0)
		{
			this.gameObject.GetComponent<Light>().intensity -= LightPerRefresh;
			yield return new WaitForSeconds(1/50);
		}
		Destroy(gameObject);
	}
}