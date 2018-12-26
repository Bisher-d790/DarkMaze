using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class destroyProjectile : MonoBehaviour {

	public GameObject lightwave;
	public GameObject Explosion;

	void OnCollisionEnter (Collision collision)
	{
		if (lightwave)
		{
			Instantiate(lightwave, this.transform.position, transform.rotation);
		}

		if (Explosion)
		{
			Instantiate(Explosion, transform.position, transform.rotation);
		}

		Destroy(gameObject);

	}



}