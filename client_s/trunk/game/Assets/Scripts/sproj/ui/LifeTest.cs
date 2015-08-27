using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 血条
/// @author PT
/// @date 2015-07
/// </summary>
public class LifeTest : MonoBehaviour
{
    //模型坐标
    private Transform headTr;

    //角色血量
    private float hp;

    //角色总血量
    private float totalHp = 4156;

    //血条距离角色高度
    public float playerHeight;

    //UI摄像机对象
    private Camera _uiCamera;
    //场景主摄像机
    public  Camera _mainCamera;

    //对象头顶在3D世界坐标
    private Vector3 worldPostion = new Vector3();

    //对象头顶的3D坐标换算在2D屏幕坐标
    private Vector2 postion;

    //获取场景Canvas组件
    private Canvas _canvas;

    //士兵
    public GeneralSoldier soldier;

    /// <summary>
    /// 限制学校的显示时间
    /// </summary>
    private int _showTime = 0;

    public void Awake()
    {
        _uiCamera = GameObject.Find("UICamera").GetComponent<Camera>();
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    
    void Start()
    {
        hp = soldier._data.HP;
        GameObject.Find("blood_foregroundBar").GetComponent<Image>().fillAmount = 1;

        //获取角色head模型
        headTr = soldier.gameObject.transform.Find("head");

        gameObject.SetActive(false);
    }

    public void Update()
    {
        if(--_showTime<=0)
        {
            gameObject.SetActive(false);
            return;
        }

        positionUpdate();
    }
    
    /// <summary>
    /// 更新血条的位置
    /// </summary>
    private void positionUpdate() 
    {
        //得到模型head坐标
        float size_y = headTr.position.y;

        //得到模型缩放比例
        float scal_y = transform.localScale.y;

        //乘积就是高度
        playerHeight = scal_y * size_y;

        //计算世界坐标
        worldPostion.Set(soldier.transform.position.x, soldier.transform.position.y + playerHeight, soldier.transform.position.z);

        //根据对象头顶的3D坐标换算成它在2D屏幕中的坐标
        postion = _mainCamera.WorldToScreenPoint(worldPostion);
        Vector2 _v2;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent as RectTransform, postion, _uiCamera, out _v2);
        (transform as RectTransform).anchoredPosition = _v2;
    }

    //角色受击减血
    public void OnHit(int dmg)
    {
        _showTime = 150;

        gameObject.transform.Find("blood_foregroundBar").GetComponent<Image>().fillAmount = (hp - dmg) / totalHp;

        //判断角色当前血量
        if ((hp - dmg) <= 0)
        {
            hp = 0;
        }
        //受击减血量
        else
        {
            hp -= dmg;
        }

        positionUpdate();

        gameObject.SetActive(true);
    }
}


