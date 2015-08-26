using UnityEngine;
using System.Collections;
using Game;
public class ParticleEffectManager : MonoBehaviour {

    private static ParticleEffectManager _instance;
    private GameObject _goParticleContainer;
    public static ParticleEffectManager Instance
    {
        get { if (_instance == null) { _instance = new ParticleEffectManager(); } return _instance; }
    }
    void Awake()
    {
        _goParticleContainer = GameObject.Find("GameObject_particle");
    }
	void Start () {
	
	}

    public GameObject LoadEffect(string name,GameObject parent = null)
    {
        GameObject _go = ResourceManager.Instance.LoadNewPrefab("/Effects/" + name);
        if (parent != null)
        {
            _go.transform.SetParent(parent.transform);
        }
        else { _go.transform.SetParent(_goParticleContainer.transform); }
        ResetEffect(_go);
        if(_go.GetComponent<ParticleEffect>() == null)_go.AddComponent<ParticleEffect>();
        return _go;
    }

    private void ResetEffect(GameObject _go)
    {
        _go.transform.localPosition = Vector3.zero;
        _go.transform.localScale = Vector3.one;
        _go.transform.localRotation = Quaternion.identity;
    }

    public static float GetParticleSystemLength(Transform _transform)
    {
        ParticleSystem[] _arrPS = _transform.GetComponentsInChildren<ParticleSystem>();
        float maxLength = 0f;
        for (int i = 0; i < _arrPS.Length; i++)
        {
            ParticleSystem ps = _arrPS[i];
            if (ps.enableEmission)
            {
                if (ps.loop == false)
                {
                    float _psLength = 0f;
                    _psLength = ps.startDelay + Mathf.Max(ps.duration, ps.startLifetime);
                    maxLength = Mathf.Max(maxLength, _psLength);
                }
            }
        }
        return maxLength;
    }
}
