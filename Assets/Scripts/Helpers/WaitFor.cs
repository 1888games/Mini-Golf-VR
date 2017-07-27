using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class WaitFor : MonoBehaviour {

	public void Wait(float seconds, Action action) {
		StartCoroutine (_wait (seconds, action));


	}

	IEnumerator _wait (float time, Action callback) {

		yield return new WaitForSeconds (time);
		callback ();
	}
	
}
