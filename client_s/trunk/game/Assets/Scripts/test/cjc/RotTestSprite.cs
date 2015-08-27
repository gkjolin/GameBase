using UnityEngine;
using System.Collections;

public class RotTestSprite : MonoBehaviour {

    public GameObject _src;

    public GameObject _dst;


    public GameObject _cjc;

    private Vector3 _centre;

	// Use this for initialization
	void Start () 
    {
        _centre = new Vector3(8, 0, 8);
	}
	
	// Update is called once per frame
	void Update () 
    {
        float angle = Vector3.Angle(_src.transform.position, _dst.transform.position);

        // Debug.Log("angle1:" + angle);


        float dot = Vector3.Dot(_src.transform.position.normalized, _dst.transform.position.normalized);
        // Debug.Log("angle2:" + dot);


        // work();

        testPos();
	}

    public void work()
    {
        Vector3 c = _src.transform.position + new Vector3(
            (_dst.transform.position.x - _src.transform.position.x) * 0.3f,
            (_dst.transform.position.y - _src.transform.position.y) * 0.3f,
            (_dst.transform.position.z - _src.transform.position.z) * 0.3f);

        transform.position = c;

        transform.Rotate(new Vector3(0, 90, 0));
        transform.TransformPoint(5, 0, 0);

        //Vector2 v2 = new Vector2(c.x, c.y);
        //Vector2.ro

        
        

#if false
        //transform.RotateAround(_up, 0.1f);

        transform.RotateAround(_centre, Vector3.up, Time.deltaTime * -30);

        Vector3 a = transform.position;
        Debug.Log("" + transform.eulerAngles);
#endif
    }

    private void testPos() 
    {
        float x = transform.position.x;
        float z = transform.position.z;
        
        Debug.Log("ry:" + transform.rotation.y);

        float lea = transform.localEulerAngles.y;
        float f1 = (lea + 90.0f) / 180.0f * Mathf.PI;
        float f2 = (lea - 90.0f) / 180.0f * Mathf.PI;

#if true
        float x1 = Mathf.Sin(f1) * m_Radius + x;
        float z1 = Mathf.Cos(f1) * m_Radius + z;

        float x2 = Mathf.Sin(f2) * m_Radius + x;
        float z2 = Mathf.Cos(f2) * m_Radius + z;

        _src.transform.position = new Vector3(x1, 1, z1);
        _dst.transform.position = new Vector3(x2, 1, z2);
#else
        float x1 = Mathf.Cos(angle + 90) * m_Radius + x;
        float z1 = Mathf.Sin(angle + 90) * m_Radius + z;

        float x2 = Mathf.Cos(angle - 90) * m_Radius + x;
        float z2 = Mathf.Sin(angle - 90) * m_Radius + z;

        _src.transform.position = new Vector3(x1, 1, z1);
        _dst.transform.position = new Vector3(x2, 1, z2);
#endif
    }
    
    //-------------------------------------------------------------------------------------------------------------------
    public Transform m_Transform;
    public float m_Radius = 7; // 圆环的半径
    public float m_Theta = 0.1f; // 值越低圆环越平滑
    public Color m_Color = Color.green; // 线框颜色

    void OnDrawGizmos()
    {
#if true
        if (m_Transform == null) 
        {
            m_Transform = this.transform;
            return; 
        }

        if (m_Theta < 0.0001f) m_Theta = 0.0001f;

        // 设置矩阵
        Matrix4x4 defaultMatrix = Gizmos.matrix;
        Gizmos.matrix = m_Transform.localToWorldMatrix;

        // 设置颜色
        Color defaultColor = Gizmos.color;
        Gizmos.color = m_Color;

        // 绘制圆环
        Vector3 beginPoint = Vector3.zero;
        Vector3 firstPoint = Vector3.zero;
        for (float theta = 0; theta < 2 * Mathf.PI; theta += m_Theta)
        {
            float x = m_Radius * Mathf.Cos(theta);
            float z = m_Radius * Mathf.Sin(theta);
            Vector3 endPoint = new Vector3(x, 0, z);
            if (theta == 0)
            {
                firstPoint = endPoint;
            }
            else
            {
                Gizmos.DrawLine(beginPoint, endPoint);
            }
            beginPoint = endPoint;
        }

        // 绘制最后一条线段
        Gizmos.DrawLine(firstPoint, beginPoint);

        // 恢复默认颜色
        Gizmos.color = defaultColor;

        // 恢复默认矩阵
        Gizmos.matrix = defaultMatrix;
#endif

        Debug.DrawLine(_src.transform.position, _dst.transform.position, Color.blue);
        //aa();

        OnDrawGizmos2();
    }



    void OnDrawGizmos2()
    {
#if true
        // 设置寻路的目标点  
        float leay = transform.localEulerAngles.y;
        float x = transform.position.x;
        float z = transform.position.z;

        // draw 1                        
        float f1 = (leay + 90.0f) / 180.0f * Mathf.PI;
        float x1 = Mathf.Sin(f1) * 8 + x;
        float z1 = Mathf.Cos(f1) * 8 + z;
        Vector3 v1 = new Vector3(x1, transform.position.y, z1);
        Debug.DrawLine(transform.position, v1, Color.blue);

        // draw2 
        float f2 = (leay - 90.0f) / 180.0f * Mathf.PI;
        float x2 = Mathf.Sin(f2) * 8 + x;
        float z2 = Mathf.Cos(f2) * 8 + z;
        Vector3 v2 = new Vector3(x2, transform.position.y, z2);
        Debug.DrawLine(transform.position, v2, Color.blue);
#endif
    }
}
