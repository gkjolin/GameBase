using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Game;
public class GameInput : MonoBehaviour
{
    private static GameInput _instance;
    private float _speed = 1.5f;

    public event Action OnUpdate;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Debug.Log("gameinput start");
    }

    private void Update()
    {
        if(OnUpdate!=null)
        {
            OnUpdate();
        }
    }

    public static GameInput Instance
    {
        get { if (_instance == null) { _instance = new GameInput(); } return GameInput._instance; }
    }

    public void JoystickMove(Vector2 arg0)
    {
        Vector3 _v3 = new Vector3(arg0.x, 0, arg0.y);
        if (GlobalData.hero == null) return;
        GlobalData.hero.MyEnity.SetProperty("actionName", "run01");
        GlobalData.hero.MyEnity.SetProperty("rotation", _v3);
        //GlobalData.hero.Animator.Play("run01");
        Vector3 _v33 = _v3 * Time.deltaTime * _speed;
        GlobalData.hero.MyEnity.SetProperty("position", _v33);
    }
    public void EasyButton()
    {
        //TestTree _tree = new TestTree();
    }

    public static void DebugLog(string log)
    {
        if (!_isLog) return;
        Debug.Log(log);
    }

    public static void Log(string fmt, params object[] args)
    {
#if UNITY_5_0
        Debug.LogFormat(fmt, args);
#else
        Debug.Log(string.Format(fmt, args));
#endif
    }

    public static void Log(string log)
    {
        if (!_isLog) return;
        Debug.Log(log);
    }

    public static bool _isLog = true;
    public void HeroUseAtk()
    {
        //Debug.Log("AtkState : " + AnimatorManager.Instance.AtkState());
        int index = AnimatorManager.Instance.AtkState() - 1;
        index = 0;
        GlobalData.hero.MyEnity.SetProperty("actionName", _arrAtks[index]);
        //UIMgr.Instance.LoadUIPrefab<UICombo>("UICombo", UIMgr.Layer.layer2).StartCombo();
        /*TestEnity _t = new TestEnity();
        GlobalData.hero = _t;*/
    }

    private string[] _arrAtks = new string[3]{"attack01", "attack02", "attack03"};
}
