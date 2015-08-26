using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;
public class SceneMove : MonoBehaviour {

    private Transform m_transform;
    private Transform tf_l1;
    private Transform tf_cloud;
    private Transform tf_cloud1;
    private float l1_width;
    private Transform tf_hero;
    private Animator animator_hero;
    private Camera sceneCamera;
    private float viewport_width;
    private float distance_camera_to_scene = 50f;
    private float d_value_of_viewport_bg;
	void Start () {
        Init();
	}

    private void Init()
    {

        m_transform = this.transform;
        tf_l1 = m_transform.Find("Bg");
        tf_cloud1 = m_transform.Find("Cloud1");
        tf_cloud = tf_l1.Find("Cloud");
        l1_width = tf_l1.Find("ShiYan_ChangJing_001").GetComponent<BoxCollider>().size.x;
        Debug.Log("scene bg width " + l1_width);
        tf_hero = tf_l1.Find("Actor/Soldier");
        animator_hero = tf_hero.GetComponent<Animator>();

        sceneCamera = Camera.main;
        distance_camera_to_scene = m_transform.localPosition.z - sceneCamera.transform.localPosition.z;
        GetCameraViewSize();
        d_value_of_viewport_bg = viewport_width - l1_width;

        MoveCloud();
        //tf_cloud.gameObject.SetActive(false);
    }

    private void MoveLayer()
    {
        animator_hero.SetFloat("MoveSpeed",1f);
        tf_cloud1.DOLocalMoveX(-0.5f, 1).SetRelative(true).SetEase(Ease.Linear);
        tf_hero.DOLocalMoveX(1, 1).SetRelative(true).SetEase(Ease.Linear).OnComplete(() => { animator_hero.SetFloat("MoveSpeed", 0); });
        if (tf_l1.localPosition.x >= d_value_of_viewport_bg)
        {
            if ((tf_l1.localPosition.x - 1) >= d_value_of_viewport_bg)
            {
                tf_l1.DOLocalMoveX(-1, 1).SetRelative(true).SetEase(Ease.Linear);
            }
            else
            {
                tf_l1.DOLocalMoveX(d_value_of_viewport_bg, 1).SetEase(Ease.Linear);
            }
        }

    }

    private void MoveCloud()
    {
        tf_cloud.DOLocalMoveX(-viewport_width, 50).SetRelative(true).SetEase(Ease.Linear).OnComplete(() => { tf_cloud.localPosition = new Vector3(10f + tf_l1.localPosition.x, 0f, -1f); MoveCloud(); });
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(2,2,100,50),"walk"))
        {
            MoveLayer();
            //UIArtNumber.CreatNumber("12345", m_transform, 0);

        }
    }

    private Vector3 vec_world;
    private void OnMouseDown()
    {
        Debug.Log("Scene Move receive mousedown");
        /*UIArtNumber.CreatNumber("8882345", tf_hero.Find("head"),ConvertCoordinate());
        / *Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
        }* /
        MoveLayer();*/
        
    }

    private void GetCameraViewSize()
    {
        Vector3[] corners = CameraManager.GetCameraViewportWorldPoint(sceneCamera, distance_camera_to_scene);
        viewport_width = (corners[1].x - corners[0].x);
        Debug.Log("width : " + viewport_width);
    }

    /*private Vector3 ConvertCoordinate()
    {
        Vector3 v = tf_hero.Find("head").position;
        Vector3 vv = CameraManager.Instance.MainCamera.WorldToScreenPoint(v);
        Debug.Log("hero head world point : " + v + "   screen point : " + vv + "   pointer point : " + Input.mousePosition);
        Vector3 vvv = CameraManager.Instance.UI3DCamera.ScreenToWorldPoint(vv);
        Debug.Log("ui3d world pointer : " + vvv);
        return vvv;
    }*/

}
