using UnityEngine;
using System.Collections;
using DG.Tweening;
public class UITestDotweenPath : MonoBehaviour
{
    private RectTransform m_transform;
    void Start()
    {
        m_transform = this.transform as RectTransform;
        this.Invoke("Play",1);
    }

    private void Play()
    {
        Vector3[] _arrV3 = new Vector3[3];
        _arrV3[0] = new Vector3(0, 0, 0);
        _arrV3[1] = new Vector3(200, 200, 0);
        _arrV3[2] = new Vector3(400, 50, 0);
        m_transform.DOLocalPath(_arrV3,0.5f).SetEase(Ease.OutCubic);
        DOTweenAnimation dot = new DOTweenAnimation();
        //dot.
    }

}
