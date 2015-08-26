using UnityEngine;
using System.Collections;

public class ShowGround : MonoBehaviour {
    public float Height=0;

    public bool IsOrthogonal = false;

    public float _rate=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Init(float rate)
    {
        _rate = rate;
    }
    public float GetYZRate()
    {
        return _rate;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < 6; i++)
        {
            Gizmos.DrawLine(this.transform.position + Vector3.forward * 1.5f * i, this.transform.position + Vector3.right * 20 + Vector3.forward * 1.5f * i);
        }
        Gizmos.color = Color.red;
        for (int i = 0; i < 6; i++)
        {
            Gizmos.DrawLine(this.transform.position + Vector3.forward * 0.75f * (2*i+1), this.transform.position + Vector3.right * 20 + Vector3.forward * 0.75f * (2*i+1));
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, this.transform.position + Vector3.forward * 7.5f);
        Gizmos.DrawLine(this.transform.position + Vector3.right * 20, this.transform.position + Vector3.forward * 7.5f + Vector3.right * 20);
        Gizmos.DrawLine(this.transform.position, this.transform.position + Vector3.forward * 7.5f + Vector3.up * Height);
        Gizmos.DrawLine(this.transform.position + Vector3.right * 20, this.transform.position + Vector3.right * 20 + Vector3.forward * 7.5f + Vector3.up * Height);

        if (IsOrthogonal)
        {
            Gizmos.color = Color.red;

            Vector3 dir = Camera.main.transform.forward;
            dir.Normalize();


            Gizmos.DrawLine(this.transform.position, this.transform.position + dir * 100);
            Gizmos.DrawLine(this.transform.position + Vector3.right * 20, this.transform.position + Vector3.right * 20 + dir * 100);

            //Vector3 dir_up = this.transform.position + Vector3.forward * 7.5f + Vector3.up * Height - Camera.main.transform.position;
            //dir.x = 0;
            //dir.Normalize();

            //Gizmos.DrawLine(this.transform.position + Vector3.forward * 7.5f + Vector3.up * Height, this.transform.position + Vector3.forward * 7.5f + Vector3.up * Height + dir_up * 100);
            //Gizmos.DrawLine(this.transform.position + Vector3.forward * 7.5f + Vector3.up * Height + Vector3.right * 30, this.transform.position + Vector3.forward * 7.5f + Vector3.up * Height + Vector3.right * 30 + dir_up * 100);

        }
        else
        {
            Gizmos.color = Color.blue;

            Vector3 dir = this.transform.position - Camera.main.transform.position;
            dir.x = 0;
            dir.Normalize();
            Gizmos.DrawLine(this.transform.position, this.transform.position + dir * 100);
            Gizmos.DrawLine(this.transform.position + Vector3.right * 30, this.transform.position + Vector3.right * 30 + dir * 100);

            Vector3 dir_up = this.transform.position + Vector3.forward * 7.5f + Vector3.up * Height - Camera.main.transform.position;
            dir.x = 0;
            dir.Normalize();

            Gizmos.DrawLine(this.transform.position + Vector3.forward * 7.5f + Vector3.up * Height, this.transform.position + Vector3.forward * 7.5f + Vector3.up * Height + dir_up * 100);
            Gizmos.DrawLine(this.transform.position + Vector3.forward * 7.5f + Vector3.up * Height + Vector3.right * 30, this.transform.position + Vector3.forward * 7.5f + Vector3.up * Height + Vector3.right * 30 + dir_up * 100);
        }
    }

}
