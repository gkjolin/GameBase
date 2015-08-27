using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

using XingLuoTianXia.lib;

public class NewBehaviourScript : MonoBehaviour {

    private List<GameObject> soldiers = new List<GameObject>();

    //倒计时
    private int time;


    LineupData data1;
    LineupData data2;
    LineupData data3;
    LineupData data4;
    LineupData data5;
    RectangleLineup lineup1;
    RectangleLineup lineup2;
    RoundLineup lineup3;
    TriangleLineup lineup4;
    RectangleLineup lineup5;

	// Use this for initialization
	void Start () {

        //士兵
        for (int i = 0; i < 12; i++)
        {
            soldiers.Add(ResourceManager.getInstance().getGameObject("A_JS_RenLei_A_001"));
        }


        //一字
        data1 = new LineupData();
        data1.point = new Vector3(0, 0, 0);
        data1.room = new int[5]{1,1,1,12,1};
        lineup1 = new RectangleLineup(data1);

        //长方形
        data2 = new LineupData();
        data2.point = new Vector3(0, 0, 0);
        data2.room = new int[5] { 1, 1, 1, 3, 4 };
        lineup2 = new RectangleLineup(data2);

        //圆形
        data3 = new LineupData();
        data3.point = new Vector3(0, 0, 0);
        data3.room = new int[2] { 2,5};
        lineup3 = new RoundLineup(data3);

        //三角形
        data4 = new LineupData();
        data4.point = new Vector3(0, 0, 0);
        data4.room = new int[2] {1, 12};
        lineup4 = new TriangleLineup(data4);

        //正方形
        data5 = new LineupData();
        data5.point = new Vector3(0, 0, 0);
        data5.room = new int[5] { 1, 1, 1, 4, 4 };
        lineup5 = new RectangleLineup(data5);
	}

    // Update is called once per frame
    void Update()
    {
        
        if (time == 0)
        {
            for (int i = 0; i < 12; i++)
            {
                Animator animator = soldiers[i].GetComponent<Animator>();
                animator.Play("run01");
                soldiers[i].transform.position = lineup1.getPoint(i);
            }
        }
        else if (time == 60)
        {
            for (int i = 0; i < 12; i++)
            {
                Animator animator = soldiers[i].GetComponent<Animator>();
                animator.Play("run02");
                soldiers[i].transform.position = lineup2.getPoint(i);
            }
        }
        else if(time == 120)
        {
            for (int i = 0; i < 12; i++)
            {
                Animator animator = soldiers[i].GetComponent<Animator>();
                animator.Play("run01");
                soldiers[i].transform.position = lineup3.getPoint(i);
            }
        }
        else if (time == 180)
        {
            for (int i = 0; i < 12; i++)
            {
                Animator animator = soldiers[i].GetComponent<Animator>();
                animator.Play("run02");
                soldiers[i].transform.position = lineup4.getPoint(i);
            }
        }
        else if (time == 240)
        {
            for (int i = 0; i < 12; i++)
            {
                Animator animator = soldiers[i].GetComponent<Animator>();
                animator.Play("run01");
                soldiers[i].transform.position = lineup5.getPoint(i);
            }
            time = -60;
        }
        else
        {
            for (int i = 0; i < 12; i++)
            {
                //soldiers[i].transform.position = new Vector3(soldiers[i].transform.position.x, soldiers[i].transform.position.y, soldiers[i].transform.position.z + 0.05f);
            }
        }

        time++;
	}
}
