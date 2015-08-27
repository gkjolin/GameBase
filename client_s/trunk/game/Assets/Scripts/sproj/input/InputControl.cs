using UnityEngine;
using System.Collections;

public class InputControl : MonoBehaviour {

    private static InputControl _self;
    public static InputControl Instance { get { return _self; } }

    public EasyTouch _etContext;
	public Canvas _etCanvas;
    public ETCJoystick _joystick;

    private void Awake()
    {
        _self = this;
    }

    private void Start()
    {
        if (_etContext == null) throw new System.InvalidOperationException("Easy Touch context not assigned");
		if (_etCanvas == null) throw new System.InvalidOperationException("Easy Touch canvas not assigned");
		if (_joystick == null) throw new System.InvalidOperationException("Easy Touch joystick not assigned");
		DontDestroyOnLoad (_etContext);
		DontDestroyOnLoad (_etCanvas);
    }

    public void Activate() { _joystick.activated = true; }
    public void Deactivate() { _joystick.activated = false; }

    public void OnMove(UnityEngine.Events.UnityAction<Vector2> OnMoveAction)
    {
        _joystick.onMove.AddListener(OnMoveAction);
    }
    public void RemoveOnMove(UnityEngine.Events.UnityAction<Vector2> OnMoveAction)
    {
        _joystick.onMove.RemoveListener(OnMoveAction);
    }
}
