using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovieController : MonoBehaviour {

	#region Public Properties

	public string _targetDirectory = "C:\\test\\";

	public GameObject _targetMovieA;
	public GameObject _targetMovieB;

	public GameObject _previewMovieA;
	public GameObject _previewMovieB;

	int _movieIdxA = -1;
	public float MovieIdxA {
		set {
			int idx = (int)(value * (_movies.Length - 1));
			if (_movieIdxB == idx) return;

			if (_movieIdxA != idx) {
				_movieIdxA = idx;
				_previewA_Image.sprite = _previews[idx];
				Debug.Log ("movieIdxA = " + idx);
			}
		}
	}
	
	int _movieIdxB = -1;
	public float MovieIdxB {
		set {
			int idx = (int)(value * (_movies.Length - 1));
			if (_movieIdxA == idx) return;
			if (_movieIdxB != idx) {
				_movieIdxB = idx;
				_previewB_Image.sprite = _previews[idx];
				Debug.Log ("movieIdxB = " + idx);
			}
		}
	}

	float _seekMovieA = 0.0f;
	public float SeekMovieA {
		get { return _seekMovieA; }
		set {
			_seekMovieA = value;
		}
	}

	float _seekMovieB = 0.0f;
	public float SeekMovieB {
		get { return _seekMovieB; }
		set {
			_seekMovieB = value;
		}
	}
	
	public bool PlayMovieA {
		set {
			if (value == true) {
				if (_currentMovieA != null) {
					_currentMovieA.Pause ();
				}
				
				_currentMovieA = _movies [_movieIdxA];
				
				_currentMovieA.MovieInstance.Loop = true;
				_currentMovieA.MovieInstance.PositionFrames = (uint)(_currentMovieA.MovieInstance.DurationFrames * _seekMovieA);
				_currentMovieA.MovieInstance.PlaybackRate = 1.0f;

				_currentMovieA.Play ();
				_currentMovieIdxA = _movieIdxA;

				Debug.Log ("PlayMovieA = " + _currentMovieIdxA);
			}
		}
	}

	public bool PlayMovieB {
		set {
			if (value == true) {
				if (_currentMovieB != null) {
					_currentMovieB.Pause ();
				}
				
				_currentMovieB = _movies [_movieIdxB];

				_currentMovieB.MovieInstance.Loop = true;
				_currentMovieB.MovieInstance.PositionFrames = (uint)(_currentMovieB.MovieInstance.DurationFrames * _seekMovieB);
				_currentMovieB.MovieInstance.PlaybackRate = 1.0f;

				_currentMovieB.Play ();
				_currentMovieIdxB = _movieIdxB;

				Debug.Log ("PlayMovieB = " + _currentMovieIdxB);
			}
		}
	}

	public bool PauseMovieA {
		set {
			if (value == true) {
				if (_currentMovieA != null) {
					_currentMovieA.Pause ();
					Debug.Log ("PauseMovieA = " + _currentMovieIdxA);
				}
			}
		}
	}
	
	public bool PauseMovieB {
		set {
			if (value == true) {
				if (_currentMovieB != null) {
					_currentMovieB.Pause ();
					Debug.Log ("PauseMovieB = " + _currentMovieIdxB);
				}
			}
		}
	}

	#endregion
	
	#region Private Members

	protected Material _movieA_Material;
	protected Material _movieB_Material;

	protected Image _previewA_Image;
	protected Image _previewB_Image;

	AVProWindowsMediaMovie _currentMovieA;
	AVProWindowsMediaMovie _currentMovieB;
	int _currentMovieIdxA = -1;
	int _currentMovieIdxB = -1;

	AVProWindowsMediaMovie [] _movies;
	Sprite [] _previews;

	Texture2D _blank;

	#endregion

	#region MonoBehaviour Functions

	void Start () {
		GetMaterials ();
		CreateBlankTexture ();
		LoadMovies ();
	}

	void Update() {
		// drawing Texture
		if (_movieA_Material != null) {
			if (_currentMovieA != null) {
				_movieA_Material.mainTexture = _currentMovieA.OutputTexture;
			}
			else {
				_movieA_Material.mainTexture = _blank;
			}
		}

		if (_movieB_Material != null) {
			if (_currentMovieB != null) {
				_movieB_Material.mainTexture = _currentMovieB.OutputTexture;
			}
			else {
				_movieB_Material.mainTexture = _blank;
			}
		}
	}

	void GetMaterials () {
		_movieA_Material = _targetMovieA.GetComponent<Renderer> ().material;
		_movieB_Material = _targetMovieB.GetComponent<Renderer> ().material;
		_previewA_Image = _previewMovieA.GetComponent<Image> ();
		_previewB_Image = _previewMovieB.GetComponent<Image> ();
	}

	void CreateBlankTexture() {
		_blank = new Texture2D(1, 1, TextureFormat.ARGB32, false, false);
		_blank.name = "blank_texture";
		_blank.filterMode = FilterMode.Point;
		_blank.wrapMode = TextureWrapMode.Clamp;
		_blank.SetPixel(0, 0, Color.black);
		_blank.Apply(false, true);
	}

	void LoadMovies() {
		string [] files = GetFiles (_targetDirectory, ".mp4");	
		_movies = LoadMovies(files);
		_previews = LoadPreviews(files);

		MovieIdxA = 0;
		MovieIdxB = 1;
	}

	string [] GetFiles(string targetDirectory, string targetExt) {
		string[] files = System.IO.Directory.GetFiles(targetDirectory);
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		
		foreach (string f in files)
		{
			string ext = System.IO.Path.GetExtension(f);
			if (ext == targetExt)
			{
				list.Add(f);
			}
		}
		
		string [] result = list.ToArray ();
		
		return result;
	}

	AVProWindowsMediaMovie [] LoadMovies(string [] movie_files) {
		System.Collections.Generic.List<AVProWindowsMediaMovie> list = new System.Collections.Generic.List<AVProWindowsMediaMovie>();

		for (int i = 0; i < movie_files.Length; ++i) {
			Debug.Log ("(" + i + "/" + movie_files.Length + ") : movie=" + movie_files[i]);

			AVProWindowsMediaMovie movie = gameObject.AddComponent <AVProWindowsMediaMovie>();
			movie._volume = 0.0f;
			movie._loop = true;
			movie._folder = System.IO.Path.GetDirectoryName (movie_files[i]);
			movie._filename = System.IO.Path.GetFileName (movie_files[i]);
			movie._loadOnStart = false;
			movie._playOnStart = false;
			movie._allowAudio = false;
			//movie._colourFormat = AVProWindowsMediaMovie.ColourFormat.RGBA32;
			movie.LoadMovie (false); // true:enable autoplay

			list.Add (movie);
		}

		return list.ToArray ();
	}

	Sprite [] LoadPreviews(string [] movie_files) {
		System.Collections.Generic.List<Sprite> list = new System.Collections.Generic.List<Sprite>();
		
		for (int i = 0; i < movie_files.Length; ++i) {
			string filename = movie_files [i] + ".jpg";

			byte [] buf = System.IO.File.ReadAllBytes (filename);
			if (buf == null) {
				Debug.LogError("cannot load image file...filename=" + filename);
				continue;
			}
			
			Texture2D t = new Texture2D(2, 2);
			if (t.LoadImage(buf) == false) {
				Debug.LogError("tex.LoadImage() failed...filename=" + filename);
				continue;
			}

			Sprite s = Sprite.Create (t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f));

			list.Add(s);
		}

		return list.ToArray ();
	}

	#endregion
}
