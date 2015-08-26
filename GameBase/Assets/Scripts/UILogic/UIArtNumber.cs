using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class UIArtNumber{

    /*public static Transform CreatNumber(string strNum,Transform attach,Vector3 v3)
    {
        GameObject go = new GameObject("Num " + strNum);
        for (int i = 0; i < strNum.Length; i++)
        {
            char num = strNum[i];
            Transform transform = CreatSpriteRenderer(num);
            transform.SetParent(go.transform);
            transform.localScale = Vector3.one;
            transform.localPosition = new Vector3(i * numWidth, 0, 0);
        }
        float fontWidth = numWidth * strNum.Length;
        go.transform.SetParent(attach);
        go.transform.localPosition = new Vector3(-(fontWidth / 2),1.5f, 0);
        go.transform.localScale = new Vector3(2,2,2);
        //go.transform.position = new Vector3(v3.x - (fontWidth / 2),v3.y,v3.z);
        //go.layer = LayerMask.NameToLayer("UI3D");
        Transform t = go.transform;
        MoveNumber(t,1,2);
        return t;
    }*/

    /*public static Transform CreatNumber(string strNum, Transform attach, float offsetY = 1.5f)
    {
        GameObject go = new GameObject("Num " + strNum);
        for (int i = 0; i < strNum.Length; i++)
        {
            char num = strNum[i];
            Transform transform = CreatSpriteRenderer(num);
            transform.SetParent(go.transform);
            transform.localScale = Vector3.one;
            transform.localPosition = new Vector3(i * numWidth, 0, 0);
        }
        float fontWidth = numWidth * strNum.Length;
        go.transform.SetParent(attach);
        go.transform.localPosition = new Vector3(-(fontWidth / 2), offsetY - 0.4f, 0);
        go.transform.localScale = new Vector3(2, 2, 2);
        Transform t = go.transform;
        MoveNumber(t, 0.25f, 0.8f, 0.15f);
        return t;
    }*/

    private static float numWidth;
    private static Transform CreatImage(char num)
    {
        GameObject go = new GameObject();
        Image img = go.AddComponent<Image>();
        //string path = "Assets/IconsPackage/number/heroNumber_" + num + ".png";
        //img.sprite = Resources.LoadAssetAtPath(path, typeof(Sprite)) as Sprite;
        img.sprite = Resources.Load("UI_DEMO2/0" + num, typeof(Sprite)) as Sprite;
        img.SetNativeSize();
        go.name = "Num " + num;
        numWidth = (go.transform as RectTransform).sizeDelta.x;
        return go.transform;
    }

    public static Transform CreatUINumber(string strNum, Transform attach, float offsetY = 0)
    {
        GameObject go = new GameObject("Num " + strNum);
        for (int i = 0; i < strNum.Length; i++)
        {
            char num = strNum[i];
            Transform transform = CreatImage(num);
            transform.SetParent(go.transform);
            transform.localScale = Vector3.one;
            transform.localPosition = new Vector3(i * numWidth, 0, 0);
        }
        //float fontWidth = numWidth * strNum.Length;
        go.transform.SetParent(attach);
        go.transform.localPosition = new Vector3(0, offsetY, 0);
        go.transform.localScale = new Vector3(1, 1, 1);
        Transform t = go.transform;
        return t;
    }

    /*private static Transform CreatSpriteRenderer(char num)
    {
        GameObject go = new GameObject();
        SpriteRenderer spriteRenderer = go.AddComponent<SpriteRenderer>();
        string path = "Assets/IconsPackage/UI_release/num/R0" + num + ".png";
        spriteRenderer.sprite = Resources.LoadAssetAtPath(path, typeof(Sprite)) as Sprite;
        go.name = "Num" + num;
        numWidth = spriteRenderer.bounds.size.x;
        //go.layer = LayerMask.NameToLayer("UI3D");
        return go.transform;

    }*/
    public static void MoveNumber(Transform target, float durationTime, float distance, float delayTime)
    {
        target.DOScale(Vector3.zero, 0);
        target.DOMoveY(distance, durationTime).SetRelative(true).OnComplete(() =>
        {
            GlobalData.Instance.Delay(delayTime, (o) => { DestoryTransform(o as Transform); }, target);
        });
        target.DOScale(new Vector3(2.2f, 2.2f, 2.2f), durationTime);
    }

    public static void DestoryTransform(Transform target)
    {
        target.SetParent(null);
        GameObject.Destroy(target.gameObject);
        return;
    }
}
