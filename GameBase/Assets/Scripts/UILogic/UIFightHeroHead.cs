using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class UIFightHeroHead : MonoBehaviour
{

    private Button btn_head;
    private Button btn_skill;
    private Image bar_hp;
    private Transform m_transform;
//    private Actor _actor;
    private bool _isGo = false;
    private Image img_head;
    public bool IsGo
    {
        get { return _isGo; }
        set
        {
            _isGo = value;
            transform.DOLocalMoveY(_isGo?14:-14, 0.3f).SetRelative(true);
        }
    }

    void Start()
    {
        Init();
        InitEvent();
        //SetVisible(false);
    }

    private void Init()
    {
        m_transform = this.transform;
        btn_head = m_transform.Find("btn_head").GetComponent<Button>();
        btn_skill = m_transform.Find("btn_skill").GetComponent<Button>();
        bar_hp = m_transform.Find("bar_hp").GetComponent<Image>();
        img_head = m_transform.Find("Image 1").GetComponent<Image>();
    }

    private void InitEvent()
    {
        btn_head.onClick.AddListener(OnClickHead);
        btn_skill.onClick.AddListener(OnClickSKill);
    }

    private float lastClickTime;
    private void OnClickHead()
    {
        if(Time.time - lastClickTime<0.3f)
        {
            return;
        }
        lastClickTime = Time.time;
        IsGo = !IsGo;
    }

    private void OnClickSKill()
    {
        Debug.Log("click skill btn");
    }

    public void SetHpBar(float curValue, float maxValue)
    {
        bar_hp.fillAmount = curValue / maxValue;
    }

    /*public Actor Actor
    {
        get
        {
            return _actor;
        }
        set
        {
            SetVisible(true);
            _actor = value;
            //img_head.overrideSprite = 
            //SetHpBar();
            //添加 actor的监听事件
        }
    }*/

    public void SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
    }

}
