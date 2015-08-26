using UnityEngine;
using System.Collections;

public class MyScreenPointTest : MonoBehaviour {
    public Transform OriginPos;
    public ShowGround _showGround;
	// Use this for initialization
	void Start () {
        SetPos(0,4.5f);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2f, 0));
        this.transform.position=new Vector3(pos.x,this.transform.position.y,this.transform.position.z);
	}

    public void SetPos(float x, float z)
    {
        this.transform.position = OriginPos.position + new Vector3(x, z * _showGround.GetYZRate(), z);
    }
}
