using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIServerlist : MonoBehaviour {

    public const string UI_NAME = "UIServerlist";
    private Transform mTransform;
    private GameObject goBgRange;
    private GameObject goCellRange;
    private GameObject goCellServer;
    private GameObject goRangePanel;
    private GameObject goServerPanel;

	void Start () {
        Init();
	}

    private void Init()
    {
        mTransform = this.transform;
        goBgRange = mTransform.Find("Panel/bg_range").gameObject;
        goCellRange = goBgRange.transform.Find("Panel/cell_range1").gameObject;
        goCellServer = mTransform.Find("Panel/bg_server/Panel/cell_server").gameObject;
        goRangePanel = mTransform.Find("Panel/bg_range").gameObject;
        goServerPanel = mTransform.Find("Panel/bg_server").gameObject;
        SetRangeList();
    }

    public void SetRangeList()
    {
        goServerPanel.transform.Find("Panel").GetChild(0).parent = null;
        for(int i = 0;i<10;i++)
        {
            GameObject go = Instantiate(goCellServer) as GameObject;
            go.transform.SetParent(goServerPanel.transform.Find("Panel"));
            go.transform.localScale = Vector3.one;
            go.transform.Find("Text").GetComponent<Text>().text = "服务器: " + (i + 1);
            go.name = (i + 1).ToString();
            Button btnServer = go.GetComponent<Button>();
            //btnServer.onClick.AddListener(delegate() { OnSelect(btnServer.gameObject); });
            btnServer.onClick.AddListener(delegate{ OnSelect(btnServer.gameObject); });
        }
    }

    private void OnSelect(GameObject go)
    {
        Debug.Log("select server name : " + go.name);
        gameObject.SetActive(false);
        UIMgr.Instance.ShowUI<UICreatRole>("UICreatRole");
    }

    public void SetServerList()
    {

    }
}
