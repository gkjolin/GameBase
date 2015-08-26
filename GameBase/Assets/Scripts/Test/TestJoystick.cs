using UnityEngine;
using System.Collections;
using Game;
public class TestJoystick : MonoBehaviour
{
    private RectTransform m_transform;
    private ETCJoystick _joystick;
    private ETCButton _button;
  
    void Start()
    {
        Init();
        InitEvent();
    }

    private void Init()
    {
        m_transform = this.transform as RectTransform;
        _joystick = m_transform.GetComponent<ETCJoystick>();
    }

    private void InitEvent()
    {
        _joystick.onMoveStart.AddListener(OnMoveStart);
        _joystick.onMove.AddListener(OnMoving);
        _joystick.onMoveEnd.AddListener(OnMoveEnd);
        _joystick.onTouchStart.AddListener(OnTouchStart);
        _joystick.onTouchUp.AddListener(OnTouchUp);
        _joystick.OnPressDown.AddListener(OnPressDown);
    }

    private void OnPressDown()
    {
    }

    private void OnTouchUp()
    {
    }

    private void OnTouchStart()
    {
    }

    private void OnMoving(Vector2 arg0)
    {
        GameInput.Instance.JoystickMove(arg0);
        /*Vector3 _v3 = new Vector3(arg0.x, 0, arg0.y);
        GlobalData.hero.MyEnity.SetProperty("moveSpeed",1.0f);
        GlobalData.hero.MyEnity.SetProperty("rotation",_v3);

        Vector3 _v33 = _v3 * Time.deltaTime * _speed;
        GlobalData.hero.MyEnity.SetProperty("position", _v33);*/

        //_sub.localRotation = Quaternion.LookRotation(_v3);
        /*_animator.SetFloat("MoveSpeed", 1);
        _goHero.transform.Translate(_v3 * Time.deltaTime * _speed);*/
    }

    private void OnMoveEnd()
    {
        GlobalData.hero.MyEnity.SetProperty("actionName","idle01");
        //GlobalData.hero.MyEnity.SetProperty("moveSpeed", 0.0f);
        //_animator.SetFloat("MoveSpeed", 0);
    }

    private void OnMoveStart()
    {
    }

    void Update()
    {

    }
}
