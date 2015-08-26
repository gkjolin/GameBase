using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UICreatRole : MonoBehaviour {

    private Transform mTransform;
    private InputField inputName;
    private Button btn_temp;
    private Button btn_job1;
    private Button btn_job2;
    private Button btn_job3;

    /*public int a = 10;
    public int b;
    [SerializeField]
    private int c;

    public int cc
    {
        get { return c; }
    }*/
	void Start () {
        Init();
	}

    private void Init()
    {
        mTransform = this.transform;
        inputName = mTransform.Find("input_name").GetComponent<InputField>();
        inputName.textComponent = inputName.transform.Find("Text").GetComponent<Text>();
        inputName.text = "请输入名字";

        Button btnHead1 = mTransform.Find("head_1").GetComponent<Button>();
        Button btnHead2 = mTransform.Find("head_2").GetComponent<Button>();
        Button btnEntergame = mTransform.Find("btn_entergame").GetComponent<Button>();
        Button btnRandomname = mTransform.Find("btn_randomName").GetComponent<Button>();

        btnEntergame.onClick.AddListener(OnEnterGame);
        btnRandomname.onClick.AddListener(OnRandomname);

        btn_job1 = mTransform.Find("role_panel/Button_job1").GetComponent<Button>();
        btn_job2 = mTransform.Find("role_panel/Button_job2").GetComponent<Button>();
        btn_job3 = mTransform.Find("role_panel/Button_job3").GetComponent<Button>();

        btn_job1.onClick.AddListener(OnClickJob1);
        btn_job2.onClick.AddListener(OnClickJob2);
        btn_job3.onClick.AddListener(OnClickJob3);

        SetBtnJobState(btn_job1);
    }

    private void OnClickJob1()
    {
        SetBtnJobState(btn_job1);
    }
    private void OnClickJob2()
    {
        SetBtnJobState(btn_job2);
    }
    private void OnClickJob3()
    {
        SetBtnJobState(btn_job3);
    }
    private void SetBtnJobState(Button btn)
    {
        if(btn_temp !=null)
        {
            btn_temp.transform.localScale = new Vector3(0.8f,0.8f,1f);
        }
        else if (btn_temp == btn)
        {
            return;
        }
        btn_temp = btn;
        btn_temp.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnEnterGame()
    {
        UIMgr.Instance.CloseUI("UICreatRole", true);
        UIMgr.Instance.ShowUI<UIMall>("UIMall");
    }

    private void OnRandomname()
    {
        inputName.text = "随机名字";
    }

}
