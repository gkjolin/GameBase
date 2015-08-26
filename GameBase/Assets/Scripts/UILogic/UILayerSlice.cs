using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.EventSystems;
public class UILayerSlice : MonoBehaviour,IPointerClickHandler
{

    private Transform m_transform;
    private Transform tf_l1;
    private Transform tf_l2;
    private float l1_width;
    private float l2_width;
    private GameObject goHero;
    private Animator animatorHero;

    void Start()
    {
        //Init();
    }

    private void Init()
    {
        m_transform = this.transform;
        tf_l1 = m_transform.Find("L1");
        tf_l2 = m_transform.Find("L2");

        l1_width = 1350 * 2;
        l2_width = 1350 * 1.5f;

        l1_width = 2500;

        goHero = m_transform.Find("Soldier").gameObject;
        animatorHero = goHero.GetComponent<Animator>();
    }

    private void HeroAction()
    {
        animatorHero.Play("Idle_Run");
        animatorHero.SetFloat("MoveSpeed", 1);
    }

    private void MoveLayer()
    {
        tf_l1.DOLocalMoveX((Screen.width - l1_width), 15).OnComplete(() => { (tf_l1 as RectTransform).anchoredPosition = new Vector2(0f, -11f); MoveLayer(); }).SetEase(Ease.Linear);
        tf_l2.DOLocalMoveX((Screen.width - l1_width) * 0.6f, 15).OnComplete(() => { (tf_l2 as RectTransform).anchoredPosition = new Vector2(1136f, -19f); }).SetEase(Ease.Linear);
    }

    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        MoveLayer();
        animatorHero.SetFloat("MoveSpeed", 1);
    }
}
