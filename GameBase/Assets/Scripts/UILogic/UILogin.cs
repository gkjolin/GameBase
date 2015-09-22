using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Game;
using SLua;
using LuaInterface;

public class UILogin : MonoBehaviour, IPointerClickHandler
{

    private Transform mTransform;
    private Button btn_login;
    private InputField inputName;
    private InputField inputPassword;
    private GameObject goEffect;

    void Start()
    {
        Init();
        InitEvent();
        OnAddStage();
        //DoLua();
    }

    private LuaSvr svr;
    private LuaTable self;
    private void DoLua()
    {
        Debug.Log("init lua in unity");
        svr = new LuaSvr();
        self = (LuaTable)svr.start("LuaFiles/UILoginLua");
        self["transform"] = transform;
        self["name"] = "UILogin";
        LuaFunction Init = (LuaFunction)self["Init"];
        Init.call(self);
    }

    void OnAddStage()
    {
        /*TweenParms tp = new TweenParms();
        this.mTransform.localScale = new Vector3(0.1f, 0.1f, 1);
        tp.Prop(UIBase.HOTweenParam.localScale.ToString(), Vector3.one);
        tp.Ease(EaseType.EaseOutBack);
        HOTween.To(mTransform, 0.2f, tp);*/
    }


    private void Init()
    {
        mTransform = this.transform;
        btn_login = mTransform.Find("btn_login").GetComponent<Button>();
        inputName = mTransform.Find("input_name").GetComponent<InputField>();
        inputPassword = mTransform.Find("input_password").GetComponent<InputField>();

        inputName.textComponent = inputName.transform.Find("Text").GetComponent<Text>();
        inputPassword.textComponent = inputPassword.transform.Find("Text").GetComponent<Text>();

        //goEffect = mTransform.Find("EffectDia").gameObject;
        //goEffect.SetActive(true);
        //Debug.Log((this.transform as RectTransform).sizeDelta.x);
    }

    private void InitEvent()
    {
        //UIEffectManager.Instance.GetUIEffect("EffectDiamond", AddEffect);
        //btn_login.onClick.AddListener(OnLogin);
        //btn_login.onClick.AddListener(delegate() { OnLogin(btn_login.gameObject); });
        UIEventListener.Instance.GetUIEventListener(btn_login.gameObject).OnClick = OnPointerClick;
        //UIEventListener.Instance.GetUIEventListener(btn_login.gameObject).OnDragIng = OnDragIng;
    }

    private void OnDragIng(PointerEventData data)
    {
        Vector2 globalMousePos;
        Vector3 globalMousePos3;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(transform as RectTransform, data.position, data.pressEventCamera, out globalMousePos3);
        Debug.Log("ScreenPointToWorldPointInRectangle> : " + globalMousePos3);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, data.position, data.pressEventCamera, out globalMousePos);
        btn_login.transform.localPosition = globalMousePos;
        btn_login.transform.SetSiblingIndex(mTransform.GetChildCount() - 1);//调增拖动物体的层级为最上层
    }

    private void OnPointerClick(PointerEventData data)
    {
        OnLogin(null);
    }


    private void OnLogin(GameObject go)
    {
        UILoading.Instance.TestLoading();
        //ResourceManager.Instance.LoadTxtTable(""); return; //测试加载数据表
        //i = 0.05f;
        //TestLoading();
        /*UILoading.Instance.TestLoading();
        return;*/
        //ResourceManager.Instance.TestBatchLoad(); return; //测试批量加载资源
        /*UIEffectManager.Instance.GetUIEffect("EffectDiamond", AddEffect); //加载资源
        return;
        goEffect.SetActive(false); return;*/
        //UIMgr.Instance.ShowUI(UITip.UIName, UIMgr.Layer.layer3);
        string username = inputName.text;
        string password = inputPassword.text;
        if (username == "" || password == "")
        {
            UINotice.Instance.SetNotice("用户名和密码不能为空");
            //UITip.Instance.SetTip("用户名和密码不能为空");
            return;
        }
        UIMgr.Instance.CloseUI("UILogin");
        UIMgr.Instance.ShowUI<UIServerlist>("UIServerlist");
    }

    private void AddEffect(GameObject go)
    {
        Debug.Log("goEffct : " + go.name);
        go = Instantiate(go) as GameObject;
        go.SetActive(true);
        go.transform.SetParent(mTransform);
        go.transform.localPosition = new Vector3(0, 0, -10);
        go.transform.localScale = new Vector3(60f, 60f, 60f);
    }

    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("pointer click");
    }


}

[CustomLuaClassAttribute]
public class CallCS
{
    public static void LuaCallCS()
    {
        Debug.Log("lua call cs success");
    }

    private static CallCS _instance;

    public static CallCS Instance
    {
        get { if (_instance == null) { _instance = new CallCS(); } return CallCS._instance; }
    }

    public void CallTest()
    {
        Debug.Log("lua call cs success");
    }

}