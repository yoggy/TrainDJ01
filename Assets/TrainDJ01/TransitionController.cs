using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransitionController : MonoBehaviour {

	#region Public Properties
	
	public string _targetDirectory = "C:\\test\\transition\\";
	
	public GameObject _targetMovie;
	public GameObject _previewMovie;

	int _movieIdx = -1;
	public float MovieIdx {
		set {
			int idx = (int)(value * (_movies.Length - 1));

			if (_movieIdx != idx) {
				_movieIdx = idx;
				_preview_Image.sprite = _previews[idx];
				Debug.Log ("movieIdx = " + idx);
			}
		}
	}

	public bool PlayMovie {
		set {
			if (_is_playing == value) return;

			if (value == true) {
				_currentMovie = _movies [_movieIdx];
				
				_currentMovie.MovieInstance.Loop = true;
				_currentMovie.MovieInstance.PositionFrames = 0;
				_currentMovie.MovieInstance.PlaybackRate = 1.0f;
				
				_currentMovie.Play ();

				Debug.Log ("PlayMovie = " + _movieIdx);
				_is_playing = true;
			}
			else {
				if (_currentMovie != null) {
					_currentMovie.Pause ();
				}
				_is_playing = false;
			}
		}
	}

	#endregion
	
	#region Private Members

	bool _is_playing = false;

	protected Material _movie_Material;

	protected Image _preview_Image;

	AVProWindowsMediaMovie _currentMovie;

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
		if (_movie_Material != null) {
			if (_currentMovie != null) {
				_movie_Material.mainTexture = _currentMovie.OutputTexture;
			}
			else {
				_movie_Material.mainTexture = _blank;
			}
		}
	}
	
	void GetMaterials () {
		_movie_Material = _targetMovie.GetComponent<Renderer> ().material;
		_preview_Image = _previewMovie.GetComponent<Image> ();
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
		
		MovieIdx = 0;
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
