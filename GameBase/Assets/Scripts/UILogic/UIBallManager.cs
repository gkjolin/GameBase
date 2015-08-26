using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class UIBallManager : MonoBehaviour
{

    private static UIBallManager _instance;

    private List<RectTransform> _arrBalls;

    private List<RectTransform> _arrPool;

    private float ball_width = 60;


    public static UIBallManager Instance
    {
        get { return UIBallManager._instance; }
    }

    void Start()
    {
        _instance = this;
        _arrBalls = new List<RectTransform>();
        _arrPool = new List<RectTransform>();
        
    }

    public GameObject CreatBallAndPlay()
    {
        GameObject goBall = GameObject.Instantiate(Resources.Load("Prefabs/btn_ball") as GameObject);
        RectTransform tr = goBall.transform as RectTransform;
        tr.SetParent(transform);
        return goBall;
    }

    private void UpdateBallsPosition(int start=0)
    {
        for (int i = start; i < _arrBalls.Count; i++)
        {
            RectTransform r = _arrBalls[i];
            r.DOLocalMoveX(ball_width, 10 * (ball_width )/ GlobalData.SCREEN_WIDTH).SetRelative(true).SetEase(Ease.Linear);
        }
    }

    public void PutBallToQueue(RectTransform rt)
    {
        if (_arrBalls.Count>4)
        {
            PopFirstBall();
        }
        _arrBalls.Add(rt);
    }

    private void PopFirstBall()
    {
        RectTransform r = _arrBalls[0];
        PopBall(r);
    }

    public void PopBall(RectTransform r)
    {
        int index = _arrBalls.IndexOf(r);
        _arrBalls.Remove(r);
        GameObject.Destroy(r.gameObject);
        UpdateBallsPosition(index);
    }

    public float GetNextEnterBallPosition()
    {
        return GlobalData.SCREEN_WIDTH - UI3CBall.MOVE_AREA - _arrBalls.Count * ball_width + 20;
    }

}
