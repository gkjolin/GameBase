using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIFightMain : MonoBehaviour
{

    private RectTransform m_transfrom;
    private Button btn_atk;
    private Button btn_skill1;
    private Button btn_skill2;
    private Button btn_skill3;
    private Button btn_skill4;
    private Button[] _arrBtns;

    void Awake()
    {
        Init();
    }

    void Start()
    {
        AddEvent();
        //InitEvent();
    }

    private void Init()
    {
        m_transfrom = this.transform as RectTransform;
        Transform _btns = m_transfrom.Find("btn_container");
        btn_atk = _btns.Find("btn_atk").GetComponent<Button>();
        btn_skill1 = _btns.Find("btn_skill1").GetComponent<Button>();
        btn_skill2 = _btns.Find("btn_skill2").GetComponent<Button>();
        btn_skill3 = _btns.Find("btn_skill3").GetComponent<Button>();
        btn_skill4 = _btns.Find("btn_skill4").GetComponent<Button>();
        _arrBtns = new Button[5] { btn_atk, btn_skill1, btn_skill2, btn_skill3, btn_skill4 };
    }

    private void AddEvent()
    {
        btn_atk.onClick.AddListener(OnAtk);

        /*for (int i = 0; i < _arrBtns.Length; i++)
        {
            Button _btn = _arrBtns[i];
            int c = i;
            _btn.onClick.AddListener(() =>
            {
                OnBtn(_btn, c);
            });
        }*/
    }


    protected void InitEvent()
    {
        for (int i = 0; i < _arrBtns.Length; i++)
        {
            Button _btn = _arrBtns[i];
            if (_btn.gameObject.GetComponent<UIBtnCD>() == null)
            {
                _btn.gameObject.AddComponent<UIBtnCD>();
            }
            int c = i;
            _btn.onClick.AddListener(() =>
            {
                OnBtn(_btn, c);
            });
        }
    }

    private void OnBtn(Button _btn, int i)
    {
        UIBtnCD _cd = _btn.transform.GetComponent<UIBtnCD>();
        if (!_cd.isCD)
        {
            _cd.SetMask();
        }
        else
        {

        }
    }

    private void OnAtk()
    {
        GameInput.Instance.HeroUseAtk();
    }


    /*private void OnBtn(Button _btn, int i)
    {
        UIBtnCD _cd = _btn.transform.GetComponent<UIBtnCD>();
        if (_cd != null)
        {
            if (!_cd.isCD)
            {
                GameInput.Instance.HeroUseAtk();
            }
            _cd.SetMask();
        }
    }*/
}
