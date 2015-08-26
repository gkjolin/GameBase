using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class UI3CBall : MonoBehaviour
{
    public const int MOVE_AREA = 800;
    public const int CLICK_AREA = 380;
    private Transform m_transform;
    private bool _isPick = false;
    private Button btn_ball;
    private RectTransform m_rectTransform;

    public delegate void ClickActiveBall(RectTransform _rect);
    public event ClickActiveBall OnClickActiveBall;
    public bool IsPick
    {
        get { return _isPick; }
        set
        {
            _isPick = value;
        }
    }
    void Start()
    {
        Init();
    }

    private void Init()
    {
        m_transform = this.transform;
        m_rectTransform = this.transform as RectTransform;

        m_rectTransform.localScale = Vector3.one;
        m_rectTransform.anchoredPosition = new Vector2(-25, -129);

        btn_ball = m_transform.GetComponent<Button>();
        btn_ball.onClick.AddListener(OnClickBall);
        Move();
    }

    private void OnClickBall()
    {
        if (_isPick)
        {
            _isPick = false;
            //UIBallManager.Instance.PopBall(m_rectTransform);
            if(OnClickActiveBall!=null)
            {
                OnClickActiveBall(m_rectTransform);
            }

        }
    }

    private Tweener tweener;
    public void Move()
    {
        m_rectTransform.localScale = new Vector3(0.5f,0.5f,0.5f);
        float t1 = GetMoveTime(MOVE_AREA);
        tweener = m_rectTransform.DOLocalMoveX(MOVE_AREA, t1).SetRelative(true).SetEase(Ease.Linear).OnComplete(UpdateX);
    }

    private float GetMoveTime(float distance)
    {
        return 10 * distance / GlobalData.SCREEN_WIDTH;
    }

    private void UpdateX()
    {
        m_rectTransform.DOScale(Vector3.one, 0.2f);
        PushToQueue();
        float endx = UIBallManager.Instance.GetNextEnterBallPosition();
        float t2 = GetMoveTime(endx);
        m_rectTransform.DOLocalMoveX(endx, t2).SetRelative(true).SetEase(Ease.Linear).OnComplete(() => { _isPick = true; });
    }

    private void PushToQueue()
    {
        UIBallManager.Instance.PutBallToQueue(m_rectTransform);
    }

    private void DestorySelf()
    {
        GameObject.Destroy(gameObject);
    }

}

