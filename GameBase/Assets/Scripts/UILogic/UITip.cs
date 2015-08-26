using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using DG.Tweening;
public class UITip : MonoBehaviour {

    public const string UIName = "UITip";
    private Transform mTransform;
    private Text text_tip;
    private static UITip _instance;
    private CanvasGroup canvasGroup;
    public static UITip Instance
    {
        get { return UITip._instance; }
    }

    void Awake()
    {
        
    }
	void Start () {
        Init();
	}

    private void Init()
    {
        _instance = this;
        mTransform = this.transform;
        text_tip = mTransform.Find("text_tip").GetComponent<Text>();
        canvasGroup = mTransform.GetComponent<CanvasGroup>();
        gameObject.SetActive(false);
        //EventSystem.current.SetSelectedGameObject(gameObject);
    }

    private Tweener tweener;
    public void SetTip(string str = " this is a tip")
    {   
        if (tweener!=null)
        {
            tweener.Kill();
        }
        this.mTransform.localPosition = Vector3.zero;
        gameObject.SetActive(true);
        text_tip.text = str;
        tweener = mTransform.DOLocalMoveY(200, 1.2f).OnComplete(OnPlayEnd);
       /* TweenParms tp = new TweenParms();
        tp.Prop(UIBase.HOTweenParam.localPosition.ToString(),new Vector3(0,200,0),true);
        //tp.Loops(-1,LoopType.Yoyo);
        tp.OnComplete(OnPlayEnd);
        tweener = HOTween.To(mTransform,1.2f, tp);*/
        /*canvasGroup.alpha = 1;  //透明度的改变
        HOTween.To(canvasGroup, 0.7f, new TweenParms().Prop("alpha", 0).Delay(0.5f));*/
    }

    private void OnPlayEnd()
    {
        gameObject.SetActive(false);
    }
	
}
