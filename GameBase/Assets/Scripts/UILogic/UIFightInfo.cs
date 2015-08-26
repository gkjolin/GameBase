using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using Game;
public class UIFightInfo : MonoBehaviour
{

    private UIFightHeroHead[] arr_heads = new UIFightHeroHead[5];

    private static UIFightInfo _instance;

    public static UIFightInfo Instance
    {
        get { return UIFightInfo._instance; }
    }
    private bool _isSwitchHero = true;
    private Button btn_switch;
    private Button btn_stop;
    private Button btn_speed;
    private Text text_kills;
    private Vector3 _v3Gold;
    private Vector3 _v3Wood;
    private UIFightBallMatch _uifightBallMatch;
    private UIBallManager _uiBallManager;
    private Transform m_transform;
    private ParticleSystem _p;
    public bool IsSwitchHero
    {
        get { return _isSwitchHero; }
        set
        {
            _isSwitchHero = value;
            btn_switch.transform.DOLocalMoveY(_isSwitchHero ? 55 : -55, 0.3f).SetRelative(true);
        }
    }
    void Start()
    {
        InitUI();
        InitHeads();
        InitEvent();
        Debug.Log("ui start");

    }

    void OnEnable()
    {
    }

    void OnDisable()
    {
    }

    private void InitUI()
    {
        _instance = this;
        m_transform = this.transform;
        btn_switch = m_transform.Find("btn_switch").GetComponent<Button>();
        btn_stop = m_transform.Find("btn_stop").GetComponent<Button>();
        btn_speed = m_transform.Find("btn_speed").GetComponent<Button>();
        text_kills = m_transform.Find("Image_timeBg/lbl_kills").GetComponent<Text>();

        _v3Gold = m_transform.Find("Image_timeBg/Image_gold").localPosition;
        _v3Wood = m_transform.Find("Image_timeBg/Image_wood").localPosition;

        _uifightBallMatch = m_transform.GetComponent<UIFightBallMatch>();
        _uiBallManager = m_transform.GetComponent<UIBallManager>();
        SetKillMonsterNum(0);
    }

    private void InitHeads()
    {
        arr_heads[0] = m_transform.Find("card_container/card_container_1").GetComponent<UIFightHeroHead>();
        arr_heads[1] = m_transform.Find("card_container/card_container_6").GetComponent<UIFightHeroHead>();
        arr_heads[2] = m_transform.Find("card_container/card_container_7").GetComponent<UIFightHeroHead>();
        arr_heads[3] = m_transform.Find("card_container/card_container_8").GetComponent<UIFightHeroHead>();
        arr_heads[4] = m_transform.Find("card_container/card_container_9").GetComponent<UIFightHeroHead>();

        for (int i = 0; i < arr_heads.Length; i++)
        {
            arr_heads[i].SetVisible(false);
        }
    }

    private void InitEvent()
    {
        btn_switch.onClick.AddListener(OnSwitchHero);
        btn_stop.onClick.AddListener(OnStop);
        btn_speed.onClick.AddListener(OnSpeed);
    }

    private void OnSwitchHero()
    {
        IsSwitchHero = !IsSwitchHero;
        UIParticle.Instance.SetActive(IsSwitchHero);
        UIFightBossPointer _s = UIMgr.Instance.LoadUIPrefab<UIFightBossPointer>(UIName.UIFightBossPointer, UIMgr.Layer.layer3);
        _s.gameObject.SetActive(IsSwitchHero);
        _s.SetPosition(Input.mousePosition);
    }

    private void OnStop()
    {
        //BattleManager.Instance.ReStart();
        //return;
        // game stop  below is the test code
        GameObject go = UIMgr.Instance.LoadNewPrefab(UIName.UIItemFlyEff, m_transform);
        //go.transform.SetSiblingIndex(0);
        UIItemFlyEff __eff = go.GetComponent<UIItemFlyEff>();
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(m_transform as RectTransform, Input.mousePosition, CameraManager.Instance.UICamera, out pos);
        Transform __t = m_transform.Find("Image_timeBg/Image_gold");
        Vector2 endPos;
        TransformHelper.UILocalPointToGlobalPoint(m_transform as RectTransform, __t.position, out endPos);
        __eff.MoveItem(pos, endPos);
    }

    private void OnSpeed()
    {
        GameObject _goActiveBall = UIBallManager.Instance.CreatBallAndPlay();
        UI3CBall _3cBall = _goActiveBall.GetComponent<UI3CBall>();
        _3cBall.OnClickActiveBall += On3cBall_OnClickActiveBall;
    }

    private void On3cBall_OnClickActiveBall(RectTransform _rect)
    {
        _uiBallManager.PopBall(_rect);
        _uifightBallMatch.SetBallSprite(_rect.GetComponent<Image>().sprite);
    }


    /*public void SetActors(List<Actor> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            arr_heads[i].Actor = _list[i];
            arr_heads[i].EasyAI = _list[i].gameObject.GetComponent<EasyAI>();
        }
    }*/

    public void SetKillMonsterNum(int num)
    {
        text_kills.text = num.ToString();

    }

}
