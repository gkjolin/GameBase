using UnityEngine;
using System.Collections;
using Game;

public class UIEffectEvent : MonoBehaviour {

    private string _effectName;

    public string EffectName
    {
        get { return _effectName; }
    }
	void Start () {
        _effectName = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnComplete()
    {
        Debug.Log("effect complete :　effectName : " + _effectName);
        //gameObject.SetActive(false);
        //DataEventSource.Instance.FireEvent();
    }
}
