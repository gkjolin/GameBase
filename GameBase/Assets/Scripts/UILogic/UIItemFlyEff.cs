using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class UIItemFlyEff : MonoBehaviour
{
    private RectTransform mRectTransform;
    void Start()
    {
    }

    private void OnComplete()
    {
        GameObject.Destroy(gameObject);
    }

    public void MoveItem(Vector3 vStart, Vector3 vEnd)
    {
        mRectTransform = this.transform as RectTransform;
        mRectTransform.localPosition = vStart;
        int offx = Random.Range(0, 100);
        mRectTransform.DOLocalMoveY(50, 0.2f).SetRelative(true).SetEase(Ease.OutQuad);
        mRectTransform.DOLocalMoveY(-300 - offx, 0.8f).SetRelative(true).SetEase(Ease.OutBounce).OnComplete(OnComplete).SetDelay(0.2f);
        int isRoolBack = Random.Range(0, 100) > 50 ? 1 : -1;
        mRectTransform.DOLocalMoveX((200 + offx) * isRoolBack, 1f).SetRelative(true).SetEase(Ease.Linear);
        //mRectTransform.DOLocalMove(vEnd, 1).OnComplete(OnComplete).SetEase(Ease.OutBounce);
    }

}
