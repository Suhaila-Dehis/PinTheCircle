using UnityEngine;
using System.Collections;

public class CircleRotateScript : MonoBehaviour {

	[SerializeField]
	private float rotationSpeed = 50f;

	private bool canRotate;

	private float angle;
	
	void Awake () {
		canRotate = true;
//		StartCoroutine(ChangeRotation());
	}

	void Update () {
		if (canRotate) {
			RotateTheCirle();
		}
	}

	IEnumerator ChangeRotation() {
		yield return new WaitForSeconds (2f);

		if (Random.Range (0, 2) > 0) {
			rotationSpeed = -Random.Range (50, 100);
		} else {
			rotationSpeed = Random.Range (50, 100);
		}

		StartCoroutine (ChangeRotation ());
	}

	void RotateTheCirle() {
		angle = transform.rotation.eulerAngles.z;
		angle += rotationSpeed * Time.deltaTime;
		transform.rotation = Quaternion.Euler (new Vector3(0, 0, angle));
	}

} // CircleRotateScript



















































