using UnityEngine;
using System.Collections.Generic;

/// /// <summary>
/// 技能释放处理
/// @author MXL
/// @date 2015-07
/// </summary>

public class SkillDispose : MonoBehaviour {

    //private List<ParticleSystem> particleSystems = new List<ParticleSystem>();

    //private bool isOver = true;


    public int time = 90;

    public int id = 0;

	// Use this for initialization
	void Start () {

        //Transform transform;
        //GameObject obj;
        //ParticleSystem particleSystem;
        //for(int i = 0; i < gameObject.transform.childCount; i++)
        //{
        //    transform = gameObject.transform.GetChild(i);
        //    if (transform != null)
        //    {
        //        obj = transform.gameObject;
        //        if (obj != null)
        //        {
        //            particleSystem = obj.GetComponent<ParticleSystem>();
        //            if (particleSystem != null)
        //            {
        //                particleSystems.Add(particleSystem);
        //            }
        //        }
        //    }
        //}
	}
	
	// Update is called once per frame
	void Update () {
        //isOver = true;
        //if (particleSystems.Count > 0)
        //{
        //    for (int i = 0; i < particleSystems.Count; i++)
        //    {
        //        if (!particleSystems[i].isStopped)
        //        {
        //            isOver = false;
        //            break;
        //        }
        //    }

        //    if (isOver)
        //    {
        //        GameObject.Destroy(this.gameObject);
        //    }
        //}




        time--;

        if (time <= 0)
        {
            string otherName = name.Substring(0, name.LastIndexOf("("));

            EffectsManager.getInstance().get(otherName).recyleObj(id);
        }
	}
}
