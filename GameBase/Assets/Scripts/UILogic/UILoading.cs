using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Game;
public class UILoading : MonoBehaviour {

    public const string UIName = "UILoading";
    private static UILoading _instance;
    private Transform transformBarHead;

    private int move_path = 770;//loading 星光移动距离
    private int begin_move_point = -440;
    private Text text_tip;

    public static UILoading Instance
    {
        get { return _instance; }
    }
    public enum eLoadingStep
    {
        none = 0,
        ui,
        wait_battle_actor,
        wait_scene_actor,
        wait_pvp_actor, 
        over,
    }
    private eLoadingStep mLoadingStep;

    private Image bar;
    private Transform mTransform;
	void Start () {
        Init();
	}

    private void Init()
    {
        _instance = this;
        mTransform = transform;
        bar = mTransform.Find("bar").GetComponent<Image>();
        transformBarHead = mTransform.Find("bar/bar_head");
        text_tip = mTransform.Find("text_tip").GetComponent<Text>();
        SetBarProgress(0);
        gameObject.SetActive(false);
    }

    public void SetBarProgress(float value,Action callBack = null)
    {
        bar.fillAmount = value;
        transformBarHead.localPosition = new Vector3(begin_move_point + move_path * value, 2, 0);
        if (value >= 1)
        {
            CloseUI();
            if(callBack!=null)
            {
                callBack();
            }
        }
    }

    public void StartShow()
    {
        if(gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
            string s = DataSource.Instance.DataLoadingTips.GetRandomTip();
            text_tip.text = s;
            Debug.Log("random tip : " + s);
        }

    }

	public void CloseUI()
    {
        gameObject.SetActive(false);
    }


    private void SetTip()
    {

    }

    private float i = 0.05f;
    public void TestLoading()
    {
        UILoading.Instance.StartShow();

        UILoading.Instance.SetBarProgress(i);
        i = i + 0.005f;
        if (i <= 1)
        {
            GlobalData.Instance.Delay(0.01f, TestLoading);
        }
        else
        {
            UILoading.Instance.CloseUI();
            i = 0.05f;
        }
    }
}
