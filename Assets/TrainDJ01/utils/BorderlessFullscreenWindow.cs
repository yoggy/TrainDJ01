using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

public class BorderlessFullscreenWindow : MonoBehaviour {
	
	public bool _enable = false;

	int _window_x = 0;
	int _window_y = 0;
	int _window_w = 640;
	int _window_h = 480;

	const int SM_CXSCREEN = 0;
	const int SM_CYSCREEN = 1;

	[DllImport("user32.dll")]
	static extern int GetSystemMetrics(int idx);

	long _defaultStyle;
	
	[DllImport("user32.dll")]
	static extern long GetWindowLong (IntPtr hwnd, int nIndex);
	
	[DllImport("user32.dll")]
	static extern IntPtr SetWindowLong (IntPtr hwnd, int nIndex, long dwNewLong);
	
	[DllImport("user32.dll")]
	static extern bool SetWindowPos (IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
	
	[DllImport("user32.dll")]
	static extern IntPtr GetForegroundWindow ();
	
	const uint SWP_SHOWWINDOW = 0x0040;
	const int GWL_STYLE = -16;
	
	void Start () {
		if (Application.platform != RuntimePlatform.WindowsPlayer) {
			_enable = false;
		}
		_defaultStyle = GetWindowLong (GetForegroundWindow (), GWL_STYLE);
		
		if (_enable) {
			EnableBorderlessWindow ();
		}
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			ToggleBorderlessWindow();
		}
	}
	
	public void ToggleBorderlessWindow() {
		if (_enable) {
			DisableBorderlessWindow ();
		} else {
			EnableBorderlessWindow ();
		}
	}
	
	public void EnableBorderlessWindow() {
		_window_x = 0;
		_window_y = 0;
		_window_w = GetSystemMetrics(SM_CXSCREEN);;
		_window_h = GetSystemMetrics(SM_CYSCREEN);

		if (Application.platform == RuntimePlatform.WindowsPlayer) {
			SetWindowLong (GetForegroundWindow(), GWL_STYLE, 8); // 8 -> WS_EX_TOPMOST
			SetWindowPos (GetForegroundWindow (), 0, _window_x, _window_y, _window_w, _window_h, SWP_SHOWWINDOW);
			_enable = true;
		}
	}
	
	public void DisableBorderlessWindow() {
		if (Application.platform == RuntimePlatform.WindowsPlayer) {
			SetWindowLong (GetForegroundWindow(), GWL_STYLE, _defaultStyle);
			SetWindowPos (GetForegroundWindow (), 0, _window_x, _window_y + 20, _window_w, _window_h, SWP_SHOWWINDOW);
			_enable = false;
		}
	}
}