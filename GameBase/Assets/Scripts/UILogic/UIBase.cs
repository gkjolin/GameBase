using UnityEngine;
using System.Collections;
using Game;
using System.Collections.Generic;
public class UIBase : MonoBehaviour {

    protected RectTransform mRectTransfrom;
    void Awake()
    {
        mRectTransfrom = this.transform as RectTransform;
        Init();
    }
    void Start()
    {
        InitEvent();
    }

    protected virtual void Init() { }
    protected virtual void InitEvent() { }

    /// <summary>
    /// ui 事件监听，ui初始化时候添加
    /// </summary>
    public virtual void AddEventListener() { }
    /// <summary>
    ///ui事件移除，ui destory 时候销毁注册监听的事件 手动添加要销毁的 方法调用
    /// </summary>
    public virtual void RemoveEventListener() { }
    public virtual void InitInfo(object info)
    {

    }

    /// <summary>
    /// 销毁
    /// </summary>
    public virtual void Destroy()
    {
        RemoveEventListener();
        RemoveAllEventListener();
        GameObject.Destroy(gameObject);
    }

    /// <summary> 
    /// ui 数据的绑定 需要子类重写此方法  
    /// </summary>
    /// <param name="eventAgrs"></param>
    public virtual void HandlerData<T>(DataEventArgs<T> eventArgs) { }


    private List<DataEvent> _listDataEvent;

    public List<DataEvent> ListDataEvent
    {
        get
        {
            if (_listDataEvent == null) _listDataEvent = new List<DataEvent>();
            return _listDataEvent;
        }
    }

    public void AddEvent(DataEvent eventKey)
    {
        ListDataEvent.Add(eventKey);
    }

    /// <summary>
    /// destory时候需要移除事件
    /// </summary>
    public void RemoveAllEventListener()
    {
        if (_listDataEvent != null)
        {
            foreach (DataEvent _event in _listDataEvent)
            {
                DataEventSource.Instance.UnRegEvent(_event, this);
            }
            _listDataEvent.Clear();
            _listDataEvent = null;
        }
    }
}

