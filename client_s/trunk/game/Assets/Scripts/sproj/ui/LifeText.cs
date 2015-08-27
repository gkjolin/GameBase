using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class LifeText : MonoBehaviour
{
    //血条距离角色高度
    public float playerHeight = 0;

    //主摄像机对象
    private Camera _camera;

    //模型坐标
    private Transform headTr;

    //对象头顶在3D世界坐标
    private Vector3 worldPostion;

    //对象头顶的3D坐标换算在2D屏幕坐标
    private Vector2 postion;

    public Text dmgText;

    public void setText(GeneralSoldier soldier, string str)
    {
        if(true)
        {
            return;
        }

        //摄像机对象
        _camera = Camera.main;

        //获取角色head模型
        headTr = soldier.gameObject.transform.Find("head");

        //得到模型head坐标
        float size_y = headTr.position.y;

        //得到模型缩放比例
        float scal_y = transform.localScale.y;

        //乘积就是高度
        playerHeight = scal_y * size_y;

        //计算世界坐标
        worldPostion = new Vector3(soldier.gameObject.transform.position.x, soldier.gameObject.transform.position.y + playerHeight, soldier.gameObject.transform.position.z);

        //根据对象头顶的3D坐标换算成它在2D屏幕中的坐标
        postion = _camera.WorldToScreenPoint(worldPostion);

        //得到真实对象头顶的2D坐标
        postion = new Vector2(postion.x, Screen.height - postion.y);

        //设置伤害
        dmgText.text = str;

        //获取画布
        GameObject canvas = GameObject.Find("Canvas");
        dmgText.transform.SetParent(canvas.transform);

        //设置锚点
        RectTransform rt = dmgText.gameObject.transform as RectTransform;
        rt.anchoredPosition = Vector2.zero;
        dmgText.gameObject.transform.localScale = Vector3.one;

        //设置坐标
        dmgText.transform.position = postion;

        //缓动
        iTween.FadeTo(gameObject, 0.1f, 1);

        iTween.ScaleTo(gameObject, new Vector3(2, 2, 2), 1);

        Hashtable hxb = new Hashtable();
        hxb.Add("position", new Vector3(dmgText.transform.position.x, dmgText.transform.position.y + 180, dmgText.transform.position.z));
        hxb.Add("time", 1.1f);
        hxb.Add("easetype", iTween.EaseType.easeOutCubic);
        hxb.Add("oncomplete", "onAnimationEnd");
        hxb.Add("oncompletetarget", this.gameObject);
        hxb.Add("oncompleteparams", this.gameObject.name);
        iTween.MoveTo(gameObject, hxb);
    }

    void onAnimationEnd()
    {
        GameObject.Destroy(gameObject);
    }
}
