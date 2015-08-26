using UnityEngine;
using System.Collections;

public class SceneLogic : MonoBehaviour {

	// Use this for initialization
    private Transform m_transform;
    private ActorMove actor_move;
    private SceneMoveTest scene_move;
	void Start () {
        Init();
	}
	
    private void Init()
    {
        m_transform = this.transform;
        /*actor_move = m_transform.Find("Scene/XiYangYeWai_WuJianMing_001_A/Actor").GetComponent<ActorMove>();
        scene_move = m_transform.Find("Scene/").GetComponent<SceneMoveTest>();*/
    }


    private void OnBecameVisible()
    {
        Debug.Log("on became visible");
    }

    private void OnBecameInvisible()
    {
        Debug.Log("on became in visible");
    }

    private void OnMouseDown()
    {
        Debug.Log("receive mouse click");
    }
}
