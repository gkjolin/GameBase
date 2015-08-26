using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class UIFightBossPointer : MonoBehaviour {

    private Image _imgMouse;
    private Image _imgPoint;
    private RectTransform _rectTransform;
	void Start () {
       // Init();
	}

    private void Init()
    {
        _rectTransform = this.transform as RectTransform;
        _imgPoint = _rectTransform.Find("Image_point").GetComponent<Image>();
        _imgPoint.transform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.3f).SetLoops(-1, LoopType.Yoyo);
    }

    public void SetPosition(Vector3 _position)
    {
        Init();
        Vector2 _pos;
        //TransformHelper.UILocalPointToGlobalPoint(_rectTransform.parent as RectTransform, _position, _pos);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform.parent as RectTransform, _position,CameraManager.Instance.UICamera, out _pos);
        _rectTransform.anchoredPosition = _pos;
    }
	
}
