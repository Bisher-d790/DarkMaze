using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip BG_Music;
    public AudioClip Player_DeathSFX;
    public AudioClip Pickup_SFX;
    public AudioClip Shot_SFX;
    private AudioSource AudioSourceSFX;

	// Use this for initialization
	void Awake () {
        AudioSourceSFX = this.gameObject.GetComponent<AudioSource>();

        GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void PlayerDeathSFX()
    {
        AudioSourceSFX.volume = (0.1f);
        AudioSourceSFX.PlayOneShot(Player_DeathSFX);
    }


    public void PickupSFX()
    {
        AudioSourceSFX.PlayOneShot(Pickup_SFX);
    }


    public void ShotSFX()
    {
        AudioSourceSFX.PlayOneShot(Shot_SFX);
    }
}
