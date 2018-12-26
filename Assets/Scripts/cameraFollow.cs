using UnityEngine;

public class cameraFollow : MonoBehaviour {


	public static cameraFollow instance = null;
	[SerializeField] private float smoothSpeed;
	[SerializeField] private float shakeTime;
	[SerializeField] private float shakeAmount;
	[SerializeField] private Transform target;
	[SerializeField] private Vector3 Offset;


	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);    
		}

	}

	void Update()
	{

		if (shakeTime >= 0) {
			Vector2 _shakePos = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3 (transform.position.x + _shakePos.x, transform.position.y + _shakePos.y, transform.position.z);
			shakeTime -= Time.deltaTime;
		}


	}

	void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + Offset;
		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}




	public void ShakeCamera(float shakePower, float shakeDuration)
	{
		shakeAmount = shakePower;
		shakeTime = shakeDuration;
	}
}
