using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIChat : MonoBehaviour
{
    public const string UIName = "UIChat";
    private Transform mTransform;
    private InputField input_msg;
    private Text text_content;
    private Button btn_send;
    private Transform container_content;

    private Transform content_bg;

    void Start()
    {
        Init();
        InitEvent();
    }

    private void Init()
    {
        mTransform = this.transform;
        input_msg = mTransform.Find("InputField_Msg").GetComponent<InputField>();
        input_msg.textComponent = input_msg.transform.Find("Text").GetComponent<Text>();
        btn_send = mTransform.Find("btn_send").GetComponent<Button>();
        //text_content = mTransform.Find("Image_bg/Text_Content").GetComponent<Text>();
        //text_content.text = "";
        container_content = mTransform.Find("Image_bg/Container_Content");
        content_bg = mTransform.Find("Image_bg");
        //content_bg.GetComponent<ScrollRect>().enabled = false;
    }

    private void InitEvent()
    {
        btn_send.onClick.AddListener(OnSendMsg);
    }

    private int index=0;
    private void OnSendMsg()
    {
        index++;
        CreatText(input_msg.text);
        CalculateContainerHeight();
        input_msg.text = "";
    }

    private int padding_height = 10;
    private float containerHeight = 0;
    private void CalculateContainerHeight()
    {
        float height = 0;
        int childCount = container_content.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Text text = container_content.GetChild(i).GetComponent<Text>();
            height = height + text.preferredHeight+ padding_height;
        }
        containerHeight = height;
        (container_content as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        (container_content as RectTransform).anchoredPosition = new Vector2(20, containerHeight - 530);
        content_bg.GetComponent<ScrollRect>().enabled = height >= 532;
        //Debug.Log("containerHeight : " + containerHeight);
        /*Debug.Log("anchoredPosition " + (container_content as RectTransform).anchoredPosition);
        Debug.Log("position "+(container_content as RectTransform).position);
        Debug.Log("localPosition " + (container_content as RectTransform).localPosition);*/
    }

    private void GetChildCount()
    {
        int childCount = container_content.childCount;
    }

    private void CreatText(string content="")
    {
        GameObject go = new GameObject();
        go.AddComponent<CanvasRenderer>();
        go.transform.SetParent(container_content);
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = new Vector3(0, -containerHeight,0);
        go.name = "txt_msg";
        Text txt = go.AddComponent<Text>();
        txt.supportRichText = true;
        txt.fontSize = 30;
        txt.text = (content != "") ? content : "<color=yellow>[hero1]:</color><color=red>代码生成出来的代码生成出来的代码生成出来的代码生成出来的代码生成出来的代码生成出来的代码生成出来的代码生成出来的的</color>" + index.ToString(); ;
        txt.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        RectTransform rt = go.transform as RectTransform;
        rt.pivot = new Vector2(0, 1);
        rt.anchorMin = rt.anchorMax = new Vector2(0,1);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 850);
        ContentSizeFitter contentSizeFitter = go.AddComponent<ContentSizeFitter>();
        contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        //Debug.Log("文本框大小: " + txt.preferredHeight +  " 。 " + txt.preferredWidth);
    }

}
