using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIRegister : UIBase {

    private Button btn_register;
    private Button btn_cancle;

    protected override void Init()
    {
        btn_register = mRectTransfrom.Find("Button_register").GetComponent<Button>();
        btn_cancle = mRectTransfrom.Find("Button_cancle").GetComponent<Button>();
    }

    protected override void InitEvent()
    {
        btn_register.onClick.AddListener(OnRegister);
        btn_cancle.onClick.AddListener(OnCancle);
    }

    private void OnCancle()
    {
        UIMgr.Instance.CloseUI(Game.UIName.UIRegister, true);
    }

    private void OnRegister()
    {

    }
}
