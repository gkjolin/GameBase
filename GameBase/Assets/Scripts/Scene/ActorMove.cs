using UnityEngine;
using System.Collections;
using DG.Tweening;
public class ActorMove : MonoBehaviour {

    private Transform m_transform;
    private Transform transform_parent;
    private Animator animator;
	private void Start () {
        Init();
	}

    private void Init()
    {
        m_transform = this.transform;
        animator = m_transform.Find("Soldier").GetComponent<Animator>();
        transform_parent = m_transform.parent;
    }

    public void Move(int direction)
    {
        animator.SetFloat("MoveSpeed",1);
        float rotation = direction == 1 ? -90 : 90;
        animator.transform.localRotation = Quaternion.Euler(new Vector3(0, rotation, 0));
        m_transform.DOLocalMoveX(1 * -direction, 1).SetRelative(true).SetEase(Ease.Linear).OnComplete(() => { animator.SetFloat("MoveSpeed", 0); });
    }

    private Tweener _tweener;
    public float move_time;
    public void DoMove(float mouseclickx)
    {
        float distance = mouseclickx - m_transform.position.x;
        move_time = Mathf.Abs(distance);
        float endx = m_transform.localPosition.x + (distance) ;
        if (endx < -11) endx = -11;
        else if (endx > 11) endx = 11;
        if(endx>m_transform.localPosition.x)
        {
            animator.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        else
        {
            animator.transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
//        Debug.Log("actor move distance : " + distance);
        animator.SetFloat("MoveSpeed", 1);
        if(_tweener!=null)
        {
            _tweener.Kill();
        }
        _tweener =  m_transform.DOLocalMoveX(endx, Mathf.Abs(distance)).SetEase(Ease.Linear).OnComplete(() => { animator.SetFloat("MoveSpeed", 0); });
    }
	
}
