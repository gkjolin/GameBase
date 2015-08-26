using UnityEngine;
using System.Collections;

public class UIParticle : MonoBehaviour
{
    private ParticleSystem _ps;
    private static UIParticle _instance;

    public static UIParticle Instance
    {
        get { return UIParticle._instance; }
    }
    void Start()
    {
        _instance = this;
        _ps = gameObject.GetComponent<ParticleSystem>();
    }

    /*void Update()
    {
        if(_ps.isStopped)
        {

        }
    }*/

    public void SetActive(bool _b)
    {
        gameObject.SetActive(_b);
    }
}
