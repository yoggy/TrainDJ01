using UnityEngine;
using System.Collections;

public class ProgressTimer : MonoBehaviour {

	public int _totalMinutes = 0; 
	public int _totalSeconds = 60; 

	float _elapsedTime = 0.0f;

	RectTransform _transform;
	Vector2 _originalSizeDelta;

	bool _oldResetValue = false;
	public bool Reset {
		set {
			// Raising trigger
			if (_oldResetValue != value && value == true) {
				_elapsedTime = 0.0f;
			}
			_oldResetValue = value;
		}
	}

	float getTotalTime() {
		return (float)(_totalMinutes * 60 + _totalSeconds);
	}

	float getProgress() {
		float p = _elapsedTime / getTotalTime ();
		if (p > 1.0f)
		{
			p = 1.0f;
		}
		return p;
	}

	void Start () {
		_transform = gameObject.GetComponent<RectTransform> ();
		_originalSizeDelta = _transform.sizeDelta;
	}
		
	void Update () {
		_elapsedTime += Time.deltaTime;
		_transform.sizeDelta = new Vector2 (_originalSizeDelta.x * getProgress(), _originalSizeDelta.y);
	}
}
