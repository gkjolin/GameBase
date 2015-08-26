using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class UIFightWin : MonoBehaviour {

    private Transform m_transform;
    private Image image_0;
    private Image image_1;
	void Start () {
        Init();
	}

    private void Init()
    {
        m_transform = this.transform;
        image_0 = m_transform.Find("Image").GetComponent<Image>();
        image_1 = m_transform.Find("Image1").GetComponent<Image>();
        image_0.gameObject.SetActive(false);
        image_1.gameObject.SetActive(false);
        this.Invoke("PlayWorldEffect", 1);
        //PlayWorldEffect();
    }

    private void PlayWorldEffect()
    {
        image_0.gameObject.SetActive(true);
        //image_1.gameObject.SetActive(true);

        image_0.rectTransform.localScale = new Vector3(8, 8, 8);
        image_1.rectTransform.localScale = new Vector3(8, 8, 8);

        image_0.rectTransform.DOScale(Vector3.one, 0.2f);
        image_1.rectTransform.DOScale(Vector3.one, 0.2f).SetDelay(0.2f).OnStart(() => { image_1.gameObject.SetActive(true); });
    }

    public void SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
    }

}
