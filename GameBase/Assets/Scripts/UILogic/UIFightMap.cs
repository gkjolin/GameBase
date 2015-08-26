using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIFightMap : UIBase
{

    private Button btn_1;
    private Button btn_2;
    private Button btn_3;
    private Image image;
    private PolygonCollider2D _polygon;
    protected override void Init()
    {
        btn_1 = this.mRectTransfrom.Find("Button 1").GetComponent<Button>();
        btn_2 = this.mRectTransfrom.Find("Button 2").GetComponent<Button>();

        btn_3 = this.mRectTransfrom.Find("Image").GetComponent<Button>();
        _polygon = this.mRectTransfrom.Find("Image").GetComponent<PolygonCollider2D>();
        image = mRectTransfrom.Find("Image").GetComponent<Image>();
        //image.IsRaycastLocationValid
    }
    /*使用2D射线检测
     * 
     *用PolygonCollider2D修改范围。
     **/
    protected override void InitEvent()
    {
        //btn_1.onClick.AddListener(OnClickBtn1);
        //btn_2.onClick.AddListener(OnClickBtn2);
        //btn_3.onClick.AddListener(OnClickBtn1);
    }

    private void OnClickBtn1()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 _v2 = CameraManager.Instance.UICamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D _ray = Physics2D.Raycast(_v2, Vector2.zero);
            if (_ray.collider!= null)
            {
                Debug.Log(" >>>>>>>>>>>>>>>>>>>>>>>> " + _ray.collider.gameObject.name);
            }

            /*Collider2D _c2d = Physics2D.OverlapPoint(_v2);
            if(_c2d != null)
            {
                Debug.Log("------------------------");
            }*/

        }
    }
    private void OnClickBtn2()
    {
        GameInput.Log("btn 2");
    }
}

