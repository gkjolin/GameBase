using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CellData
{
    public int index;
    public bool visible = false;

}

public class UIBtn : MonoBehaviour
{
    public CellData cellData;
}

public class UIBag : UIBase
{
    private ScrollRect _scrollRect;
    private RectTransform _contentTransform;
    private int cellHeight = 100;
    public GameObject _cell;
    private List<CellData> _listCellData = new List<CellData>();
    private int _cellCount;//元素总数量，计算出 容易的高度
    private int showCount = 7;//每页显示数量
    private Dictionary<int, GameObject> _dictCell = new Dictionary<int, GameObject>();

    public int CellCount
    {
        get { return _cellCount; }
        set
        {
            _cellCount = value;
            _contentTransform.sizeDelta = new Vector2(300, cellHeight * _cellCount);
        }
    }

    protected override void Init()
    {
        _scrollRect = mRectTransfrom.Find("Panel").GetComponent<ScrollRect>();
        _contentTransform = mRectTransfrom.Find("Panel/content") as RectTransform;
    }

    protected override void InitEvent()
    {
        _scrollRect.onValueChanged.AddListener(OnValueChanged);
        GenerateCellData();
        SetCell(0);
    }

    private int currentIndex = 0;
    private void OnValueChanged(Vector2 arg0)
    {
        float moveDirection = _contentTransform.anchoredPosition.y;
        int index = Mathf.FloorToInt(moveDirection / cellHeight);
        if (currentIndex != index && index > -1 && index < _cellCount)
        {
            currentIndex = index;
            RemoveOutRange(index);
            SetCell(index);
        }
    }

    private void UpdateListLength()
    {

    }

    private void GenerateCellData()
    {
        for (int i = 0; i < 100; i++)
        {
            CellData _data = new CellData();
            _data.index = i;
            _listCellData.Add(_data);
        }
        CellCount = _listCellData.Count;
    }

    private void SetCell(int index)
    {
        for (int i = index; i < index + showCount; i++)
        {
            CreatCell(i);
        }
    }

    private void CreatCell(int index)
    {
        if (index < 0 || index > _cellCount - 1) return;
        if (_dictCell.ContainsKey(index)) return;
        CellData _data = _listCellData[index];
        GameObject _c;
        if (_pool.Count > 0)
        {
            _c = _pool.Dequeue();
            _c.SetActive(true);
        }
        else
        {
            _c = GameObject.Instantiate(_cell);
        }
        _c.transform.Find("Text").GetComponent<Text>().text = index.ToString();
        _c.transform.SetParent(_contentTransform);
        (_c.transform as RectTransform).anchoredPosition = new Vector2(0, -cellHeight * index);
        _c.transform.localScale = Vector2.one;
        UIBtn uiBtn = _c.GetComponent<UIBtn>() == null ? _c.AddComponent<UIBtn>() : _c.GetComponent<UIBtn>();
        uiBtn.cellData = _data;
        _c.name = "cell  " + index;
        _dictCell.Add(index, _c);
    }

    private void RemoveOutRange(int index)
    {
        foreach (KeyValuePair<int, GameObject> _kv in _dictCell)
        {
            PushToPool(_kv.Value);
        }
        _dictCell.Clear();
    }

    private Queue<GameObject> _pool = new Queue<GameObject>();
    private void PushToPool(GameObject _go)
    {
        _go.SetActive(false);
        _go.transform.SetParent(null);
        _pool.Enqueue(_go);
    }

}


