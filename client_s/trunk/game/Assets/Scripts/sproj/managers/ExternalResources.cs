using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Game
{
	public interface IAsyncProgress {
		float Progress { get;}
		void Next (WWW w);
	}

	public class LoadProgress : IAsyncProgress {
		public float Progress {get{if (_loader == null) return 0; return _loader.progress;}}
		private WWW _loader;
		public void Next (WWW l) {_loader = l; }
	}

	public class BatchLoadProgress : IAsyncProgress {
		public float Progress {get{if (_loader == null) return 0; return _loader.progress / _total + _tProgress;}}
		private WWW _loader;
		private int _total;
		private int _cur;
		private float _tProgress;
		public BatchLoadProgress (int count) {_total = count; }
		public void Next (WWW l) {_loader = l; _cur++; _tProgress = _cur / _total;}
	}

	public enum ResCategory : int {
		Audio,
		Video,
		Text,
		Binary,
		Character,
		Shader,
		Scene,
	}

	[Flags]
	public enum CacheOption : short {
		None = 0x0,
		_Ignorable = None,

		Deserialize = 0x01,
		Decrypt = 0x02,
		Uncomopress = 0x04,
		CustomParser = 0x08,
	}

	public class ExternalResources
	{
		private static ExternalResources _self;
		public static ExternalResources Instance {get{if (_self == null) _self = new ExternalResources(); return _self;}}

		private ExternalResources () { 
			_inLoading = new List<string> (64);/* max parallel loading op */
			_pool = new Dictionary<string, UnityEngine.Object> (512);
		}

		public MonoBehaviour CrExe { get; set ;}
		private List <string> _inLoading;
		private Dictionary <string, UnityEngine.Object> _pool;

		// <should be JIT inlined>
		private string Protocol ()
		{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
			return "file://";
#elif UNITY_ANDROID
			return null;
#elif UNITY_IPHONE
			return null;
#else
			return null;
#endif
		}

		public IAsyncProgress Cache(string id, ResCategory cat, Action<string> OnCached) {
			return Cache (id, cat, OnCached, null, null);
		}
		public IAsyncProgress Cache<R> (string id, ResCategory cat, Action<string> OnCached) where R : UnityEngine.Object {
			return Cache (id, cat, OnCached, null, typeof(R));
		}
		public IAsyncProgress Cache(string id, ResCategory cat, Action<string> OnCached, Action<string, string, string> OnError, params Type[] typeF) {
			if (_inLoading.Contains (id) || _pool.ContainsKey(id))
				return null;
			LoadProgress lp = new LoadProgress ();
			CrExe.StartCoroutine (CacheInternal(id, cat, OnCached, OnError, 0, typeF, lp));
			return lp;
		}

		public R Load<R> (string id) where R : UnityEngine.Object {
			R r = null;
			if (_pool.ContainsKey (id)) {
				r = _pool[id] as R;
				if (r == null) Debug.LogWarning (id + "(" + r.GetType() + ") is not of type " + typeof(R) + "!");
			} else if (_inLoading.Contains(id)){
				Debug.LogWarning (id + " is in loading process!");
			} else {
				Debug.LogError (id + " is not cached!");
			}
			return r;
		}

		// <should be JIT inlined>
		private string ConvertToUrl (string id)
		{
			return Protocol() + Application.streamingAssetsPath + "/" + id + ".bytes";
		}

		private IEnumerator CacheInternal (string id, ResCategory cat, Action<string> OnCached, Action<string, string, string> OnError, CacheOption options, Type[] typeF, IAsyncProgress prog)
		{
			_inLoading.Add (id);
			WWW l = new WWW (ConvertToUrl(id));
			prog.Next (l);
			yield return l;
			if (l.error != null) {
				if (OnError != null) OnError (id, l.url, l.error);
				else DefaultOnError (id, l.url, l.error);
			}
			PostProcessByCategory (id, l, cat, typeF);
			if (options > CacheOption._Ignorable) OptionalPostProcess (id, cat, options);
			if (OnCached != null) OnCached (id);
			_inLoading.Remove (id);
		}

		void DefaultOnError (string id, string url, string error)
		{
			Debug.LogError (id + "@url = " + url + " load failed. " + " \nerror = " + error);
		}

		private void PostProcessByCategory (string id, WWW loader, ResCategory cat, Type[] typeF)
		{
			switch (cat) {
			case ResCategory.Audio :
				//TODO : loader.GetAudioClip();
				break;
			case ResCategory.Binary :
				//TODO : loader.bytes
				break;
			case ResCategory.Text :
				//TODO : loader.text
				break;
			case ResCategory.Video :
				//TODO : loader.movie;
				break;
			case ResCategory.Character : {
				GameObject t = loader.assetBundle.mainAsset as GameObject;
				if (t == null) Debug.LogError("assetbundle from (" + loader.url + ") does not contain the requested GameObject (id = " + id + ")");
				else _pool.Add (id, t);
			}
				break;
			case ResCategory.Scene : {
				AssetBundle ab = loader.assetBundle;//load the bundle into memory
			}
				break;
			case ResCategory.Shader : {
				Shader t = loader.assetBundle.mainAsset as Shader;
				if (t == null) Debug.LogError("assetbundle from (" + loader.url + ") does not contain the requested Shader (id = " + id + ")");
				else _pool.Add (id, t);
			}
				break;
			}
		}

		private void OptionalPostProcess (string id, ResCategory cat, CacheOption options)
		{
			//TODO
		}
	}
}

