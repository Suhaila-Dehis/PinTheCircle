﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	private Button shootBtn;

	[SerializeField]
	private GameObject needle;

	private GameObject[] gameNeedles;

	[SerializeField]
	private int howManyNeedles;

	private float needleDistance = 0.5f;
	private int needleIndex;

	void Awake () {
		if (instance == null) {
			instance = this;
		}

		GetButton ();
	}

	void Start () {
		CreateNeedles ();
	}

	void GetButton() {
		shootBtn = GameObject.Find ("Shoot Button").GetComponent<Button> ();
		shootBtn.onClick.AddListener (() => ShootTheNeedle());
	}

	public void ShootTheNeedle() {
		gameNeedles [needleIndex].GetComponent<NeedleMovementScript> ().FireTheNeedle ();
		needleIndex++;

		if (needleIndex == gameNeedles.Length) {
			shootBtn.onClick.RemoveAllListeners();
		}
	}

	void CreateNeedles() {
		gameNeedles = new GameObject[howManyNeedles];
		Vector3 temp = transform.position;

		for(int i = 0; i < gameNeedles.Length; i++) {
			gameNeedles[i] = Instantiate(needle, temp, Quaternion.identity) as GameObject;
			temp.y -= needleDistance;
		}
	}

	public void InstantiateNeedle() {
		Instantiate (needle, transform.position, Quaternion.identity);
	}

} // GameManager

































































