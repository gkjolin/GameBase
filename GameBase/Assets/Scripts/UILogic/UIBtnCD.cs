using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class UIBtnCD : MonoBehaviour {

    private RectTransform mRectTransform;
    private Button _btn;
    public float cdTime = 2;
    private Image _mask;
    private Tweener _tweener;
    public bool isCD;

	void Start () {
        mRectTransform = this.transform as RectTransform;
        _btn = mRectTransform.GetComponent<Button>();
        _mask = mRectTransform.Find("mask").GetComponent<Image>();
        _mask.transform.localPosition = Vector3.zero;
        _mask.enabled = false;
	}

    public void SetMask()
    {
        if (_tweener == null)
        {
            _mask.enabled = true;
            _mask.fillAmount = 1;
            isCD = true;
            _tweener = _mask.DOFillAmount(0, cdTime).SetEase(Ease.Linear).OnComplete(OnComplete);
        }else
        {
            Debug.Log("技能CD中");
        }

    }

    private void OnComplete()
    {
        _mask.enabled = false;
        isCD = false;
        _tweener = null;
    }

}
