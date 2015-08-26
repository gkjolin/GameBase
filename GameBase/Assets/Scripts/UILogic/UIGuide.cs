using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using Game;
using System;
public class UIGuide : UIBase
{

    private static UIGuide _instance;
    private Image _rect1;
    private Image _rect2;
    private Image _rect3;
    private Image _rect4;
    private Image _arrow;
    public Transform _target;
    public static UIGuide Instance
    {
        get { return UIGuide._instance; }
    }
    protected override void Init()
    {
        _instance = this;
        _rect1 = mRectTransfrom.FindChild("Image 1").GetComponent<Image>();//left
        _rect2 = mRectTransfrom.FindChild("Image 2").GetComponent<Image>();//right
        _rect3 = mRectTransfrom.FindChild("Image 3").GetComponent<Image>();//top
        _rect4 = mRectTransfrom.FindChild("Image 4").GetComponent<Image>();//bottom
        _arrow = mRectTransfrom.FindChild("Image_arrow").GetComponent<Image>();
    }

    #region
    private void ResetRect()
    {
        _rect1.rectTransform.sizeDelta = new Vector2(GlobalData.SCREEN_WIDTH / 2, GlobalData.SCREEN_HEIGHT);
        _rect1.rectTransform.anchoredPosition = new Vector2(-GlobalData.SCREEN_WIDTH / 4, 0);

        _rect2.rectTransform.sizeDelta = new Vector2(GlobalData.SCREEN_WIDTH / 2, GlobalData.SCREEN_HEIGHT);
        _rect2.rectTransform.anchoredPosition = new Vector2(GlobalData.SCREEN_WIDTH / 4, 0);

        _rect3.rectTransform.sizeDelta = new Vector2(GlobalData.SCREEN_WIDTH, GlobalData.SCREEN_HEIGHT / 2);
        _rect3.rectTransform.anchoredPosition = new Vector2(0, GlobalData.SCREEN_HEIGHT / 4);

        _rect4.rectTransform.sizeDelta = new Vector2(GlobalData.SCREEN_WIDTH, GlobalData.SCREEN_HEIGHT / 2);
        _rect4.rectTransform.anchoredPosition = new Vector2(0, -GlobalData.SCREEN_HEIGHT / 4);

    }
    #endregion
    protected override void InitEvent()
    {
        SetRectVisible(false);

    }

    public void DrawRect(Vector2 _position, Vector2 _size)
    {
        SetRectVisible(true);
        _rect1.rectTransform.sizeDelta = new Vector2((GlobalData.SCREEN_WIDTH / 2 + _position.x - _size.x / 2), GlobalData.SCREEN_HEIGHT);
        //_rect1.rectTransform.anchoredPosition = new Vector2((_rect1.rectTransform.sizeDelta.x / 2 - GlobalData.SCREEN_WIDTH / 2), 0);
        _rect1.rectTransform.anchoredPosition = new Vector2((_rect1.rectTransform.sizeDelta.x- GlobalData.SCREEN_WIDTH)/2, 0);

        _rect2.rectTransform.sizeDelta = new Vector2(GlobalData.SCREEN_WIDTH - _rect1.rectTransform.sizeDelta.x - _size.x, GlobalData.SCREEN_HEIGHT);
        _rect2.rectTransform.anchoredPosition = new Vector2(_position.x + _size.x / 2 + _rect2.rectTransform.sizeDelta.x / 2, 0);


        /*_rect3.rectTransform.sizeDelta = new Vector2(GlobalData.SCREEN_WIDTH, GlobalData.SCREEN_HEIGHT / 2 - (_position.y + _size.y / 2));
        _rect3.rectTransform.anchoredPosition = new Vector2(0, _position.y + _size.y / 2 + _rect3.rectTransform.sizeDelta.y / 2);

        _rect4.rectTransform.sizeDelta = new Vector2(_rect3.rectTransform.sizeDelta.x, (GlobalData.SCREEN_HEIGHT / 2 + _position.y - _size.y / 2));
        _rect4.rectTransform.anchoredPosition = new Vector2(0, (_rect4.rectTransform.sizeDelta.y / 2 - GlobalData.SCREEN_HEIGHT / 2));*/

        _rect3.rectTransform.sizeDelta = new Vector2(GlobalData.SCREEN_WIDTH - _rect1.rectTransform.sizeDelta.x - _rect2.rectTransform.sizeDelta.x, GlobalData.SCREEN_HEIGHT / 2 - (_position.y + _size.y / 2));
        _rect3.rectTransform.anchoredPosition = new Vector2(_rect1.rectTransform.anchoredPosition.x + _rect1.rectTransform.sizeDelta.x/2+ _rect3.rectTransform.sizeDelta.x / 2, _position.y + _size.y / 2 + _rect3.rectTransform.sizeDelta.y / 2);

        _rect4.rectTransform.sizeDelta = new Vector2(_rect3.rectTransform.sizeDelta.x, (GlobalData.SCREEN_HEIGHT / 2 + _position.y - _size.y / 2));
        _rect4.rectTransform.anchoredPosition = new Vector2(_rect3.rectTransform.anchoredPosition.x, (_rect4.rectTransform.sizeDelta.y / 2 - GlobalData.SCREEN_HEIGHT / 2));

        ArrowFly(_position, _size);
    }
    private void SetRectVisible(bool _visible)
    {
        _arrow.enabled = _visible;
        _rect1.enabled = _visible;
        _rect2.enabled = _visible;
        _rect3.enabled = _visible;
        _rect4.enabled = _visible;
    }

    public void ArrowFly(Vector2 _position, Vector2 _size,Action _callBack = null)
    {
        _arrow.enabled = true;

        DOTween.Kill(_arrow.rectTransform);
        _arrow.rectTransform.DOAnchorPos(new Vector2(_position.x - _size.x / 2 - _arrow.rectTransform.sizeDelta.x / 2, _position.y), 1).OnComplete(() =>
        {
            //DataEventSource.Instance.DispatcherEvent("GuideStart", _target);
            if(_callBack !=null)
            {
                _callBack();
            }
        });

         _arrow.rectTransform.DOLocalMoveX(60, 0.5f).SetRelative(true).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear).SetDelay(1);
    }


    public void TestFindChild(string _name)
    {
        Transform t = GetTransform(_name, UIMgr.Instance.uiRoot.transform);
        if (t != null)
        {
            Debug.Log("find the child name : >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + t.name);
        }
        else
        {
            Debug.Log("not find the child name : >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        }
    }

    public Transform GetTransform(string __name, Transform parent)
    {
        _target = TransformHelper.GetChild(parent, __name);
        return _target;
        #region 
/*Transform _root = parent;
        Transform _target = parent.Find(__name);
        if (_target == null)
        {
            int count = _root.childCount;
            for (int i = 0; i < count; i++)
            {
                Transform _t = _root.GetChild(i);
                _target = _t.Find(__name);
                if (_target != null)
                {
                    //Debug.Log("find transform -------------------------------------- :"+ _target.name);
                    return _target;
                }
                else
                {
                    _target = GetTransform(__name, _t);
                    if (_target != null) return _target;
                }
            }
        }
        return _target;*/
#endregion
    }


    public void GuideEnd()
    {
        this.SetRectVisible(false);
    }
}
