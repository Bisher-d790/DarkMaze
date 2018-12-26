using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

	public GameObject projectile;
	public float power;
	public float ColliderThickness;
	private float _shakePower = 0.39f;
	private float _shakeDuration = 0.1f;


	// Use this for initialization
	void Update()
	{

        if (Input.GetButtonDown("Fire") && !this.GetComponent<player_movement>()._paused)
		{



			if (projectile)
			{



				GameObject InstancedObject = Instantiate(projectile, this.transform.position + transform.forward + new Vector3(0,0,ColliderThickness) , transform.rotation);

				if (!InstancedObject.GetComponent<Rigidbody>()) InstancedObject.AddComponent<Rigidbody>();

				InstancedObject.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().ShotSFX();

			}

			cameraFollow.instance.ShakeCamera (_shakePower, _shakeDuration);
		}

	}



}