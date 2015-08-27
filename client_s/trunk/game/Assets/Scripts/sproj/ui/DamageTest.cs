using UnityEngine;
using System.Collections;

public class DamageTest : MonoBehaviour
{

    //伤害文字距离角色高度
    public float playerHeight = 0;
    
    //红色血条贴图
    public GUIText DmgText;

    //主摄像机对象
    private Camera _camera;

    //模型坐标
    private Transform headTr;

    //对象头顶在3D世界坐标
    private Vector3 worldPostion;

    //对象头顶的3D坐标换算在2D屏幕坐标
    private Vector2 postion;

    //角色对象
    GameObject Player;

    //伤害数字
    int dmgNum;

    void Start()
    {
        //根据Tag得到主角对象
        Player = GameObject.FindGameObjectWithTag("Player");

        //摄像机对象
        _camera = Camera.main;

        //获取角色head模型
        headTr = gameObject.transform.Find("head");

        //得到模型head坐标
        float size_y = headTr.position.y;

        //得到模型缩放比例
        float scal_y = transform.localScale.y;
        Debug.Log(scal_y);
        //乘积就是高度
        playerHeight = scal_y * size_y;
        Debug.Log(playerHeight);
    }

    void Update()
    {

    }

    void OnGUI()
    {
        //得到对象头顶在3D世界中的坐标
        //默认对象坐标点在脚下，所以加上它模型的高度
        worldPostion = new Vector3(transform.position.x, transform.position.y + playerHeight, transform.position.z);

        //根据对象头顶的3D坐标换算成它在2D屏幕中的坐标
        postion = _camera.WorldToScreenPoint(worldPostion);

        //得到真实对象头顶的2D坐标
        postion = new Vector2(postion.x, Screen.height - postion.y);

        //计算对象名称的宽高
        GUI.skin.label.fontSize = 24;
        Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(name));

        //设置显示颜色为绿色
        GUI.color = Color.green;

        ////绘制对象名称
        //GUI.Label(new Rect(postion.x - (nameSize.x / 2),
        //                   postion.y - nameSize.y - bloodSize.y / 6,
        //                   nameSize.x, nameSize.y), name);
    }


    //头顶伤害飘字
    void DmgFloat()
    {

    }
}
