using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class RotationScript : MonoBehaviour
{
	[SerializeField] private float speed = 10f;

	void Update ()
	{
		transform.Rotate(Vector3.left, speed * Time.deltaTime);
	}
}