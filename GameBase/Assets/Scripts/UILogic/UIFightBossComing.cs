using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class UIFightBossComing : MonoBehaviour {

    private Transform m_transform;
    private Image image_arrow;

	void Start () {
        Init();
	}

    private void Init()
    {
        m_transform = this.transform;
        image_arrow = m_transform.Find("Image_arrow").GetComponent<Image>();
        PlayArrowEffect();
    }

    private void PlayArrowEffect()
    {
        image_arrow.rectTransform.DOLocalMoveX(100, 0.5f).SetRelative(true).SetLoops(-1, LoopType.Yoyo);
    }

    public void SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
    }
}
