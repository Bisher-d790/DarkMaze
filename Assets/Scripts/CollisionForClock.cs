using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionForClock : MonoBehaviour {



    void OnTriggerEnter(Collider collision)
	{

		if (collision.gameObject.tag == "Player") {
			Timer.instance.StopTime ();
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PickupSFX();
			Destroy (gameObject);
		}
	}

}
