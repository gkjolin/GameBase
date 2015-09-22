using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UISpriteAnimation : MonoBehaviour
{

    private Image image;

    public int imageCount = 5;

    public int frame = 1;

    public string imagePre="Diamonds_0";

    private int curIndex = 1;

    private float duration;
    
    public bool isPlay = false;

    private RectTransform mTransform;

    void Awake()
    {
        mTransform = this.transform as RectTransform;
        image = mTransform.GetComponent<Image>();
    }
    void Start()
    {
        duration = (float)1 / frame;
    }

    void FixedUpdate()
    {
        if (isPlay)
        {
            GetSprite();
        }
    }

    private void Reset()
    {
        curIndex = 0;
    }

    private float durationTime = 0;
    private void GetSprite()
    {
        durationTime = durationTime + Time.deltaTime;
        if (durationTime <= duration) return;
        durationTime = 0;
        string imageName = "UI_DEMO2/Dia/" + imagePre + curIndex;
        Sprite s = Resources.Load(imageName, typeof(Sprite)) as Sprite;
        image.overrideSprite = s;
        curIndex++;
        if (curIndex > imageCount) curIndex = 0;
    }

    public void SetParent(RectTransform parent,Vector2 position)
    {
        mTransform.SetParent(parent);
        mTransform.anchoredPosition = position;
    }

}
