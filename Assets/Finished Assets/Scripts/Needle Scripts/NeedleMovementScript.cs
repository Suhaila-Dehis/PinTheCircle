using UnityEngine;
using System.Collections;

public class NeedleMovementScript : MonoBehaviour {

	[SerializeField]
	private GameObject needleBody;

	private bool canFireNeedle;
	private bool touchedTheCircle;

	private float forceY = 20f;
	
	private Rigidbody2D myBody;

	void Awake() {
		Initialize ();
	}

	void Initialize() {
		needleBody.SetActive (false);
		myBody = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		if (canFireNeedle) {
			myBody.velocity = new Vector2(0, forceY);
		}
	}

	public void FireTheNeedle() {
		needleBody.SetActive (true);
		myBody.isKinematic = false;
		canFireNeedle = true;
	}

	void OnTriggerEnter2D(Collider2D target) {

		if (touchedTheCircle)
			return;

		if (target.tag == "Circle") {
			canFireNeedle = false;
			touchedTheCircle = true;

			myBody.isKinematic = true;
			gameObject.transform.SetParent(target.transform);

			if(ScoreManager.instance != null) {
				ScoreManager.instance.SetScore();
			}
			
		}

	}

} // NeedleMovementScript


























































