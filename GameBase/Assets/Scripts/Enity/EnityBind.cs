using UnityEngine;
using System.Collections;
using Game;
public class EnityBind : MonoBehaviour {

    private Enity _owner;
    public Enity Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }
	void Start () {
	
	}
    public void NewEvent(AnimationEvent args)
    {
        Debug.Log(" event receiver");
    }

    public void AttackEvent(AnimationEvent args)
    {
        Debug.Log(" event receiver  AttackEvent");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider name : " + other.gameObject.name);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("on collision enter " + collision.gameObject.name);
    }

}
