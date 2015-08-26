using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UINotice : MonoBehaviour {

    public const string UIName = "UINotice";
    private Transform mTransform;
    private Text text_word;
    private float text_width;
    private static UINotice _instance;

    public static UINotice Instance
    {
        get { return _instance; }
    }
	void Start () {
        Init();
	}

    private void Init()
    {
        _instance = this;
        mTransform = this.transform;
        mTransform.localPosition = new Vector3(0, 240, 0);
        text_word = mTransform.Find("text_word").GetComponent<Text>();

        text_width = (mTransform as RectTransform).sizeDelta.x;
        
        gameObject.SetActive(false);
    }

    public void SetNotice(string notice)
    {
        gameObject.SetActive(true);
        text_word.text = notice;
        Vector2 perferredSize = GetTextAutoSize();
        text_word.transform.localPosition = new Vector3(text_width/2, 0, 0);
       /* TweenParms tp = new TweenParms();
        tp.Prop(UIBase.HOTweenParam.localPosition.ToString(), new Vector3(-(text_width/2 + perferredSize.x), 0, 0));
        tp.Ease(EaseType.Linear);
        tp.OnComplete(() => { gameObject.SetActive(false); });
        HOTween.To(text_word.transform,10,tp);*/
    }

    private Vector2 GetTextAutoSize()
    {
        return new Vector2(text_word.preferredWidth, text_word.preferredHeight);
    }

	
}
