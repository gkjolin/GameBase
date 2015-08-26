using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Reflection;
public class UICombo : MonoBehaviour {

    private RectTransform _mRectTransform;
    private Image _bar;
    private Transform _count;

    private float comboTime = 5.0f;
        
	void Awake () {
        Debug.Log("awake");
        Init();
	}

    private void Init()
    {
        _mRectTransform = this.transform as RectTransform;
        _bar = _mRectTransform.Find("bar").GetComponent<Image>();
        _count = _mRectTransform.Find("count");
        //gameObject.SetActive(false);
        //StartCombo();
        /*Type T = Type.GetType("Game.EnityData");
        MemberInfo[] _a = T.GetMember("DictActionTime");*/
    }

    void Start()
    {
        Debug.Log("start");
    }

    void OnEnable()
    {
        Debug.Log("onEnable");
    }

    private Tweener _tweener;
    private int count = 0;
    public void StartCombo()
    {
        Debug.Log("startCombo");
        count++;
        gameObject.SetActive(true);
        if (_tweener!=null)
        {
            _tweener.Kill();
            _bar.fillAmount = 1;
        }
        _tweener = _bar.DOFillAmount(0, comboTime).OnComplete(StopCombo).SetEase(Ease.Linear);

        if (_count.childCount>0)
        {
            Destroy(_count.GetChild(0).gameObject);
        }
        UIArtNumber.CreatUINumber(count.ToString(), _count);
    }

    private void StopCombo()
    {
        count = 0;
        gameObject.SetActive(false);
        //StartCombo();
    }
	
}
