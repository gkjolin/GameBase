using UnityEngine;
using System.Collections;
using System;
using Game;
public class GlobalData : MonoBehaviour
{

    private static GlobalData _instance;
    public const int SCREEN_WIDTH = 1136;

    public const int SCREEN_HEIGHT = 640;
    public static GlobalData Instance
    {
        get { return _instance; }
    }
    void Start()
    {
        _instance = this;
        Debug.Log("global data start");
    }

    /*void Update () {
	
    }*/

    public void Delay(float duration, Action<object> callBack, object obj, float delay = 0)
    {
        this.StartCoroutine(DelayCoroutine(duration, callBack, obj));
    }

    public void Delay(float duration, Action callBack, float delay = 0)
    {
        this.StartCoroutine(DelayCoroutine(duration, callBack, delay));
    }

    private IEnumerator DelayCoroutine(float duration, Action callBack, float delay = 0)
    {
        yield return new WaitForSeconds(duration + delay);
        if (callBack != null)
        {
            callBack();
        }
    }

    private IEnumerator DelayCoroutine(float duration, Action<object> callBack, object obj, float delay = 0)
    {
        yield return new WaitForSeconds(duration + delay);
        if (callBack != null)
        {
            callBack(obj);
        }
    }

    public static TestEnity hero;

}
