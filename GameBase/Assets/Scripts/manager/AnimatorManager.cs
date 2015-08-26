using UnityEngine;
using System.Collections;
using Game;
using System.Collections.Generic;
public class AnimatorManager : MonoBehaviour
{

    private static AnimatorManager _instance;

    public static AnimatorManager Instance
    {
        get { return AnimatorManager._instance; }
    }

    public string currentActionName;

    public int currentStateHashName;

    public const string Attack_01 = "attack01";
    public const string Attack_02 = "attack02";
    public const string Attack_03 = "attack03";
    public const string idle01 = "idle01";
    public const string hit01 = "hit01";
    public static int atk01Hash;
    public static int atk02Hash;
    public static int atk03Hash;
    public static int idle01Hash;
    public static int run01Hash;
    public static int hit01Hash;


    private bool _isAtk;

    private Dictionary<int, string> _dictHashToString = new Dictionary<int, string>();

    public bool IsAtk
    {
        get { return _isAtk; }
        set { _isAtk = value; }
    }

    void Awake()
    {
        _instance = this;
        Init();
        InitEvent();
    }

    private void Init()
    {
        atk01Hash = StringToHash(Attack_01);
        atk02Hash = StringToHash(Attack_02);
        atk03Hash = StringToHash(Attack_03);
        idle01Hash = StringToHash(idle01);
        run01Hash = StringToHash("run01Hash");
        hit01Hash = StringToHash(hit01);
        //_dictHashToString
    }

    private void InitEvent()
    {
        DataEventSource.Instance.AddEventListener("onStateEnter", OnAnimatorStateEnter);
        DataEventSource.Instance.AddEventListener("onStateExit", OnAnimatorStateExit);
    }

    private void OnAnimatorStateExit(object obj)
    {
        AnimatorStateInfo state = (AnimatorStateInfo)obj;
        if (IsAtkAction())
        {
            IsAtk = false;
        }
        //Animator.SetBool("isAttack", false);
    }

    private void OnAnimatorStateEnter(object obj)
    {
        AnimatorStateInfo state = (AnimatorStateInfo)obj;
        currentStateHashName = state.shortNameHash;
        if (IsAtkAction())
        {
            IsAtk = true;
        }
    }


    private Animator _animator;

    private Animator Animator
    {
        get
        {
            if (_animator == null)
            {
                _animator = GlobalData.hero.MyEnity.Go.GetComponentInChildren<Animator>();
            }
            return _animator;
        }
    }

    private int StringToHash(string name)
    {
        int hash = Animator.StringToHash(name);
        if (_dictHashToString.ContainsKey(hash) == false)
            _dictHashToString.Add(hash, name);
        return hash;
    }

    public string HashToString(int hash)
    {
        return _dictHashToString[hash];
    }
    //判断三连击 返回参数 当作 攻击动作
    public int AtkState()
    {
        if (currentStateHashName == atk01Hash)
        {
            return 2;
        }
        else if (currentStateHashName == atk02Hash)
        {
            return 3;
        }
        return 1;
    }

    private bool IsAtkAction()
    {
        return currentStateHashName == atk01Hash || currentStateHashName == atk02Hash || currentStateHashName == atk03Hash;
    }

    public bool IsSameCurrentAction(string name)
    {
        return currentStateHashName == Animator.StringToHash(name);
    }
    //锁定状态 不能进行 其他操作
    public bool IsLock(int _stateHashName)
    {
        return _stateHashName == atk01Hash || _stateHashName == hit01Hash;
    }

}
