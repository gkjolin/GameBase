using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Game;
public class UIFightBallMatch : MonoBehaviour {

    private RectTransform _mRectTransform;
    private Image _imgBall1;
    private Image _imgBall2;
    private Image _imgBall3;

	void Start () {
        Init();
        ResetBall();
	}

    private void Init()
    {
        _mRectTransform = this.transform as RectTransform;
        _imgBall1 = _mRectTransform.Find("Image_ball/ball1").GetComponent<Image>();
        _imgBall2 = _mRectTransform.Find("Image_ball/ball2").GetComponent<Image>();
        _imgBall3 = _mRectTransform.Find("Image_ball/ball3").GetComponent<Image>();
        ResetBall();
    }

    public void SetBallSprite(Sprite _spite)
    {
        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>:"+_imgBall1.transform.Find("Image").GetComponent<Image>().sprite.name);
        if (_imgBall1.transform.Find("Image").GetComponent<Image>().overrideSprite.name == "bottom_02")
        {
            _imgBall1.transform.Find("Image").GetComponent<Image>().overrideSprite = _spite;
            return;
        }
        if (_imgBall2.transform.Find("Image").GetComponent<Image>().overrideSprite.name == "bottom_02")
        {
            _imgBall2.transform.Find("Image").GetComponent<Image>().overrideSprite = _spite;
            return;
        }
        if (_imgBall3.transform.Find("Image").GetComponent<Image>().overrideSprite.name == "bottom_02")
        {
            _imgBall3.transform.Find("Image").GetComponent<Image>().overrideSprite = _spite;
        }
        //SetSmallBallVisible(false);
    }

    public void ResetBall()
    {
        _imgBall1.transform.Find("Image").GetComponent<Image>().overrideSprite = ResourceManager.Instance.LoadSprite("bottom_02");
        _imgBall2.transform.Find("Image").GetComponent<Image>().overrideSprite = ResourceManager.Instance.LoadSprite("bottom_02");
        _imgBall3.transform.Find("Image").GetComponent<Image>().overrideSprite = ResourceManager.Instance.LoadSprite("bottom_02");
    }

    public void SetSmallBallVisible(bool visible)
    {
        _imgBall1.gameObject.SetActive(visible);
        _imgBall2.gameObject.SetActive(visible);
        _imgBall3.gameObject.SetActive(visible);
    }
	
}
