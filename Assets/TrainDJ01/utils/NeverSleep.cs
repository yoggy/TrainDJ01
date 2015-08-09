using UnityEngine;
using System.Collections;

public class NeverSleep : MonoBehaviour {

	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}	

	void Update () {
	}
}
