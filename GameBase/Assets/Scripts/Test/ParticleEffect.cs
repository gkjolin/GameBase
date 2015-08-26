using UnityEngine;
using System.Collections;

public class ParticleEffect : MonoBehaviour
{
    private Transform _transfrom;
    private float _length;
    void Start()
    {
        _transfrom = this.transform;
        _length = GetParticleSystemLength();
        if(_length >0)
        {
            StartCoroutine(DestoryParticle(_length));
        }
    }

    private IEnumerator DestoryParticle(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private float GetParticleSystemLength()
    {
        ParticleSystem[] _arrPS = _transfrom.GetComponentsInChildren<ParticleSystem>();
        float maxLength = 0f;
        for (int i = 0; i < _arrPS.Length; i++)
        {
            ParticleSystem ps = _arrPS[i];
            if (ps.enableEmission)
            {
                if(ps.loop == false)
                {
                    float _psLength = 0f;
                    _psLength = ps.startDelay + Mathf.Max(ps.duration, ps.startLifetime);
                    maxLength = Mathf.Max(maxLength,_psLength);
                }
            }
        }
        return maxLength;
    }

}
