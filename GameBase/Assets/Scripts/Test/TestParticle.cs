using UnityEngine;
using System.Collections;

public class TestParticle : MonoBehaviour
{
    private float endTime;
    public int loop = 1;
    void Start() {
        /*_ps = this.transform.GetComponent<ParticleSystem>();
        _ps.loop = false;
        endTime = _ps.startLifetime + _ps.startDelay;*/
        endTime = ParticleSystemLength(this.transform);
        if(endTime>0)
        {
            StartCoroutine(OnEnd(endTime));
        }
	}

    private IEnumerator OnEnd(float _time)
    {
        yield return new WaitForSeconds(_time);
        Debug.Log("on end : " + _time);
        //Destroy(gameObject);
    }

    /*void Update()
    {
        if(_ps.isStopped)
        {
            Debug.Log("particle system stop  on update");
        }
    }*/
	static float ParticleSystemLength(Transform transform)
	{
		ParticleSystem []particleSystems = transform.GetComponentsInChildren<ParticleSystem>();
		float maxDuration = 0;
		foreach(ParticleSystem ps in particleSystems){
			if(ps.enableEmission){
				if(ps.loop){
					return -1f;
				}
				float duration = 0f;
				if(ps.emissionRate <=0){
					duration = ps.startDelay + ps.startLifetime;
				}else{
					duration = ps.startDelay + Mathf.Max(ps.duration,ps.startLifetime);
				}
				if (duration > maxDuration) {
					maxDuration = duration;
				}
			}

		}
		return maxDuration;
	}
   
}
