using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Game {
	public class ProgressPanel : XingLuoTianXia.lib .UIPanelBase {

	public Image background;
	public Image progressBg;
	public Image progressBar;
	public Text info;
	private IAsyncProgress _progress;
		Vector3 _scale;

	void Start () {
			_scale = new Vector3 (0, 1, 1);
			progressBar.rectTransform.localScale = _scale;
	}

	void Update () {
			if (_progress != null) {
				_scale.Set(_progress.Progress , 1, 1);
				progressBar.rectTransform.localScale = _scale;
			}
	}

		public void ProgressObj (IAsyncProgress _p)
		{
			_progress = _p;
		}
}
}
