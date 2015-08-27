using UnityEngine;
using System.Collections;

/// <summary>
/// 将代码添加到我们的相机物体上，运行游戏，鼠标在我们创建的地面上点击，控制台就会输出点击点的坐标，
/// 通过上面的简单的例子，我们就可以得到目的点的坐标，具体做法：当我们点击鼠标时，从我们的摄像机朝我们鼠标的方向发射一条射线，
/// 当射线与地面发生碰撞时，输出碰撞点的坐标，这个坐标就是鼠标点击到地面的点的坐标，也就是目标点坐标。
/// </summary>
public class Pathfinding : MonoBehaviour {
    private static readonly string CUBY_NAME = "Cube";

    private GameObject _cube;

    void Start()
    {
        _cube = GameObject.Find(CUBY_NAME);
    }

    // Use this for initialization
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //定义一条从主相机射向鼠标位置的一条射向
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //判断射线是否发生碰撞
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.name != CUBY_NAME)
                {
                    Debug.Log(hit.point);
                    //_cube.transform.LookAt(hit.point);

                    Vector3 moveDir = (hit.point - _cube.transform.position).normalized * 0.1f;

                    _cube.GetComponent<CharacterController>().Move(moveDir);
                    _cube.GetComponent<CharacterController>().Move(Vector3.down);
                    //iTween.Stop(_cube.gameObject);
                    //iTween.MoveTo(_cube.gameObject, hit.point, 2);
                }
            }
        }

    }
}
