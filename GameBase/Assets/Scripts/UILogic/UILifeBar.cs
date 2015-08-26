using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class UILifeBar : MonoBehaviour {

    private static UILifeBar _instance;
    private Transform _transform_attach;
//    private Actor _actor;
    private Image bar_hp;

    public Transform Transform_attach
    {
        get { return _transform_attach; }
        set { _transform_attach = value; }
    }
    public static UILifeBar Instance
    {
        get { return UILifeBar._instance; }
    }
    private Transform m_transform;
	void Start () {
        _instance = this;
        m_transform = this.transform;
        bar_hp = m_transform.Find("bar_life").GetComponent<Image>();
        this.Invoke("SetPosition", 1f);
	}

    public void SetPosition()
    {
        /*Vector3 v = SceneMoveTest.Instance.GetHeadScreenPoint();
        m_transform.localPosition = new Vector3(v.x - 1136 / 2, v.y - 640 / 2, 1);*/
        IsInit = true;
    }

    private bool IsInit = false;

    private void ConvertPoint()
    {
        //SceneMoveTest.Instance.transform_actor
    }

    void Update()
    {
        if(IsInit)
        {
            Vector3 v = SceneMoveTest.Instance.GetHeadScreenPoint();
           // Debug.Log("sceeen width : " + Screen.width +  "   sceen height : " + Screen.height   +  "   v " + v) ;
            m_transform.position = new Vector3(v.x, v.y, 1);
            //UpdateBarPosition();
        }

    }

    /*private void UpdateBarPosition()
    {
        if(_actor!=null)
        {
            Vector3 v = CameraManager.Instance.MainCamera.WorldToScreenPoint(new Vector3(_actor.transform.position.x, _actor.transform.position.y + 1.5f, _actor.transform.position.z));
            m_transform.localPosition = new Vector3(v.x - 1136 / 2, v.y - 640 / 2, 1);
        }
    }*/

    public void SetBarLength(float currentValue,float maxValue)
    {
        //transform.GetComponent<Image>().fillAmount = currentValue/maxValue;
        DOTween.To(ChangeValue, transform.GetComponent<Image>().fillAmount, currentValue / maxValue, 1);
    }

    private void ChangeValue(float v)
    {
        bar_hp.fillAmount = v;
    }
	
}
