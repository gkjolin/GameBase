using UnityEngine;
using System.Collections;
using Game;
using UnityEngine.UI;
public class UILifeBar2 : MonoBehaviour {

    private Image bar;
    private RectTransform m_RectTransform;
    public Transform _actor;
    private RectTransform parent;
    public Camera _camera;
    private void Awake()
    {
        m_RectTransform = this.transform as RectTransform;
        bar = m_RectTransform.Find("Bar").GetComponent<Image>();
    }

    void Start()
    {
        parent = UIMgr.Instance.GetLayer(UIMgr.Layer.layer2) as RectTransform;
    }

    void Update()
    {
        UpdateBarPosition();
    }

    private void UpdateBarPosition()
    {
        if (_actor != null)
        {
            Vector2 _v2Screen = RectTransformUtility.WorldToScreenPoint(_camera, _actor.position);
            Vector2 outV;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, _v2Screen, CameraManager.Instance.UICamera, out outV);
            m_RectTransform.anchoredPosition = new Vector2(outV.x,outV.y + 130) ;

            /*Vector3 v = _camera.WorldToScreenPoint(_actor.position);
            v = CameraManager.Instance.UICamera.ScreenToWorldPoint(v);
            transform.position = new Vector3(v.x, v.y, 1);*/
        }
    }

    public void SetBarLength(float currentValue, float maxValue)
    {
        bar.fillAmount = currentValue / maxValue;
        if (currentValue <= 0)
        {
            bar.fillAmount = 1;
            gameObject.SetActive(false);
            _actor = null;
        }
    }
	
}
