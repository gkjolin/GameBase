using UnityEngine;
using System.Collections;

public class TestCameraFit : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Screen height :" + Screen.height + "   width : " + Screen.width);
        int ManualWidth = GlobalData.SCREEN_WIDTH;
        int ManualHeight = GlobalData.SCREEN_HEIGHT;
        int manualHeight;
        if (System.Convert.ToSingle(Screen.height) / Screen.width > System.Convert.ToSingle(ManualHeight) / ManualWidth)
            manualHeight = Mathf.RoundToInt(System.Convert.ToSingle(ManualWidth) / Screen.width * Screen.height);
        else
            manualHeight = ManualHeight;
        Camera camera = GetComponent<Camera>();
        float scale = System.Convert.ToSingle(manualHeight / ManualWidth);
        camera.fieldOfView *= scale;
    }

}
