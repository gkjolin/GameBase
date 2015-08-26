using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    private Camera camera_ui;
    private Camera camera_main;
    private static CameraManager _instance;

    public static CameraManager Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        Init();
        _instance = this;
    }

	void Start () {
  
	}

    private void Init()
    {
        camera_main= GameObject.Find("Cameras/Main Camera").GetComponent<Camera>();
        camera_ui = GameObject.Find("Cameras/UICamera").GetComponent<Camera>();
    }

    public Camera UICamera
    {
        get { return camera_ui; }
    }


    public Camera MainCamera
    {
        get { return camera_main; }
    }

    public Vector3[] GetMainCameraViewportWorldPoint(float distance)
    {
        return GetCameraViewportWorldPoint(MainCamera, distance - MainCamera.transform.position.z);
    }

    /// <summary>
    /// 获取摄像机 视口每个点的坐标
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="distance"></param>摄像机到视口的距离
    /// <returns></returns>
    public static Vector3[] GetCameraViewportWorldPoint(Camera camera, float distance)
    {
        Vector3[] corners = new Vector3[4];
        // 左上
        corners[0] = camera.ViewportToWorldPoint(new Vector3(0, 1, distance));

        // 右上
        corners[1] = camera.ViewportToWorldPoint(new Vector3(1, 1, distance));

        // 左下
        corners[2] = camera.ViewportToWorldPoint(new Vector3(0, 0, distance));

        // 右下
        corners[3] = camera.ViewportToWorldPoint(new Vector3(1, 0, distance));

        return corners;
    }
}
