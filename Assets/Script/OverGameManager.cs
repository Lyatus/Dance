﻿using UnityEngine;
using System.Collections;

public class OverGameManager : MonoBehaviour {

	public float timeBeforeResetValue = 5f;

	private float timeBeforeReset;

	// Use this for initialization
	void Start () {
		timeBeforeReset = Time.time + timeBeforeResetValue;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeBeforeResetValue < Time.time) {
			Application.LoadLevel(0);
		}
	}
}
