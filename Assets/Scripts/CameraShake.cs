using UnityEngine;
using System.Collections;
using System;

public class CameraShake : MonoBehaviour {

	public static CameraShake instance = null;
	public float linearIntensity = 0.25f;
	public float angularIntensity = 5f;

	[NonSerialized] public bool isShaking = false;

	private bool angularShaking = true;


	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
	}



	void Update () {
		if (isShaking) {
			LinearShaking ();
			if (angularShaking)
				AngularShaking ();
		}
	}

	private void LinearShaking () {
		Vector2 shake = UnityEngine.Random.insideUnitCircle * linearIntensity / 2;
		Vector3 newPosition = transform.localPosition;
		newPosition.x = shake.x;
		newPosition.y = shake.y;
		transform.localPosition = newPosition;
	}

	private void AngularShaking () {
		float shake = UnityEngine.Random.Range (-angularIntensity, angularIntensity);
		transform.localRotation = Quaternion.Euler (0f, 0f, shake);
	}

	public void SetAngularShaking(bool state) {
		angularShaking = state;
		if (!angularShaking)
			transform.localRotation = Quaternion.identity;
	}

	public void Enable () {
		isShaking = true;
	}

	public void Disable () {
		isShaking = false;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}
}
	