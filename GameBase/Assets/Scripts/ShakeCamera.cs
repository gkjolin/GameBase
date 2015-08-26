using UnityEngine;
using System.Collections;

public enum ShakeType
{
    UpAndDown,
    InsideUnitSphere,
}
public class ShakeCamera : MonoBehaviour
{

    private Vector3 deltaPos = Vector3.zero;
    Camera cam;

    float  conTime = 2.0f;
    float r_Time = 0;

    bool isShake = false;
    Vector3 origin = Vector3.zero;

    ShakeType _shakeType = ShakeType.UpAndDown;

    // Use this for initialization
    void Start()
    {
        cam = this.GetComponent<Camera>();
        r_Time = -conTime-1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShake) return;
        if ((Time.time-r_Time) <= conTime)
        {
            transform.position -= deltaPos;
            switch (_shakeType)
            {
                case ShakeType.UpAndDown:
                    deltaPos = Random.insideUnitSphere / 2.6f;
                    deltaPos.x = 0;
                    deltaPos.z = 0;
                    break;
                case ShakeType.InsideUnitSphere:
                    deltaPos = Random.insideUnitSphere /5f;
                    deltaPos.x = Mathf.Clamp(deltaPos.x, -0.5f, 0.5f);
                    break;
            }
           
            transform.position += deltaPos;
        }
        else
        {
            isShake = false;
            this.transform.position = origin;
        }

    }

    public void shakeCamera(ShakeType shakeType, float durationTime=1)
    {
        _shakeType = shakeType;
        origin = this.transform.position;
        conTime = durationTime;
        r_Time = Time.time;
        isShake = true;
    }
}