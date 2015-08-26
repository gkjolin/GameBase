using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TransformHelper
{

    public static void SetTransformX(Transform __transform, float x)
    {
        __transform.position = new Vector3(x, __transform.position.y, __transform.position.z);
    }

    public static void SetTransformY(Transform __transform, float y)
    {
        __transform.position = new Vector3(__transform.position.x, y, __transform.position.z);
    }

    public static void SetTransformZ(Transform __transform, float z)
    {
        __transform.position = new Vector3(__transform.position.x, __transform.position.y, z);
    }

    public static void SetTransformLocalX(Transform __transform, float x)
    {
        __transform.localPosition = new Vector3(x, __transform.localPosition.y, __transform.localPosition.z);
    }

    public static void SetTransformLocalY(Transform __transform, float y)
    {
        __transform.localPosition = new Vector3(__transform.localPosition.x, y, __transform.localPosition.z);
    }

    public static void SetTransformLocalZ(Transform __transform, float z)
    {
        __transform.localPosition = new Vector3(__transform.localPosition.x, __transform.localPosition.y, z);
    }

    public static void SetRectTransformAnchoredPositionX(RectTransform __transform, float x)
    {
        __transform.anchoredPosition = new Vector2(x, __transform.anchoredPosition.y);
    }

    public static void SetRectTransformAnchoredPositionY(RectTransform __transform, float y)
    {
        __transform.anchoredPosition = new Vector2(__transform.anchoredPosition.x, y);
    }
    public static Transform GetChild(Transform root, string childName)
    {
        Transform[] children = root.GetComponentsInChildren<Transform>(true);
        int len = children.Length;
        for (int i = 0; i < len; i++)
        {
            if (children[i].name.Equals(childName))
                return children[i];
        }
        return null;
    }
    /// <summary>
    /// 将目标UI的局部坐标 转换为 相对于 __rectTransform 的局部坐标
    /// </summary>
    /// <param name="__rectTransform">参照物</param> 
    /// <param name="__position"></param>目标UI的世界坐标
    /// <param name="__anchorPosition"></param>转换转换的锚点坐标
    public static void UILocalPointToGlobalPoint(RectTransform __rectTransform, Vector3 __position, out Vector2 __anchorPosition)
    {
        Vector2 __screenPoint = RectTransformUtility.WorldToScreenPoint(CameraManager.Instance.UICamera, __position);//将子UI的世界坐标转换为屏幕坐标
        RectTransformUtility.ScreenPointToLocalPointInRectangle(__rectTransform, __screenPoint, CameraManager.Instance.UICamera, out __anchorPosition);//将屏幕坐标转换为UI内的坐标
    }
}
