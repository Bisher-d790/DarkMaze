using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private Rigidbody player;
	private Camera mainCamera;
    public AudioClip SFX;

	private Vector3 moveInput;
	private Vector3 moveVelocity;
	public bool useController;
	public bool _paused;


	void Start()
	{
		mainCamera = FindObjectOfType <Camera> ();
	}

    void Update()
	{
		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0f, Input.GetAxisRaw ("Vertical"));
		moveVelocity = moveInput * speed;

		if (useController) {
            if (!_paused)
            {


                Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
                Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
                float length;


                if (groundPlane.Raycast(cameraRay, out length))
                {
                    Vector3 pointToLook = cameraRay.GetPoint(length);
                    transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
                }
            }
		}

		if (!useController) 
		{
			if (!_paused) {
				Vector3 playerDirection = Vector3.right * Input.GetAxisRaw ("RHorizontal") + Vector3.forward * -Input.GetAxisRaw ("LHorizontal");
				if (playerDirection.magnitude > 0.0f) {
					transform.rotation = Quaternion.LookRotation (playerDirection, Vector3.up);
				}
			}
		}

        if(moveVelocity != new Vector3(0,0,0))
        {
            if (!this.gameObject.GetComponent<AudioSource>().isPlaying) { this.gameObject.GetComponent<AudioSource>().PlayOneShot(SFX); }
        }else{
            this.gameObject.GetComponent<AudioSource>().Stop();
        }
	}

	void FixedUpdate()
	{

		player.velocity = moveVelocity;
	}

}
