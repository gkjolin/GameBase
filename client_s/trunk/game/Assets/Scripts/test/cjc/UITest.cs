using UnityEngine;
using System.Collections;

using UnityEngine.UI;

/// <summary>
/// 测试agent.Stop();后，还是否可以不重合
/// 测试agent.SetDestination(gameObj.transform.position);后，还是否可以不重合
/// CJC
/// </summary>
public class UITest : MonoBehaviour {

    public GameObject _rot;

	// Use this for initialization
	void Start () {

        GameObject stopObj = GameObject.Find("Stop");
        Button StopBtn = stopObj.GetComponent<Button>();
        StopBtn.onClick.AddListener(delegate()
        {
            this.OnClick(stopObj);
        });

        GameObject setDstObj = GameObject.Find("SetDst");
        Button SetDstBtn = setDstObj.GetComponent<Button>();
        SetDstBtn.onClick.AddListener(delegate()
        {
            this.OnClick(setDstObj);
        });


//         GameObject ursObj = GameObject.Find("UpdateRotSprite");
//         Button ursBtn = ursObj.GetComponent<Button>();
//         ursBtn.onClick.AddListener(delegate()
//         {
//             this.OnClick(ursObj);
//         }	
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    /// <summary>
    /// 通过按钮名称为按钮添加点击事件
    /// </summary>
    /// <param name="sender"></param>
    public void OnClick(GameObject sender)
    {
        if (sender.name == "Stop")
        {
            Debug.Log("Stop");

            for(int i=1;i<=10;i++)
            {
                GameObject gameObj = GameObject.Find("sprite" + i);
                NavMeshAgent agent = gameObj.GetComponent<NavMeshAgent>();
                agent.Stop();
            }
            return;
        }

        if (sender.name == "SetDst")
        {
            Debug.Log("SetDst");

            for (int i = 11; i <= 20; i++)
            {
                GameObject gameObj = GameObject.Find("sprite" + i);
                NavMeshAgent agent = gameObj.GetComponent<NavMeshAgent>();
                agent.SetDestination(gameObj.transform.position);
            }
            return;
        }

        if (sender.name == "UpdateRotSprite")
        {
            Debug.Log("UpdateRotSprite");

            RotTestSprite rts = _rot.GetComponent<RotTestSprite>();
            rts.work();
            return;
        }
    }
}
