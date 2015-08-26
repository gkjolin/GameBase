using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SceneMoveTest : MonoBehaviour
{
    private Transform m_transform;
    private Transform[] arr_layers = new Transform[5];
    //private float[] arr_distance = new float[5] { 1f, 1f, 1f, 1f, 1f };
    private float[] arr_distance = new float[5] { 1f, 1f, 0.8f, 0.6f, 0.4f };
    private float screen_width;
    private float scene_width;
    private float move_speed = 1f;
    private float move_time_one_setp = 1f;
    private float scene_left_x;
    private float scene_right_threshold_x;
    private Transform transform_actor;

    private static SceneMoveTest _instance;

    public static SceneMoveTest Instance
    {
        get { return SceneMoveTest._instance; }
    }
    void Start()
    {
        Init();
    }

    private void Init()
    {
        _instance = this;
        m_transform = this.transform;
        Transform layer1 = m_transform.Find("XiYangYeWai_001_A");
        Transform layer2 = m_transform.Find("XiYangYeWai_001_B");
        Transform layer3 = m_transform.Find("XiYangYeWai_001_C");
        Transform layer4 = m_transform.Find("XiYangYeWai_001_D");
        Transform layer5 = m_transform.Find("XiYangYeWai_001_E");
        transform_actor = layer5.Find("Actor");
        arr_layers[0] = layer5;
        arr_layers[1] = layer4;
        arr_layers[2] = layer3;
        arr_layers[3] = layer2;
        arr_layers[4] = layer1;
        Vector3[] arr_viewport_point = CameraManager.Instance.GetMainCameraViewportWorldPoint(m_transform.position.z);
        screen_width = arr_viewport_point[1].x - arr_viewport_point[0].x;
        scene_width = m_transform.GetComponent<BoxCollider>().size.x;
        scene_left_x = (scene_width - screen_width) / 2;
        scene_right_threshold_x = -(scene_width - screen_width);
        m_transform.localPosition = new Vector3(scene_left_x, m_transform.localPosition.y, m_transform.localPosition.z);
    }

    private void Move()
    {
        int direction = Input.mousePosition.x >= Screen.width / 2 ? -1 : 1;
        transform_actor.GetComponent<ActorMove>().Move(direction);
        if (direction == 1)
        {
            if (arr_layers[0].localPosition.x >= 0)
            {
                return;
            }
        }
        else
        {
            if (arr_layers[0].localPosition.x <= scene_right_threshold_x)
            {
                return;
            }
        }
        float move_distance = direction * move_speed + arr_layers[0].localPosition.x;
        if (move_distance > 0)
        {
            move_distance = 0;
        }
        else if (move_distance < scene_right_threshold_x)
        {
            move_distance = scene_right_threshold_x;
        }
        for (int i = 0; i < arr_layers.Length; i++)
        {
            arr_layers[i].DOLocalMoveX(move_distance * arr_distance[i], move_time_one_setp).SetEase(Ease.Linear);
        }
    }

    public void DoMove(float distance,float duration)
    {
        float move_distance = -distance * move_speed + arr_layers[0].localPosition.x;
        if (move_distance > 0)
        {
            move_distance = 0;
        }
        else if (move_distance < scene_right_threshold_x)
        {
            move_distance = scene_right_threshold_x;
        }
        Debug.Log("map move distance :"+move_distance);
        for (int i = 0; i < arr_layers.Length; i++)
        {
            arr_layers[i].DOLocalMoveX(move_distance * arr_distance[i], duration).SetEase(Ease.Linear);
        }
    }

    private void OnMouseDown()
    {
        //UIArtNumber.CreatNumber("8882345", transform_actor, ConvertCoordinate(transform_actor.Find("Soldier/head").position));
        //Move(); return; 
        return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo = new RaycastHit();
        if (Physics.Raycast(ray, out hitinfo))
        {
            float endx = hitinfo.point.x;
            transform_actor.GetComponent<ActorMove>().DoMove(endx);
            DoMove(endx, transform_actor.GetComponent<ActorMove>().move_time);
        }
    }

    public Vector3 GetHeadScreenPoint()
    {
        Vector3 v = CameraManager.Instance.MainCamera.WorldToScreenPoint(new Vector3(transform_actor.position.x, transform_actor.position.y + 1.8f, transform_actor.position.z));
        v = CameraManager.Instance.UICamera.ScreenToWorldPoint(v);
        return v;
    }

}
