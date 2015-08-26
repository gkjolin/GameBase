using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Game;
//using Holoville.HOTween;
public class UIMall : UIBase
{
    private Transform mTransform;
    private Button btn_close;
    private Button btn_call;
    private Button btn_items;
    private Button btn_gifts;
    private Button btn_temp = null;
    private GameObject node_call;
    private GameObject node_items;
    private GameObject node_gifts;
    private GameObject node_temp = null;
    private Button[] arr_btns = new Button[3];
    private GameObject[] arr_nodes = new GameObject[3];

    private GameObject goCube;
    private int _nodeIndex = 0;

    public int NodeIndex
    {
        get { return _nodeIndex; }
        set
        {
            _nodeIndex = value;
            this.SelectNode(_nodeIndex);//
           
        }
    }
    void Start()
    {
        InitUI();
        InitEvent();
    }

    void OnEnable()
    {
        Debug.Log("ui enabled");
    }

    private void InitUI()
    {
        mTransform = this.transform;
        btn_close = mTransform.Find("btn_close").GetComponent<Button>();
        btn_call = mTransform.Find("btn_call").GetComponent<Button>();
        btn_items = mTransform.Find("btn_gifts").GetComponent<Button>();
        btn_gifts = mTransform.Find("btn_items").GetComponent<Button>();
        arr_btns[0] = btn_call; arr_btns[1] = btn_items; arr_btns[2] = btn_gifts;
        
        btn_gifts.transform.SetSiblingIndex(-1);
        node_call = mTransform.Find("node_call").gameObject;
        node_items = mTransform.Find("node_items").gameObject;
        node_gifts = mTransform.Find("node_gifts").gameObject;
        arr_nodes[0] = node_call; arr_nodes[1] = node_items; arr_nodes[2] = node_gifts;

        node_temp = node_call;

    }

    private void InitEvent()
    {
        btn_close.onClick.AddListener(OnClose);
        btn_call.onClick.AddListener(OnClickCall);
        btn_items.onClick.AddListener(OnClickItmes);
        btn_gifts.onClick.AddListener(OnClickGifts);
    }

    private void OnClose()
    {
        UIMgr.Instance.CloseUI("UIMall");
        UIMgr.Instance.ShowUI<UILogin>("UILogin");

        //HOTween.To(btn_close.transform, 0.5f, HOTweenParam.localPosition.ToString(), new Vector3(-300, 216, 0));
    }

    private void OnClickGifts()
    {
        NodeIndex = 2;
    }

    private void OnClickItmes()
    {
        NodeIndex = 1;
    }

    private void OnClickCall()
    {
        NodeIndex = 0;
    }

    private void SelectNode(int node)
    {
        GameObject go = arr_nodes[node];
        if (node_temp != null)
        {
            node_temp.SetActive(false);
        }
        else if (go == node_temp)
        {
            return;
        }
        node_temp = go;
        node_temp.SetActive(true);

        Button btn= arr_btns[node];
        if(btn_temp !=null)
        {
            btn_temp.image.overrideSprite = ResourceManager.Instance.LoadSprite("btn_bg_common",false);
        }
        btn_temp = btn;
        btn_temp.image.overrideSprite = ResourceManager.Instance.LoadSprite("btn_bg_green",false);
    }
}
