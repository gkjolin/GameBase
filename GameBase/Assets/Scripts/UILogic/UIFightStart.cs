using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using Game;
public class UIFightStart : MonoBehaviour
{

    private RectTransform m_transform;
    private Image img_word1;
    private Image img_word2;
    private Image img_top;
    private Image img_bottom;
    void Start()
    {
        Init();
    }

    private void Init()
    {
        m_transform = this.transform as RectTransform;
        img_word1 = m_transform.Find("img_word1").GetComponent<Image>();
        img_word2 = m_transform.Find("img_word2").GetComponent<Image>();
        img_top = m_transform.Find("img_top").GetComponent<Image>();
        img_bottom = m_transform.Find("img_bottom").GetComponent<Image>();

        img_top.rectTransform.anchoredPosition = new Vector2(0, 0);
        img_bottom.rectTransform.anchoredPosition = new Vector2(0, 0);
        img_word1.rectTransform.anchoredPosition = new Vector2(-180, 0);
        img_word2.rectTransform.anchoredPosition = new Vector2(180, 0);
        m_transform.sizeDelta = new Vector2(400, 0);
        m_transform.anchoredPosition = new Vector2(0, 200);
        gameObject.SetActive(false);
        this.Invoke("PlayEffect", 1f);
    }

    private void OnBecameVisible()
    {
        Debug.Log("on became visible");
    }

    private void OnBecameInvisible()
    {
        Debug.Log("on became in visible");
    }

    private void PlayEffect()
    {
        gameObject.SetActive(true);

        m_transform.sizeDelta = new Vector2(0, 0);
        m_transform.DOSizeDelta(new Vector2(400, 70), 0.2f);

        img_top.rectTransform.anchoredPosition = new Vector2(0, 0);
        img_bottom.rectTransform.anchoredPosition = new Vector2(0, 0);
        img_word1.rectTransform.anchoredPosition = new Vector2(-180, 0);
        img_word2.rectTransform.anchoredPosition = new Vector2(180, 0);

        img_top.rectTransform.DOLocalMoveY(40, 0.2f);
        img_bottom.rectTransform.DOLocalMoveY(-40, 0.2f);
        img_word1.rectTransform.DOLocalMoveX(-45, 0.2f).SetDelay(0.2f);
        img_word2.rectTransform.DOLocalMoveX(45, 0.2f).SetDelay(0.2f).OnComplete(() =>
        {
            GlobalData.Instance.Delay(1, () =>
            {
                gameObject.SetActive(false);
                /*TestEnity _t = new TestEnity();
                GlobalData.hero = _t;

                EnemyEnity _enemy = new EnemyEnity();
                _enemy.MyEnity.SetProperty("position", new Vector3(-12, 0, 0));
                _enemy.MyEnity.SetProperty("patrolTarget", _t.MyEnity);*/
            });
        });
    }

}
