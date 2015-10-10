using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class HideMouseCursor : MonoBehaviour {

	void Start () {
	}

	void Update() {
	}

	void OnGUI() {
#if UNITY_EDITOR
#else
        Cursor.visible = false;
#endif
	}
}
